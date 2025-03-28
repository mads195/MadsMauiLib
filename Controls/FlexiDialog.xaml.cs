namespace Mads195.MadsMauiLib.Controls;

using CommunityToolkit.Maui.Views;
using Mads195.MadsMauiLib.ViewModels.Controls;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class FlexiDialog : Popup
{
    public FlexiDialog(FlexiDialogViewModel oVmZ)
	{
		InitializeComponent();
        BindingContext = oVmZ;
        //SetPopupWidth();
    }
    //private void SetPopupWidth()
    //{
    //    double screenWidth = Application.Current.MainPage.Width;
    //    double margin = 20;
    //    double popupWidth = screenWidth - (2 * margin);

    //    PopupBorder.WidthRequest = popupWidth;
    //}
}