using System.IdentityModel.Tokens.Jwt;
using InblensaLTE.Helpers;
using InblensaLTE.Pages;

namespace InblensaLTE.ViewModels;

public partial class LoadingPageViewModel : BaseViewModel
{
    public LoadingPageViewModel()
    {
        CheckUserLoginDetails();
    }

    private async void CheckUserLoginDetails()
    {
        var token = Preferences.Get("Token", string.Empty);

        if (string.IsNullOrEmpty(token))
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }
        else
        {
            var jsonToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;

            bool isValid = jsonToken.ValidTo >= DateTime.UtcNow;

            if (!isValid)
            {
                Preferences.Clear();
                await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
            }
            else
            {
                MenuBuilder.BuildMenu();
                await Shell.Current.GoToAsync($"{nameof(MainPage)}");
            }
        }
    }
}