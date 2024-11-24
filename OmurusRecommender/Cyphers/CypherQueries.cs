namespace OmurusRecommender.Cyphers
{

    public class CypherQueries
    {
        public const string CreateUser = "CREATE (u:User { Id: $id, FirstName: $firstName, Email: $email, LastName: $lastName, City: $city }) RETURN u.resultProperty";
        public const string CreateInterest = "CREATE (u:Interest { Id: $id, Title: $title, Code: $code }) RETURN u.resultProperty";
        public const string CreateSubInterest = "CREATE (u:SubInterest { Id: $id, Title: $title, Code: $code , InterestId:$interestId }) RETURN u.resultProperty";
        // Create or update user node with interests and subinterests
        public const string CreateUserInterest = @"
                    MERGE (user:User { id: $userId })
                    SET user.interests = $interests";

        public const string CreateUserInterests = @"
                MATCH (u:User {Id: $userId})
                UNWIND $interests AS interest
                MATCH (i:Interest {Id: interest.id})
                MERGE (u)-[:HAS_INTEREST]->(i)";

        public const string CreateInterestSubInterest = @"MATCH (interest:Interest {Id: $interestId})
                MATCH (subinterest:Subinterest {Id: $subinterestId})
                CREATE (interest)-[:HAS_SUBINTEREST]->(subinterest)";

        public const string CreateBulkInterestSubInterest = @"            
                UNWIND $interests AS interest
                UNWIND $subinterests AS subinterest
                MATCH (i:Interest {id: interest}), (s:SubInterest {id: subinterest})
                MERGE (i)-[:HAS_SUBINTEREST]->(s)";

        public const string CreateSubInterestRelationships = @"
               MATCH (si1:SubInterest)
               OPTIONAL MATCH (si2:SubInterest)
               WHERE si1.InterestId = si2.InterestId AND si1.Id <> si2.Id
               WITH si1, si2
               WHERE si2 IS NOT NULL
              CREATE (si1)-[:SUB_INTEREST_RELATES_TO]->(si2)";

        public const string CreateExistingInterestSubInterestRelationship = @"
              MATCH (si:SubInterest)
              OPTIONAL MATCH (i:Interest {Id: si.InterestId})
              WITH si, i
              WHERE i IS NOT NULL
              CREATE (si)-[:HAS_SUB_INTEREST_INTEREST]->(i)";

    }
}
