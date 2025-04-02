# Mads195.MadsMauiLib
MadsMauiLib is a library for the Mads195 Maui Framework. It is a collection of classes and functions that are useful for developing applications with the Maui Framework.
## Controls
### FlexiDialog
Built on **.NET MAUI CommunityToolKit Popup**, FlexiDialog is a pre-built dialog that can be used to show a message, ask for a confirmation, or ask for a password. There are 3 types of dialogs:
- SingleField - A single text field
- ConfirmFieldPassword - A password field that requires a confirmation
- ConfirmField - A text field that requires a confirmation

#### Usage
```
var oValueZ = await this.popupService.ShowPopupAsync<Mads195.MadsMauiLib.ViewModels.Controls.FlexiDialogViewModel>(onPresenting: oVmZ => {
    oVmZ.Title = "Choose Password";
    oVmZ.Message = "Please enter your password";
    oVmZ.ButtonSubmitText = "OK";
    oVmZ.ButtonCancelText = "Cancel";
    oVmZ.Keyboard = Keyboard.Default;
    oVmZ.DialogType = Mads195.MadsMauiLib.ViewModels.Controls.FlexiDialogType.ConfirmFieldPassword;
    oVmZ.ValidationRegex = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).+$";
    oVmZ.MinLength = 8;
    oVmZ.MaxLength = 20;
});
```

### SectionTitle
Section title simply displays a consistently formatted title to use within a view.

#### Usage
```
<ContentPage ...
             xmlns:madsmauilib="clr-namespace:Mads195.MadsMauiLib.Controls;assembly=MadsMauiLib"
             ...>
```

```
<madsmauilib:SectionTitle Text="Hello Maddie!" Padding="20,0,20,0" TextColor="Red" HorizontalTextAlignment="Start" HorizontalOptions="FillAndExpand" />
```