using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InblensaLTE.Models;
using InblensaLTE.Services;

namespace InblensaLTE.ViewModels;

public partial class InventoryViewModel : BaseViewModel
{
    private readonly ApiService _apiService;
    public ObservableCollection<Inventory> Inventories { get; private set; } = new();

    public InventoryViewModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    [ObservableProperty] private bool isRefreshing;
    [ObservableProperty] private string id;

    [RelayCommand]
    public async Task GetInvetories()
    {
        if(IsLoading) return;

        try
        {
            IsLoading = true;

            if (Inventories.Any()) Inventories.Clear();

            var inventories = new List<Inventory>();

            inventories = await _apiService.GetInventories();

            foreach (var inventory in inventories)
            {
                Inventories.Add(inventory);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await Shell.Current.DisplayAlert("Error", "Ocurrio un error cargando los inventarios", "Ok");
        }
        finally
        {
            IsLoading = false;
            isRefreshing = false;
        }
    }

    [RelayCommand]
    public async Task Navigate()
    {
        App.Current.MainPage = new AppShell();
    }
}