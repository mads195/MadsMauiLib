# Mads195.MadsMauiLib
MadsMauiLib is a library for the Mads195 Maui Framework. It is a collection of classes and functions that are useful for developing applications with the Maui Framework.
## New Features (April 2025)
**FlexiDialog**
- FlexiDialog has been extended to include two new dialog types: InfoList, a list of key/values and SingleCheckbox, a single checkbox with a label.
- Simple share option for having a link that allows you to share a text value via the built-in share sheet
- Hero message - simple prominent message

**LabelItem**
- Displays a left label and right aligned value - both are bindable.
- LabelItem has been extended to include a bindable command that can be used to execute a command when the label is tapped.
## Controls
### FlexiDialog
Built on **.NET MAUI CommunityToolKit Popup**, FlexiDialog is a pre-built dialog that can be used to show a message, ask for a confirmation, or ask for a password. There are 3 types of dialogs:
- SingleField - A single text field
- ConfirmFieldPassword - A password field that requires a confirmation
- ConfirmField - A text field that requires a confirmation
- InfoList - A list of key values in two columns - column 1: key, column 2: value
- SingleCheckbox - A checkbox with a label that passes back text values of `true` or `false`

#### Usage
**Example: password confirmation**
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
    oVmZ.ShareText = $"Some text that you would like to share";
    oVmZ.ShareLabel = "Share"; // A text label for the share button
    oVmZ.HeroMessage = "Hello!"; // A message that is displayed in the hero area beneath the title and message
    oVmZ.HeroFontSize = 24; // Font size of the hero message
});
```
**Example: a list of information**
```
var aExtraData = new ObservableCollection<KeyValuePair<string, string>>
{
    new KeyValuePair<string, string>("Apples", "10"),
    new KeyValuePair<string, string>("Durians", "3"),
    new KeyValuePair<string, string>("Kiwis", "56")
};

var oValueZ = await this.popupService.ShowPopupAsync<Mads195.MadsMauiLib.ViewModels.Controls.FlexiDialogViewModel>(onPresenting: viewModel => {
    viewModel.Title = "Some Information";
    viewModel.Message = "Some information is shown below";
    viewModel.ButtonSubmitText = "OK";
    viewModel.ButtonCancelText = "Cancel";
    viewModel.DialogType = Mads195.MadsMauiLib.ViewModels.Controls.FlexiDialogType.InfoList;
    viewModel.InfoItems = aExtraData;
});
```
**Note:** Several internally used properties are exposed to allow for customization of the dialog. These properties are not intended to be used by the developer and are typically used for comparison and validation purposes within the control. The properties are: `password`, `confirmPassowrd`, `isCheckboxFieldChecked`, `textField`, `textConfirmValue`, `textConfirmValueRepeat`, `passwordValue`, `passwordValueRepeat` and `checkBoxValue`. These values should not be considered as permanent and may change in future releases.

### SectionTitle
Section title simply displays a consistently formatted title to use within a view.

#### Usage
```
<ContentPage ...
             xmlns:madsmauilib="clr-namespace:Mads195.MadsMauiLib.Controls;assembly=MadsMauiLib"
             ...>
```

```
<madsmauilib:SectionTitle Text="Hello Mads195!" Padding="20,0,20,0" TextColor="Red" HorizontalTextAlignment="Start" HorizontalOptions="FillAndExpand" />
```

### LabelItem
Displays a label and a value. The label is on the left and the value is on the right. The label can be a string or a bindable property. A bindable command can be used to execute a command when the label is tapped.

#### Usage
```
<ContentPage ...
             xmlns:madsmauilib="clr-namespace:Mads195.MadsMauiLib.Controls;assembly=MadsMauiLib"
             ...>
```

```
<madsmauilib:LabelItem TextStart="Check Database" TextEnd="{Binding DatabaseCheck}" TapCommand="{Binding CheckDatabaseCommand}" Padding="0,10" />
```
