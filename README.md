<p align="center">
  <img src="https://mads195.s3.eu-west-2.amazonaws.com/public/mads195/mml_horizontal_300px.png" alt="MadsMauiLib"/>
</p>

# Mads195.MadsMauiLib
MadsMauiLib is a library for the Mads195 Maui Framework. It is a collection of classes and functions that are useful for developing applications with the Maui Framework.
## New Features (June 2025)
**FlexiDialog**
- FlexiDialog has been updated to include an IndeterminateTransfer dialog type. This uses the TransferProgressIndicator control to give a visual indication that something is happening between A and B.

**IndeterminateProgressBar**
- A control that shows a continuously travelling indicator (image or solid colour) moving from left-to-right to indicate that activity is happening.

**LabelItem**
- Label item is a control that displays a label and a value. The label is on the left and the value is on the right. The label can be a string or a bindable property. A bindable command can be used to execute a command when the label is tapped. TextEndDisplayStyle can be set between Text or Badge where Badge can be used to display a count such as notifications.

**TransferProgressIndicator**
- A control that gives a visual indication that something is being transferred from one point to another. E.g. a file upload. Left and right images can be specified.

## Features
**Card**
- Card is a control that can be used to display a title, text and inner content that can be child controls from the calling app.

**DateTimePicker**
- DateTimePicker is a simple select type picker control allowing the independent selection of hours and minutes.

**DateTimeFormatConverter**
- The DateTimeFormatConverter is a converter that converts a datetime value to a formatted string. Any valid C# datetime format can be specified as the parameter.

**IndeterminateProgressBar**
- A control that shows a continuously travelling indicator (image or solid colour) moving from left-to-right to indicate that activity is happening.

**MultiValueMatchConverter**
- MultiValueMatchConverter is a converter that takes multiple values and returns a boolean value. It is used to determine if each property matches a specific value.

**TwoDigitConverter**
- TwoDigitConverter is a converter that converts a number to a two digit string. It is used where a leading zero should be displayed such as an hour, minute, day or month value but that value is stored as an integer.

**ScreenTitle**
- ScreenTitle is a simple control that displays a title and an optional icon. The icon is displayed on the left and the title is displayed on the right. A bindable command can be used to execute a command when the icon or title is tapped.

**SolidButton**
- SolidButton is a simple button control that can be used to display a title and an optional icon. A bindable command can be used to execute a command when the button is tapped.

**TransferProgressIndicator**
- A control that gives a visual indication that something is being transferred from one point to another. E.g. a file upload. Left and right images can be specified.

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

For controls, add the namespace:
```
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             ...
             xmlns:mmlcontrols="clr-namespace:Mads195.MadsMauiLib.Controls;assembly=MadsMauiLib"
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

### Card
Card is a control that can be used to display a title, text and inner content that can be child controls from the calling app.

#### Usage
```
<mmlcontrols:Card Title="Card" ShowEditIcon="False" ShowTitle="False" ShowCardContent="False" Command="{Binding MyUsefulCommand}" CommandParameter="SomeText" BorderColor="Black" WidthRequest="160" Margin="20,10,20,10">
    <mmlcontrols:Card.InnerContent>
        <StackLayout>
            <Label Text="This is some content inside the card." />
        </StackLayout>
    </mmlcontrols:Card.InnerContent>
</mmlcontrols:Card>
```

### IndeterminateProgressBar
IndeterminateProgress is a control that shows a continuously travelling indicator (image or solid colour) moving from left-to-right to indicate that activity is happening.

#### Usage
```
<mmlcontrols:IndeterminateProgressBar
    BackgroundColor="#eeeeee"
    IndicatorColor="#2196F3"
    HeightRequest="20"
    IndicatorWidth="120"
    StrokeShape="{RoundRectangle CornerRadius='8'}"
    IndicatorImage="mml_chevron_right.png"
    ProgressSpeed="Fast" />
```

### LabelItem
Displays a label and a value. The label is on the left and the value is on the right. The label can be a string or a bindable property. A bindable command can be used to execute a command when the label is tapped.

#### Usage
```
<mmlcontrols:LabelItem 
TextStart="Check Database" 
TextEnd="{Binding MyCommandResult}" 
TapCommand="{Binding MyUsefulCommand}" 
Padding="0,10" />
```

### SectionTitle
Section title simply displays a consistently formatted title to use within a view.

#### Usage
```
<mmlcontrols:SectionTitle 
    Text="Hello Mads195!" 
    Padding="20,0,20,0" 
    TextColor="Red" 
    HorizontalTextAlignment="Start" 
    HorizontalOptions="FillAndExpand" />
