# Mads195.MadsMauiLib
MadsMauiLib is a library for the Mads195 Maui Framework. It is a collection of classes and functions that are useful for developing applications with the Maui Framework.
## New Features (May 2025)
**DateTimePicker**
- DateTimePicker is a simple select type picker control allowing the independent selection of hours and minutes.
**TwoDigitConverter**
- TwoDigitConverter is a converter that converts a number to a two digit string. It is used where a leading zero should be displayed such as an hour, minute, day or month value but that value is stored as an integer.

## Getting Started
MadsMauiLib can be installed via Nuget. Recommend that MauiCommunityToolkit is also installed. Once installed, register the package in your MauiProgram.cs file:
```
var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .UseMauiCommunityToolkit()
        .UseMadsMauiLib()
        .RegisterServices()
        .RegisterViewModels();
```

In your XAML file, add the namespace:
```
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             ...
             xmlns:madsmauilib="clr-namespace:Mads195.MadsMauiLib.Controls;assembly=MadsMauiLib"
             ...>
```

## Controls
### FlexiDialog
Built on **.NET MAUI CommunityToolKit Popup**, FlexiDialog is a pre-built dialog that can be used to show a message, ask for a confirmation, or ask for a password. There are 3 types of dialogs:
- SingleField - A single text field
- ConfirmFieldPassword - A password field that requires a confirmation
- ConfirmField - A text field that requires a confirmation
- InfoList - A list of key values in two columns - column 1: key, column 2: value
- SingleCheckbox - A checkbox with a label that passes back text values of `true` or `false`
- DateTimePicker - A simple date/time picker that returns a **time (HH:mm)** value as a string. Date return will be added in v1.0.150.

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

## Converters
### TwoDigitConverter
TwoDigitConverter is a converter that converts a number to a two digit string. It is used where a leading zero should be displayed such as an hour, minute, day or month value but that value is stored as an integer.

#### Usage
```
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             ...
             xmlns:converters="clr-namespace:Mads195.MadsMauiLib.Converters"
             ...
             >
```

```
<ResourceDictionary>
    <converters:TwoDigitConverter x:Key="TwoDigitConverter" />
</ResourceDictionary>
```

```
<Entry Text="{Binding SelectedHour, Converter={StaticResource TwoDigitConverter}}" Keyboard="Numeric" MaxLength="2" />
```

## Notes
- This package is in early development and is not yet complete. It is intended to be used as a starting point for building applications with the Maui Framework. Not warranty is given or implied and the risk of using this package is entirely the responsibility of the user. If you find bugs or have suggestions, please open an issue on the GitHub repository.
- Images used within this package are from Bootstrap Icons https://icons.getbootstrap.com/ and are licensed under an MIT license.
- When a package that contains controls using images is used via Nuget in another project, the images do not display. This is when the package is packed, the process doesn't know what to do with the images and ignores them. To fix this, a targets file is included `Directory.Build.Targets`. The original source is here: https://github.com/mattleibow/PackagingMauiAssets/blob/main/MauiLibrary/PackMauiAssets.targets. This issue is described in Maui issue 19804 https://github.com/dotnet/maui/issues/19804.