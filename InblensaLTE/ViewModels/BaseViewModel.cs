using CommunityToolkit.Mvvm.ComponentModel;

namespace InblensaLTE.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(isNotLoading))]
    bool _isLoading;

    public bool isNotLoading => !isNotLoading;
}