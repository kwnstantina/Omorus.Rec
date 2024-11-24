using Microsoft.ML.Data;

namespace OmurusRecommender.Models.Tags
{
    public class TrainingData
    {
        // The input text: a combination of the Interest and SubInterest titles
        [ColumnName("Text")]

        public string Text { get; set; }

        // The tag (label) that corresponds to this input text
        [ColumnName("Tag")]
        public string Tag { get; set; }



    }
}
