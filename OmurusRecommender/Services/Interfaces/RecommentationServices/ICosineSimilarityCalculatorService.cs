namespace OmurusRecommender.Services.Interfaces.RecommentationServices
{
    public interface ICosineSimilarityCalculatorService
    {
        double CalculateCosineSimilarity(List<string> keywordsA, List<string> keywordsB);
    }
}
