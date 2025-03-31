namespace Mads195.MadsMauiLib.Controls;

using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Mads195.MadsMauiLib.ViewModels.Controls;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class FlexiDialog : Popup
{
    public FlexiDialog(FlexiDialogViewModel oVmZ)
	{
		InitializeComponent();
        BindingContext = oVmZ;
        
        Opened += OnOpened;
    }
    async void OnOpened(object? sender, PopupOpenedEventArgs e)
    {
        await ((FlexiDialogViewModel)BindingContext).OnOpened();
    }
}