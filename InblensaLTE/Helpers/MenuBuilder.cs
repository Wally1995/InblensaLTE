using InblensaLTE.Controls;
using InblensaLTE.Pages;

namespace InblensaLTE.Helpers;

public static class MenuBuilder
{
    public static void  BuildMenu()
    {
        // Clear all items from shell
        Shell.Current.Items.Clear();

        // Set Flyout header
        Shell.Current.FlyoutHeader = new FlyOutHeader();

        // Create and add Flyout items
        var flyOutItem = new FlyoutItem
        {
            Title = "Admin Car Management",
            Route = nameof(MainPage),
            FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
            Items =
            {
                new ShellContent
                {
                    Icon = "store.png",
                    Title = "Admin Page 1",
                    ContentTemplate = new DataTemplate(typeof(MainPage))
                }
            }
        };


        // Add FlyoutItem if not already in the list
        if (!Shell.Current.Items.Contains(flyOutItem))
        {
            Shell.Current.Items.Add(flyOutItem);
        }
            
    }
}