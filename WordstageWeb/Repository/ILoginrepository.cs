namespace WordstageWeb.Repository
{
    public interface ILoginrepository
    {
        Task<string> login(string userName, string password);
    }
}
