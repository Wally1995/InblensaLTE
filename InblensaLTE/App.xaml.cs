using InblensaLTE.Models;

namespace InblensaLTE;

public partial class App : Application
{
    public static UserInfo UserInfo;
    public App()
    {
        UserAppTheme = AppTheme.Light;
        InitializeComponent();
        // Preferences.Clear();
        
        MainPage = new AppShell();
    }
}