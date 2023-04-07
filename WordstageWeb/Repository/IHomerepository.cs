using WordstageWeb.Models;

namespace WordstageWeb.Repository
{
    public interface IHomerepository
    {
        Task<List<Language>> LoadLanguageDropdown();
        Task<List<ProductType>> LoadProductDropdown();
        Task<List<Product>> LoadProduct(string Productid, string from, string to);
    }
}
