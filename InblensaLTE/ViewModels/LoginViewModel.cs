using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InblensaLTE.Helpers;
using InblensaLTE.Models;
using InblensaLTE.Pages;
using InblensaLTE.Services;

namespace InblensaLTE.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty] 
    string username;

    [ObservableProperty]
    string password;

    private readonly ApiService _apiService;

    public LoginViewModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    [RelayCommand]
    async Task Login()
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await Shell.Current.DisplayAlert("Error", "Es necesario llenar todos los campos", "Ok");
            Password = string.Empty;
        }
        else
        {
            var loginModel = new LoginModel()
            {
                Email = username, Password = password
            };

            var response = await _apiService.Login(loginModel);

            if (!string.IsNullOrEmpty(response.Token))
            {
                //P@$$w0rd1
                SecureStorage.RemoveAll(); 
                Preferences.Set("Token", response.Token);
                var jsonToken = new JwtSecurityTokenHandler().ReadToken(response.Token) as JwtSecurityToken;
                
                var role = jsonToken.Claims.FirstOrDefault(q => q.Type.Equals(ClaimTypes.Role))?.Value;

                var userInfo = new UserInfo()
                {
                    Username = Username,
                    Role = role
                };

                App.UserInfo = userInfo;
                
                MenuBuilder.BuildMenu();
                await Shell.Current.GoToAsync($"{nameof(MainPage)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Correo o clave invalidos", "Ok");
            }
        }
    }
}