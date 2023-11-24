using OmurusRecommender.Models.User;

namespace OmurusRecommender.Services.Interfaces
{
    public interface ICreateNode<T>
    {
        Task<string> CreateNode(T node);
    }
}
    