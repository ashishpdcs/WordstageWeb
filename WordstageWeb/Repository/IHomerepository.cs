using WordstageWeb.Models;

namespace WordstageWeb.Repository
{
    public interface IHomerepository
    {
        Task<List<Language>> LoadLanguageDropdown();
    }
}
