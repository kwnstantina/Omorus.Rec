namespace OmurusRecommender.Models.SubInterests
{
    public class SubInterest
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }

        public string? Code { get; set; }

        public Guid InterestId { get; set; }
    }
}
