using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
        string buttonCancelText = "";
        [ObservableProperty]
        string buttonSubmitText = "";
        [ObservableProperty]
        Keyboard keyboard = Keyboard.Default;
        [ObservableProperty]
        FlexiDialogType dialogType = FlexiDialogType.SingleField;
        /**
         * Bindable Properties - Private
         */
        [ObservableProperty]
        private string message = "";
        [ObservableProperty]
        private string password = "";
        [ObservableProperty]
        private string confirmPassword = "";

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

        [RelayCommand(CanExecute = nameof(CanSubmit))]
        void OnSubmit()
        {
            switch(DialogType)
            {
                case FlexiDialogType.SingleField:
                    popupService.ClosePopup(Title);
                    break;
                case FlexiDialogType.ConfirmField:
                    popupService.ClosePopup(Title);
                    break;
                case FlexiDialogType.ConfirmFieldPassword:
                    popupService.ClosePopup(Password);
                    break;
            }
        }

        bool CanSubmit() => string.IsNullOrWhiteSpace(Title) is false;
        bool CanCancel() => true;
    }

    public enum FlexiDialogType
    {
        SingleField,
        ConfirmFieldPassword,
        ConfirmField
    }
}
