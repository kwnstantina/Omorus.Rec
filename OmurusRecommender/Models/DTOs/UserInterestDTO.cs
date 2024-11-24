using OmurusRecommender.Models.Interests;
using OmurusRecommender.Models.SubInterests;

namespace OmurusRecommender.Models.DTOs
{
    public class UserInterestDTO
    {
        public Guid UserId { get; set; }
        public List<Interest>? Interests { get; set; }
    }
}
