using WordstageWeb.Models;

namespace WordstageWeb.Repository
{
    public interface IOrderrepository
    {
        Task<List<Product>> GetProductDetails(string productId);
    }
}
