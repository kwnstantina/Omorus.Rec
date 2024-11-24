using Microsoft.ML.Data;

namespace OmurusRecommender.Models.Tags
{
    public class PreditionTagResult
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabel { get; set; }
    }
}
