namespace BlazorSampleCommerce.Services
{
    public class AuthService
    {
        public bool IsLoggedIn { get; set; } = false;
        public string UserEmail { get; set; } = "";

        public void Login(string email)
        {
            IsLoggedIn = true;
            UserEmail = email;
        }

        public void Logout()
        {
            IsLoggedIn = false;
            UserEmail = "";
        }
    }
}
