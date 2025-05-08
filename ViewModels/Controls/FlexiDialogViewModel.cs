using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Mads195.MadsMauiLib.ViewModels.Controls
{
    public partial class FlexiDialogViewModel : ObservableObject
    {
        /**
         * Bindable Properties - Public
         */
        [ObservableProperty]
        string title = "";
        [ObservableProperty]
        string buttonCancelText = "Cancel";
        [ObservableProperty]
        string buttonSubmitText = "OK";
        [ObservableProperty]
        Keyboard keyboard = Keyboard.Default;
        [ObservableProperty]
        FlexiDialogType dialogType = FlexiDialogType.SingleField;
        [ObservableProperty]
        int maxLength = 50;
        [ObservableProperty]
        int minLength = 0;
        [ObservableProperty]
        string validationRegex = "";
        [ObservableProperty]
        string validationRegexMessage = "";
        [ObservableProperty]
        string minLengthMessage = "";
        [ObservableProperty]
        string heroMessage = "";
        [ObservableProperty]
        double heroFontSize = 14;
        [ObservableProperty]
        string message = "";
        [ObservableProperty]
        string shareText = "";
        [ObservableProperty]
        string shareLabel = "";
        [ObservableProperty]
        bool cancelShouldReturn = false;
        [ObservableProperty]
        string checkBoxLabel = "";
        [ObservableProperty]
        ObservableCollection<KeyValuePair<string, string>> infoItems = new();
        [ObservableProperty]
        int selectedHour = 0;
        [ObservableProperty]
        int selectedMinute = 0;
        /**
         * Bindable Properties - Private
         */
        [ObservableProperty]
        string password;
        [ObservableProperty]
        string confirmPassword;
        [ObservableProperty]
        bool isCheckboxFieldChecked;
        [ObservableProperty]
        string textField;
        [ObservableProperty]
        string textConfirmValue;
        [ObservableProperty]
        string textConfirmValueRepeat;
        [ObservableProperty]
        string passwordValue;
        [ObservableProperty]
        string passwordValueRepeat;
        [ObservableProperty]
        string checkBoxValue;

        public ObservableCollection<int> Hours { get; } = new ObservableCollection<int>(Enumerable.Range(0, 24));
        public ObservableCollection<int> Minutes { get; } = new ObservableCollection<int>(Enumerable.Range(0, 60));

        internal readonly IPopupService popupService;
        public FlexiDialogViewModel(IPopupService popupService)
        {
            this.popupService = popupService;
            //IsCheckboxField = false;
            isCheckboxFieldChecked = false;
            //IsConfirmField = false;
            //IsConfirmFieldPassword = false;
            //IsSingleField = false;
            //IsInfoList = false;
        }
        [RelayCommand(CanExecute = nameof(CanCancel))]
        internal async void OnCancel()
        {
            if (CancelShouldReturn)
            {
                try
                {
                    FlexiDialogResponse oFlexiDialogResponseZ = await PrepareReturnValue(FlexiDialogButton.Cancel);
                    popupService.ClosePopup(oFlexiDialogResponseZ);
                }
                catch (Exception ex)
                {
                    // Exception - cancel the submit and show the message
                    Message = ex.Message;
                    return;
                }
            }
            else
            {
                popupService.ClosePopup();
            }
        }
        internal bool CanCancel() => true;

        [RelayCommand(CanExecute = nameof(CanSubmit))]
        internal async void OnSubmit()
        {
            Console.WriteLine("FlexiDialogViewModel.OnSubmit");
            
            try
            {
                FlexiDialogResponse oFlexiDialogResponseZ = await PrepareReturnValue(FlexiDialogButton.Submit);
                popupService.ClosePopup(oFlexiDialogResponseZ);
            }
            catch(Exception ex)
            {
                // Exception - cancel the submit and show the message
                Message = ex.Message;
                return;
            }
        }
        internal bool CanSubmit() => true;

        internal async Task OnOpened()
        {
            Console.WriteLine("FlexiDialogViewModel.OnOpened");
            //IsMessageVisible = false;
            //Message = "";
            switch (DialogType)
            {
                case FlexiDialogType.SingleField:
                    Console.WriteLine("FlexiDialogViewModel.OnOpened - SingleField");
                    break;
                case FlexiDialogType.ConfirmField:
                    Console.WriteLine("FlexiDialogViewModel.OnOpened - ConfirmField");
                    break;
                case FlexiDialogType.ConfirmFieldPassword:
                    Console.WriteLine("FlexiDialogViewModel.OnOpened - ConfirmFieldPassword");
                    break;
                case FlexiDialogType.InfoList:
                    Console.WriteLine("FlexiDialogViewModel.OnOpened - InfoList");
                    if (InfoItems != null)
                    {
                        InfoItems = new ObservableCollection<KeyValuePair<string, string>>(InfoItems);
                    }
                    break;
                case FlexiDialogType.SingleCheckbox:
                    Console.WriteLine("FlexiDialogViewModel.OnOpened - SingleCheckbox");
                    break;
                case FlexiDialogType.DateTimePicker:
                    Console.WriteLine("FlexiDialogViewModel.OnOpened - DateTimePicker");
                    break;
            }
        }
        [RelayCommand]
        internal async void OnShare()
        {
            await Share.Default.RequestAsync(new ShareTextRequest
            {
                Text = ShareText,
                Title = Title
            });
        }

        internal async Task<FlexiDialogResponse> PrepareReturnValue(FlexiDialogButton oButtonZ)
        {
            string vEntryValue = "";
            switch (DialogType)
            {
                case FlexiDialogType.SingleField:
                    if (string.IsNullOrEmpty(TextField))
                    {
                        throw new Exception("A value is required");
                        //popupService.ClosePopup();
                        //return;
                    }
                    vEntryValue = TextField;
                    break;
                case FlexiDialogType.ConfirmField:
                    if (string.IsNullOrEmpty(TextConfirmValue) && string.IsNullOrEmpty(TextConfirmValueRepeat))
                    {
                        throw new Exception("A value is required");
                        //popupService.ClosePopup();
                        //return;
                    }

                    if (TextConfirmValue != TextConfirmValueRepeat)
                    {
                        throw new Exception("Your entries do not match");
                        //Message = "Your entries do not match";
                        //return;
                    }

                    vEntryValue = TextConfirmValue;
                    break;
                case FlexiDialogType.ConfirmFieldPassword:
                    if (string.IsNullOrEmpty(PasswordValue) || string.IsNullOrEmpty(PasswordValueRepeat))
                    {
                        throw new Exception("A value is required");
                        //popupService.ClosePopup();
                        //return;
                    }

                    if (PasswordValue != PasswordValueRepeat)
                    {
                        throw new Exception("Your entries do not match");
                        //Message = "Your entries do not match";
                        //return;
                    }

                    vEntryValue = PasswordValue;
                    break;
                case FlexiDialogType.SingleCheckbox:
                    vEntryValue = IsCheckboxFieldChecked ? "true" : "false";
                    break;
                case FlexiDialogType.DateTimePicker:
                    vEntryValue = $"{SelectedHour:D2}:{SelectedMinute:D2}";
                    break;
            }

            /**
             * Validation
             */
            // Check over min length
            if (vEntryValue.Length < MinLength)
            {
                throw new Exception(!string.IsNullOrEmpty(MinLengthMessage) ? MinLengthMessage : $"Entry must be at least {MinLength} characters");
                //Message = (!string.IsNullOrEmpty(MinLengthMessage) ? MinLengthMessage : $"Entry must be at least {MinLength} characters");
                //return;
            }

            // Regex
            if (!string.IsNullOrEmpty(ValidationRegex) && !Regex.IsMatch(vEntryValue, ValidationRegex))
            {
                throw new Exception(!string.IsNullOrEmpty(ValidationRegexMessage) ? ValidationRegexMessage : "The entry does not match the required format");
                //Message = (!string.IsNullOrEmpty(ValidationRegexMessage) ? ValidationRegexMessage : "The entry does not match the required format");
                //return;
            }

            FlexiDialogResponse oFlexiDialogResponseZ = new FlexiDialogResponse()
            {
                ButtonClicked = oButtonZ,
                Value = vEntryValue
            };

            return oFlexiDialogResponseZ;
        }

        [RelayCommand]
        internal async void OnDateTimeChange(string parameter)
        {
            switch (parameter)
            {
                case "HourIncrease":
                    if (SelectedHour < 23)
                        SelectedHour++;
                    break;

                case "HourDecrease":
                    if (SelectedHour > 0)
                        SelectedHour--;
                    break;

                case "MinuteIncrease":
                    if (SelectedMinute < 59)
                        SelectedMinute++;
                    else
                    {
                        SelectedMinute = 0;
                        if (SelectedHour < 23)
                            SelectedHour++;
                    }
                    break;

                case "MinuteDecrease":
                    if (SelectedMinute > 0)
                        SelectedMinute--;
                    else
                    {
                        SelectedMinute = 59;
                        if (SelectedHour > 0)
                            SelectedHour--;
                    }
                    break;
            }
        }

    }

    public enum FlexiDialogType
    {
        SingleField,
        ConfirmFieldPassword,
        ConfirmField,
        InfoList,
        SingleCheckbox,
        DateTimePicker
    }

    public enum FlexiDialogButton
    {
        Cancel,
        Submit
    }

    public class FlexiDialogResponse
    {
        public string? Value { get; set; }
        public FlexiDialogButton ButtonClicked { get; set; }
    }
}
