using BlazorSampleCommerce.DTOs;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BlazorSampleCommerce.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly ProtectedLocalStorage _localStorage;
        public bool IsLoggedIn { get; private set; }
        public UserDto? CurrentUser { get; private set; }
        public event Action? OnAuthStateChanged;

        public AuthService(HttpClient http, ProtectedLocalStorage localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                var users = await _http.GetFromJsonAsync<List<UserDto>>("User");
                var user = users?.FirstOrDefault(u => u.Email == email && u.Password == password);

                if (user != null)
                {
                    IsLoggedIn = true;
                    CurrentUser = user;
                    await _localStorage.SetAsync("user_session", user);
                    OnAuthStateChanged?.Invoke();
                    return true;
                }
            }
            catch { /* TODO: Add it to Log File */ }
            return false;
        }

        public async Task RestoreSessionAsync()
        {
            try
            {
                var result = await _localStorage.GetAsync<UserDto>("user_session");
                if (result.Success && result.Value != null)
                {
                    CurrentUser = result.Value;
                    IsLoggedIn = true;
                }
            }
            catch{/*ODO: Add to .log file*/}
        }

        public async Task LogoutAsync()
        {
            IsLoggedIn = false;
            CurrentUser = null;
            await _localStorage.DeleteAsync("user_session");
            OnAuthStateChanged?.Invoke();
        }
    }
}
