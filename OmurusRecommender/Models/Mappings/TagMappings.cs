using OmurusRecommender.Models.Tags;

namespace OmurusRecommender.Models.Mappings
{
    public static class TagMappings
    {
        #region Seeds Interests Title
        private static readonly string InterestType_Gaming_Title = "Gaming";
        private static string InterestType_Entertainment_Title = "Entertainment";
        public static readonly string InterestType_Sports_Title = "Sports";
        private static readonly string InterestType_Watersports_Title = "Water Sports";
        private static readonly string InterestType_ExtremeSports_Title = "Extreme sports";
        private static readonly string InterestType_Errands_Title = "Errands";
        private static readonly string InterestType_Assignments_Title = "Assignments";
        private static readonly string InterestType_Beauty_Title = "Beauty";
        private static readonly string InterestType_Other_Title = "Other";
        private static readonly string InterestType_Art_Title = "Art";
        #endregion

        #region Seeds SubInterests Title
        private static readonly string SubInterestType_PokemonGo_Title = "Pokemon Go";
        private static readonly string SubInterestType_LOL_Title = "LOL";
        private static readonly string SubInterestType_Fortnite_Title = "Fortnite";
        private static readonly string SubInterestType_FIFA_Title = "FIFA";
        private static readonly string SubInterestType_Dota_Title = "Dota";
        private static readonly string SubInterestType_Party_Title = "Party";
        private static readonly string SubInterestType_Cinema_Title = "Cinema";
        private static readonly string SubInterestType_Theatre_Title = "Theatre";
        private static readonly string SubInterestType_Concerts_Title = "Concerts";
        private static readonly string SubInterestType_Pool_Title = "Pool";
        private static readonly string SubInterestType_Bowling_Title = "Bowling";
        private static readonly string SubInterestType_Darts_Title = "Darts";
        private static readonly string SubInterestType_Basketball_Title = "Basketball";
        private static readonly string SubInterestType_5X5_Title = "5X5";
        private static readonly string SubInterestType_Running_Title = "Running";
        private static readonly string SubInterestType_Hiking_Title = "Hiking";
        private static readonly string SubInterestType_ScubaDiving_Title = "Scuba Diving";
        private static readonly string SubInterestType_Sailing_Title = "Sailing";
        private static readonly string SubInterestType_JetSki_Title = "Jet Ski";
        private static readonly string SubInterestType_SkyDiving_Title = "Sky Diving";
        private static readonly string SubInterestType_BungeeJumping_Title = "Bungee Jumping";
        private static readonly string SubInterestType_Climbing_Title = "Climbing";
        private static readonly string SubInterestType_DogSitting_Title = "Dog Sitting";
        private static readonly string SubInterestType_Caring_Title = "Caring";
        private static readonly string SubInterestType_Watering_Title = "Watering";
        private static readonly string SubInterestType_Cleaning_Title = "Cleaning";
        private static readonly string SubInterestType_Gardening_Title = "Gardening";
        private static readonly string SubInterestType_Picking_Title = "Picking";
        private static readonly string SubInterestType_LocalGuides_Title = "Local Guides";
        private static readonly string SubInterestType_Nails_Title = "Nails";
        private static readonly string SubInterestType_MakeUp_Title = "MakeUp";
        private static readonly string SubInterestType_HairStyling_Title = "Hair Styling";
        private static readonly string SubInterestType_Styling_Title = "Styling";
        private static readonly string SubInterestType_Painting_Title = "Painting";
        private static readonly string SubInterestType_Sculpture_Title = "Sculpture";
        #endregion

        public static List<TrainingData> trainingData = new List<TrainingData> {
            new TrainingData { Text = "Gaming Dota Sky Fortnite Pokemon Go Pokemon Go", Tag = "Gaming" },
            new TrainingData { Text = "Football Basketball Sports 5x5 Running", Tag = "Sports" },
            new TrainingData { Text = "Art Painting Sculpture", Tag = "Art" },
            new TrainingData { Text = "Cinema Movie", Tag = "Cinema" },
            new TrainingData { Text = "Water Sports Diving", Tag = "Water Sports" },
            new TrainingData { Text = "Beauty Makeup Nails Hair Styling", Tag = "Beauty" },
            new TrainingData { Text = "Errands Dog Sitting Grocery Shopping Local Guides Household Cleaning Gardening Picking Delivery Baby Sitting", Tag = "Errands" },
            new TrainingData { Text = "Extreme Sports Sky Diving Bungee Jumping Climbing Paragliding", Tag = "Extreme Sports" },
            new TrainingData { Text = "Entertainment Party Theatre Cinema Bowling Darts Movie Cinema Music Concert", Tag = "Entertainment" },
            new TrainingData { Text = "Other", Tag = "Other" },
   

    };

  }
}
