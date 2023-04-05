namespace WordstageWeb.Repository
{
    public interface ILoginrepository
    {
        Task<bool> login(string userName, string password);
    }
}
