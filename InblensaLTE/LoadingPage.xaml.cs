using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InblensaLTE.ViewModels;

namespace InblensaLTE;

public partial class LoadingPage : ContentPage
{
    public LoadingPage(LoadingPageViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
    }
}