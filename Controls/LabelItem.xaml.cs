using Mads195.MadsMauiLib.ViewModels.Controls;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Mads195.MadsMauiLib.Controls;

public partial class LabelItem : ContentView
{
    public static readonly BindableProperty TextStartProperty =
    BindableProperty.Create(nameof(TextStart), typeof(string), typeof(LabelItem), string.Empty);

    public static readonly BindableProperty TextEndProperty =
    BindableProperty.Create(nameof(TextEnd), typeof(string), typeof(LabelItem), string.Empty);

    public static readonly BindableProperty TapCommandProperty =
        BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(LabelItem));

    public static readonly BindableProperty IconSourceProperty =
        BindableProperty.Create(nameof(IconSource), typeof(string), typeof(LabelItem), string.Empty);

    public static readonly BindableProperty IconHeightProperty =
        BindableProperty.Create(nameof(IconHeight), typeof(int), typeof(LabelItem), 16);

    public static readonly BindableProperty IconWidthProperty =
        BindableProperty.Create(nameof(IconWidth), typeof(int), typeof(LabelItem), 16);

    public string TextStart
    {
        get => (string)GetValue(TextStartProperty);
        set => SetValue(TextStartProperty, value);
    }
    public string TextEnd
    {
        get => (string)GetValue(TextEndProperty);
        set => SetValue(TextEndProperty, value);
    }
    public ICommand TapCommand
    {
        get => (ICommand)GetValue(TapCommandProperty);
        set => SetValue(TapCommandProperty, value);
    }
    public string IconSource
    {
        get => (string)GetValue(IconSourceProperty);
        set => SetValue(IconSourceProperty, value);
    }
    public int IconHeight
    {
        get => (int)GetValue(IconHeightProperty);
        set => SetValue(IconHeightProperty, value);
    }
    public int IconWidth
    {
        get => (int)GetValue(IconWidthProperty);
        set => SetValue(IconWidthProperty, value);
    }
    public LabelItem()
	{
		InitializeComponent();
    }
}