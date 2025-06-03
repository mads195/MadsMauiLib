using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mads195.MadsMauiLib.ViewModels.Controls
{
    public partial class LabelItemViewModel : ObservableObject
    {
        public LabelItemViewModel()
        {
            // Default constructor for ViewModel
        }
    }

    public enum DisplayStyle
    {
        Text,
        Badge
    }
}