```

### SolidButton
SolidButton is a simple button control that can be used to display a title and an optional icon. A bindable command can be used to execute a command when the button is tapped.

#### Usage
```
<mmlcontrols:SolidButton 
    Text="Hello Mads195!" 
    ImageSource="icon.png" 
    Command="{Binding MyUsefulCommand}" 
    CommandParameter="SomeText" 
    BackgroundColor="Red" 
    TextColor="White" 
    MaximumWidthRequest="100" />
```

### ScreenTitle
Displays a title and an optional icon. The icon is displayed on the left and the title is displayed on the right. A bindable command can be used to execute a command when the icon or title is tapped.

#### Usage
```
<mmlcontrols:ScreenTitle 
    Title="Hello Mads195!" 
    Byline="Welcome to the screen."
    TitleTextColor="Black"
    TitleFontSize="24"
    TitleFontAttributes="Bold"
    BylineTextColor="Gray"
    BylineFontSize="16"
    BylineFontAttributes="None"
    ImageSource="icon.png"
    ImageAspect="AspectFit"
    ImageHeight="40"
    ImageWidth="40"
    ImageColumnWidth="Auto"
    Padding="10"
    BackgroundColor="White" />
```

## TransferProgressIndicator
A control that gives a visual indication that something is being transferred from one point to another. E.g. a file upload. Left and right images can be specified.

#### Usage
```
<mmlcontrols:TransferProgressIndicator 
    TransferImageL="mml_box.png"
    TransferImageR="mml_box_fill.png"
    TransferBarHeight="30"
    TransferImageWidth="30" />
```

## Converters
Load the converters in your XAML file:
```
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             ...
             xmlns:mmlconverters="clr-namespace:Mads195.MadsMauiLib.Converters;assembly=MadsMauiLib"
             ...
             >
```

### TwoDigitConverter
TwoDigitConverter is a converter that converts a number to a two digit string. It is used where a leading zero should be displayed such as an hour, minute, day or month value but that value is stored as an integer.

#### Usage
```
<ResourceDictionary>
    <mmlconverters:TwoDigitConverter x:Key="TwoDigitConverter" />
</ResourceDictionary>
```

```
<Entry Text="{Binding SelectedHour, Converter={StaticResource TwoDigitConverter}}" Keyboard="Numeric" MaxLength="2" />
```

### DateTimeFormatConverter
DateTimeFormatConverter is a converter that converts a datetime value to a formatted string. Any valid C# datetime format can be specified as the parameter.

#### Usage
```
<ResourceDictionary>
    <mmlconverters:DateTimeFormatConverter x:Key="DateTimeFormatConverter" />
</ResourceDictionary>
```

```
<Entry Text="{Binding OurDateTimeValue, Converter={StaticResource DateTimeFormatConverter}, ConverterParameter='dd/MM/yyyy HH:mm'}" />
```

### MultiValueMatchConverter
MultiValueMatchConverter is a converter that takes multiple values and returns a boolean value. It is used to determine if each property matches a specific value. In the following example, the image is only visible if the first binding is `True` and the second binding is `False`. The converter parameter is a comma separated list of values that are used to compare against the bindings. The first value in the list is compared against the first binding, the second value is compared against the second binding, and so on. If all values match, the converter returns `True`, otherwise it returns `False`. An empty string can be passed as one of the parameter values. This is useful when you want to check if a value is empty or not. The converter will return `True` if the value is empty and `False` if it is not.

#### Usage
```
<ResourceDictionary>
    <mmlconverters:MultiValueMatchConverter x:Key="MultiValueMatchConverter" />
</ResourceDictionary>
```

```
<Image Source="{Binding Source={x:Reference self}, Path=IconSource}" Margin="20,0,0,0">
    <Image.IsVisible>
        <MultiBinding Converter="{StaticResource MultiValueMatchConverter}" ConverterParameter="True,False">
            <Binding Path="ShowEditIcon" />
            <Binding Path="ShowTitle" />
        </MultiBinding>
    </Image.IsVisible>
</Image>
```

## Notes
- This package is in early development and is not yet complete. It is intended to be used as a starting point for building applications with the Maui Framework. Not warranty is given or implied and the risk of using this package is entirely the responsibility of the user. If you find bugs or have suggestions, please open an issue on the GitHub repository.
- Images used within this package are from Bootstrap Icons https://icons.getbootstrap.com/ and are licensed under an MIT license.
- When a package that contains controls using images is used via Nuget in another project, the images do not display. This is when the package is packed, the process doesn't know what to do with the images and ignores them. To fix this, a targets file is included `Directory.Build.Targets`. The original source is here: https://github.com/mattleibow/PackagingMauiAssets/blob/main/MauiLibrary/PackMauiAssets.targets. This issue is described in Maui issue 19804 https://github.com/dotnet/maui/issues/19804.