using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InblensaLTE.ViewModels;

namespace InblensaLTE.Pages;

public partial class InventoriesPage : ContentPage
{
    private readonly InventoryViewModel _inventoryViewModel;
    
    public InventoriesPage(InventoryViewModel inventoryViewModel)
    {
        InitializeComponent();
        BindingContext = inventoryViewModel;
        _inventoryViewModel = inventoryViewModel;
    }


    protected override async void OnAppearing()
    {
        
        base.OnAppearing();

        await _inventoryViewModel.GetInvetories();
    }
}