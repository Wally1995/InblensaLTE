using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InblensaLTE.Controls;

public partial class FlyOutHeader : StackLayout
{
    public FlyOutHeader()
    {
        InitializeComponent();
    }

    private void SetValues()
    {
        // if (App.UserInfo != null)
        // {
        //     lblUserName.Text = App.UserInfo.Username;
        //     lblRole.Text = App.UserInfo.Role;
        // }
        // else
        // {
        //     
        // }
        lblUserName.Text = "Walter Blandon";
        lblRole.Text = "Super Admin";
    }
}