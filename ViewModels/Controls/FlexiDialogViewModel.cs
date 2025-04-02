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
        /**
         * Bindable Properties - Private
         */
        [ObservableProperty]
        private string password = "";
        [ObservableProperty]
        private string confirmPassword = "";
        [ObservableProperty]
        private bool isSingleField = false;
        [ObservableProperty]
        private bool isConfirmField = false;
        [ObservableProperty]
        private bool isConfirmFieldPassword = false;
        [ObservableProperty]
        private bool isInfoList = false;
        [ObservableProperty]
        private string textField;
        [ObservableProperty]
        private string textConfirmValue;
        [ObservableProperty]
        private string textConfirmValueRepeat;
        [ObservableProperty]
        private string passwordValue;
        [ObservableProperty]
        private string passwordValueRepeat;
        [ObservableProperty]
        private ObservableCollection<KeyValuePair<string, string>> infoItems = new();
        readonly IPopupService popupService;
        public FlexiDialogViewModel(IPopupService popupService)
        {
            this.popupService = popupService;
        }
        [RelayCommand(CanExecute = nameof(CanCancel))]
        void OnCancel()
        {
            popupService.ClosePopup();
        }
        bool CanCancel() => true;

        [RelayCommand(CanExecute = nameof(CanSubmit))]
        void OnSubmit()
        {
            Console.WriteLine("FlexiDialogViewModel.OnSubmit");
            string vEntryValue = "";
            switch (DialogType)
            {
                case FlexiDialogType.SingleField:
                    if (string.IsNullOrEmpty(TextField))
                    {
                        popupService.ClosePopup();
                        return;
                    }
                    vEntryValue = TextField;
                    break;
                case FlexiDialogType.ConfirmField:
                    if (string.IsNullOrEmpty(TextConfirmValue) && string.IsNullOrEmpty(TextConfirmValueRepeat))
                    {
                        popupService.ClosePopup();
                        return;
                    }

                    if (TextConfirmValue != TextConfirmValueRepeat)
                    {
                        Message = "Your entries do not match";
                        return;
                    }

                    vEntryValue = TextConfirmValue;
                    break;
                case FlexiDialogType.ConfirmFieldPassword:
                    if (string.IsNullOrEmpty(PasswordValue) && string.IsNullOrEmpty(PasswordValue))
                    {
                        popupService.ClosePopup();
                        return;
                    }

                    if (PasswordValue != PasswordValue)
                    {
                        Message = "Your entries do not match";
                        return;
                    }

                    vEntryValue = PasswordValue;
                    break;
            }
            [RelayCommand]
            async void OnShare()
            {
                await Share.Default.RequestAsync(new ShareTextRequest
                {
                    Text = ShareText,
                    Title = Title
                });
            }

            /**
             * Validation
             */
            // Check over min length
            if (vEntryValue.Length < MinLength)
            {
                Message = (!string.IsNullOrEmpty(MinLengthMessage) ? MinLengthMessage : $"Entry must be at least {MinLength} characters");
                return;
            }

            // Regex
            if(!string.IsNullOrEmpty(ValidationRegex) && !Regex.IsMatch(vEntryValue, ValidationRegex))
            {
                Message = (!string.IsNullOrEmpty(ValidationRegexMessage) ? ValidationRegexMessage : "The entry does not match the required format");
                return;
            }

            popupService.ClosePopup(vEntryValue);
        }
        bool CanSubmit() => true;

        public async Task OnOpened()
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
            }
        }
    }

    public enum FlexiDialogType
    {
        SingleField,
        ConfirmFieldPassword,
        ConfirmField,
        InfoList
    }
}
