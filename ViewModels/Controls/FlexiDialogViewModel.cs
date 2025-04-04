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
        /**
         * Bindable Properties - Private
         */
        //[ObservableProperty]
        //internal string password;
        //[ObservableProperty]
        //internal string confirmPassword;
        //[ObservableProperty]
        //internal bool isSingleField;
        //[ObservableProperty]
        //internal bool isConfirmField;
        ////[ObservableProperty]
        ////internal bool isConfirmFieldPassword;
        //[ObservableProperty]
        //internal bool isCheckboxField;
        //[ObservableProperty]
        //internal bool isCheckboxFieldChecked;
        //[ObservableProperty]
        //internal bool isInfoList;
        //[ObservableProperty]
        //internal string textField;
        //[ObservableProperty]
        //internal string textConfirmValue;
        //[ObservableProperty]
        //internal string textConfirmValueRepeat;
        //[ObservableProperty]
        //internal string passwordValue;
        //[ObservableProperty]
        //internal string passwordValueRepeat;

        //private bool isConfirmFieldPassword { get; set; } = false;
        //public bool IsConfirmFieldPassword
        //{
        //    get { return isConfirmFieldPassword; }
        //    internal set { isConfirmFieldPassword = value; OnPropertyChanged(nameof(IsConfirmFieldPassword)); }
        //}

        //[ObservableProperty]
        private string password { get; set; }
        public string Password
        {
            get { return password; }
            internal set { password = value; OnPropertyChanged(nameof(Password)); }
        }
        private string confirmPassword { get; set; }
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            internal set { confirmPassword = value; OnPropertyChanged(nameof(ConfirmPassword)); }
        }
        private bool isSingleField { get; set; } = false;
        public bool IsSingleField
        {
            get { return isSingleField; }
            internal set { isSingleField = value; OnPropertyChanged(nameof(IsSingleField)); }
        }
        private bool isConfirmField { get; set; } = false;
        public bool IsConfirmField
        {
            get { return isConfirmField; }
            internal set { isConfirmField = value; OnPropertyChanged(nameof(IsConfirmField)); }
        }
        private bool isConfirmFieldPassword { get; set; } = false;
        public bool IsConfirmFieldPassword
        {
            get { return isConfirmFieldPassword; }
            internal set { isConfirmFieldPassword = value; OnPropertyChanged(nameof(IsConfirmFieldPassword)); }
        }
        private bool isCheckboxField { get; set; } = false;
        public bool IsCheckboxField
        {
            get { return isCheckboxField; }
            internal set { isCheckboxField = value; OnPropertyChanged(nameof(IsCheckboxField)); }
        }
        private bool isCheckboxFieldChecked { get; set; } = false;
        public bool IsCheckboxFieldChecked
        {
            get { return isCheckboxFieldChecked; }
            internal set { isCheckboxFieldChecked = value; OnPropertyChanged(nameof(IsCheckboxFieldChecked)); }
        }
        private bool _isInfoList { get; set; } = false;
        public bool IsInfoList
        {
            get { return _isInfoList; }
            internal set { _isInfoList = value; OnPropertyChanged(nameof(IsInfoList)); }
        }
        private string textField { get; set; }
        public string TextField
        {
            get { return textField; }
            internal set { textField = value; OnPropertyChanged(nameof(TextField)); }
        }
        private string textConfirmValue { get; set; }
        public string TextConfirmValue
        {
            get { return textConfirmValue; }
            internal set { textConfirmValue = value; OnPropertyChanged(nameof(TextConfirmValue)); }
        }
        private string textConfirmValueRepeat { get; set; }
        public string TextConfirmValueRepeat
        {
            get { return textConfirmValueRepeat; }
            internal set { textConfirmValueRepeat = value; OnPropertyChanged(nameof(TextConfirmValueRepeat)); }
        }
        private string passwordValue { get; set; }
        public string PasswordValue
        {
            get { return passwordValue; }
            internal set { passwordValue = value; OnPropertyChanged((PasswordValue)); }
        }
        private string passwordValueRepeat { get; set; }
        public string PasswordValueRepeat
        {
            get { return passwordValueRepeat; }
            internal set { passwordValueRepeat = value; OnPropertyChanged(nameof(PasswordValueRepeat)); }
        }
        private string checkBoxValue { get; set; }
        public string CheckBoxValue
        {
            get { return checkBoxValue; }
            internal set { checkBoxValue = value; OnPropertyChanged(nameof(CheckBoxValue)); }
        }
        internal readonly IPopupService popupService;
        public FlexiDialogViewModel(IPopupService popupService)
        {
            this.popupService = popupService;
            IsCheckboxField = false;
            isCheckboxFieldChecked = false;
            IsConfirmField = false;
            IsConfirmFieldPassword = false;
            IsSingleField = false;
            IsInfoList = false;
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
