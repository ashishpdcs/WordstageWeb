namespace WordstageWeb.Repository
{
    public interface ISignuprepository
    {
        Task<bool> SignUp(string firstName, string lastName, string emailAddress, string password, string usertype);
    }
}
