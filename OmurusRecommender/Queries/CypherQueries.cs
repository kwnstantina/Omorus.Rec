namespace OmurusRecommender.Queries
{

    public class CypherQueries
    {
        public const string CreateUser = "CREATE (u:User { Id: $id, FirstName: $firstName, Email: $email, LastName: $lastName, City: $city }) RETURN u.resultProperty";
        public const string CreateInterest = "CREATE (u:Interest { Id: $id, Title: $title }) RETURN u.resultProperty";
        public const string CreateSubInterest = "CREATE (u:SubInterest { Id: $id, $title }) RETURN u.resultProperty";
    }
}
