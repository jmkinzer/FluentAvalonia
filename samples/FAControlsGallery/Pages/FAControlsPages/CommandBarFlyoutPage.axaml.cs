using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FluentAvalonia.UI.Controls;
using FAControlsGallery.ViewModels;

namespace FAControlsGallery.Pages;

public partial class CommandBarFlyoutPage : FAControlsPageBase
{
    public CommandBarFlyoutPage()
    {
        InitializeComponent();
               
        DataContext = new CommandBarFlyoutPageViewModel();
        TargetType = typeof(CommandBarFlyout);

        this.FindControl<Button>("myImageButton").ContextRequested += OnMyImageButtonContextRequested;
    }

    private void OnMyImageButtonContextRequested(object sender, ContextRequestedEventArgs e)
    {
        ShowMenu(false);
        e.Handled = true;
    }

    private void MyImageButton_Click(object sender, RoutedEventArgs args)
    {
        ShowMenu(true);
    }

    private void ShowMenu(bool isTransient)
    {
        var flyout = Resources["CommandBarFlyout1"] as CommandBarFlyout;
        flyout.ShowMode = isTransient ? FlyoutShowMode.Transient : FlyoutShowMode.Standard;

        flyout.ShowAt(this.FindControl<Image>("Image1"));
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

}
