using OmurusRecommender.Models.Interests;
using OmurusRecommender.Models.SubInterests;

namespace OmurusRecommender.Models.DTOs
{
    public class InterestWithSubInterestForCreateDTO
    {
        public Interest Interest { get; set; }

        public SubInterest SubInterest { get; set; }
    }
}
