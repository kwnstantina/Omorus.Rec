/*
 * 
 * Cosine Similarity Formula
The formula for cosine similarity between two vectors 𝐴 and B is:
CosineSimilarity(A,B)= ∣∣A∣∣×∣∣B∣∣/A⋅B
Where:

A⋅B is the dot product of vectors 
∣∣A∣∣ is the magnitude (or length) of vector 
∣∣B∣∣ is the magnitude of vector 

*/

using OmurusRecommender.Services.Interfaces.RecommentationServices;

namespace OmurusRecommender.Services.Implementations.RecommentationServices
{
    public class CosineSimilarityCalculatorService: ICosineSimilarityCalculatorService
    {

    public double CalculateCosineSimilarity(List<string> keywordsA, List<string> keywordsB)
        {
            // Create a combined list of unique keywords
            var allKeywords = keywordsA.Union(keywordsB).ToList();

            // Create vectors based on the presence of keywords
            var vectorA = CreateVector(allKeywords, keywordsA);
            var vectorB = CreateVector(allKeywords, keywordsB);

            // Calculate dot product
            double dotProduct = DotProduct(vectorA, vectorB);

            // Calculate magnitudes
            double magnitudeA = Magnitude(vectorA);
            double magnitudeB = Magnitude(vectorB);

            // Calculate cosine similarity
            if (magnitudeA == 0 || magnitudeB == 0)
                return 0.0; // Avoid division by zero

            return dotProduct / (magnitudeA * magnitudeB);
        }

        private List<int> CreateVector(List<string> allKeywords, List<string> keywords)
        {
            return allKeywords.Select(k => keywords.Contains(k) ? 1 : 0).ToList();
        }

        private double DotProduct(List<int> vectorA, List<int> vectorB)
        {
            return vectorA.Zip(vectorB, (a, b) => a * b).Sum();
        }

        private double Magnitude(List<int> vector)
        {
            return Math.Sqrt(vector.Sum(x => x * x));
        }
    }
}
