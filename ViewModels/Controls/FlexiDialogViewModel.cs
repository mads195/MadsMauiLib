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
        private ObservableCollection<KeyValuePair<string, string>> infoItems = new();
        /**
         * Bindable Properties - Private
         */
        private string password { get; set; }
        private string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }
        private string confirmPassword { get; set; }
        private string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; OnPropertyChanged("ConfirmPassword"); }
        }
        private bool isSingleField { get; set; } = false;
        private bool IsSingleField
        {
            get { return isSingleField; }
            set { isSingleField = value; OnPropertyChanged("IsSingleField"); }
        }
        private bool isConfirmField { get; set; } = false;
        private bool IsConfirmField
        {
            get { return isConfirmField; }
            set { isConfirmField = value; OnPropertyChanged("IsConfirmField"); }
        }
        private bool isConfirmFieldPassword { get; set; } = false;
        private bool IsConfirmFieldPassword
        {
            get { return isConfirmFieldPassword; }
            set { isConfirmFieldPassword = value; OnPropertyChanged("IsConfirmFieldPassword"); }
        }
        private bool isCheckboxField { get; set; } = false;
        private bool IsCheckboxField
        {
            get { return isCheckboxField; }
            set { isCheckboxField = value; OnPropertyChanged("IsCheckboxField"); }
        }
        private bool isCheckboxFieldChecked { get; set; } = false;
        private bool IsCheckboxFieldChecked
        {
            get { return isCheckboxFieldChecked; }
            set { isCheckboxFieldChecked = value; OnPropertyChanged("IsCheckboxFieldChecked"); }
        }
        private bool isInfoList { get; set; } = false;
        private bool IsInfoList
        {
            get { return isInfoList; }
            set { isInfoList = value; OnPropertyChanged("IsInfoList"); }
        }
        private string textField { get; set; }
        private string TextField
        {
            get { return textField; }
            set { textField = value; OnPropertyChanged("TextField"); }
        }
        private string textConfirmValue { get; set; }
        private string TextConfirmValue
        {
            get { return textConfirmValue; }
            set { textConfirmValue = value; OnPropertyChanged("TextConfirmValue"); }
        }
        private string textConfirmValueRepeat { get; set; }
        private string TextConfirmValueRepeat
        {
            get { return textConfirmValueRepeat; }
            set { textConfirmValueRepeat = value; OnPropertyChanged("TextConfirmValueRepeat"); }
        }
        private string passwordValue { get; set; }
        private string PasswordValue
        {
            get { return passwordValue; }
            set { passwordValue = value; OnPropertyChanged("PasswordValue"); }
        }
        private string passwordValueRepeat { get; set; }
        private string PasswordValueRepeat
        {
            get { return passwordValueRepeat; }
            set { passwordValueRepeat = value; OnPropertyChanged("PasswordValueRepeat"); }
        }
        private string checkBoxValue { get; set; }
        private string CheckBoxValue
        {
            get { return checkBoxValue; }
            set { checkBoxValue = value; OnPropertyChanged("CheckBoxValue"); }
        }
        internal readonly IPopupService popupService;
        public FlexiDialogViewModel(IPopupService popupService)
        {
            this.popupService = popupService;
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
                    IsSingleField = true;
                    break;
                case FlexiDialogType.ConfirmField:
                    Console.WriteLine("FlexiDialogViewModel.OnOpened - ConfirmField");
                    IsConfirmField = true;
                    break;
                case FlexiDialogType.ConfirmFieldPassword:
                    Console.WriteLine("FlexiDialogViewModel.OnOpened - ConfirmFieldPassword");
                    IsConfirmFieldPassword = true;
                    break;
                case FlexiDialogType.InfoList:
                    Console.WriteLine("FlexiDialogViewModel.OnOpened - InfoList");
                    if (InfoItems != null)
                    {
                        InfoItems = new ObservableCollection<KeyValuePair<string, string>>(InfoItems);
                    }
                    IsInfoList = true;
                    break;
                case FlexiDialogType.SingleCheckbox:
                    Console.WriteLine("FlexiDialogViewModel.OnOpened - SingleCheckbox");
                    IsCheckboxField = true;
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
                    if (string.IsNullOrEmpty(PasswordValue) && string.IsNullOrEmpty(PasswordValue))
                    {
                        throw new Exception("A value is required");
                        //popupService.ClosePopup();
                        //return;
                    }

                    if (PasswordValue != PasswordValue)
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
    }

    public enum FlexiDialogType
    {
        SingleField,
        ConfirmFieldPassword,
        ConfirmField,
        InfoList,
        SingleCheckbox
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
