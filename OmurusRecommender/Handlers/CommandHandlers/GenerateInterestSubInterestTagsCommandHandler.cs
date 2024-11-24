using MediatR;
using Microsoft.ML;
using Microsoft.ML.Data;
using OmurusRecommender.Commands;
using OmurusRecommender.Commands.Tags;
using OmurusRecommender.Cyphers;
using OmurusRecommender.Models.Mappings;
using OmurusRecommender.Models.Tags;
using OmurusRecommender.Services.Interfaces.INeo4jProvider;
using OmurusRecommender.Utils;

namespace OmurusRecommender.Handlers.CommandHandlers
{
    public class GenerateInterestSubInterestTagsCommandHandler : IRequestHandler<GenerateInterestSubInterestTagsCommand, CommandResult>
    {

        private readonly INeo4jProvider _neo4jProvider;
        private readonly MLContext _mlContext;
        private List<TrainingData> _trainingData;


        public GenerateInterestSubInterestTagsCommandHandler(INeo4jProvider neo4jProvider)
        {
            _neo4jProvider = neo4jProvider;
            _mlContext = new MLContext();
            _trainingData = TagMappings.trainingData;
        
        }

        public async Task<CommandResult> Handle(GenerateInterestSubInterestTagsCommand request, CancellationToken cancellationToken)
        {

            // Combine the Interest and SubInterest to create a body of text
            string inputText = $"{request?.CreateTagRecommendation.Interest} {request?.CreateTagRecommendation.SubInterest}";
            // Prepare the model
            var model = BuildModel();

            // Predict tags
            var predictedTags = PredictTags(model, inputText);


            return new CommandSuccessResult(ResultMessages.TagsGeneratedSuccessfully);

        }

        // Function to build the model
        private ITransformer BuildModel()
        {
            // Convert the data to IDataView
            var trainingData = _mlContext.Data.LoadFromEnumerable<TrainingData>(_trainingData);

            // Build the pipeline
            var pipeline =
               _mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(TrainingData.Tag))  // Convert 'Tag' to numeric key
            .Append(_mlContext.Transforms.Text.FeaturizeText("Features", nameof(TrainingData.Text)))  // Featurize the 'Text' column
            .Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))  // Use a classification trainer
            .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel", "PredictedLabel"))  // Map the predicted label back to the original tag
            .AppendCacheCheckpoint(_mlContext);


            // Train the model
            var model = pipeline.Fit(trainingData);
            return model;
        }
        private List<string> PredictTags(ITransformer model, string inputText)
        {
            // Create a prediction engine
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<TrainingData, PreditionTagResult>(model);

            // Create prediction data
            var prediction = predictionEngine.Predict(new TrainingData { Text = inputText });

            // Return predicted tag
            return new List<string> { prediction.PredictedLabel };
        }

    }
}
