using Microsoft.Maui.Graphics.Text;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Mads195.MadsMauiLib.Controls;

public partial class OutlineButton : ContentView
{
    /**
     * Bindable Properties
     */
    public static readonly BindableProperty StrokeThicknessProperty =
        BindableProperty.Create(nameof(StrokeThickness), typeof(int), typeof(OutlineButton), 1);
    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(OutlineButton), 10);
    public static readonly BindableProperty MaximumWidthRequestProperty =
        BindableProperty.Create(nameof(MaximumWidthRequest), typeof(int), typeof(OutlineButton));
    public static readonly BindableProperty StrokeColorProperty =
        BindableProperty.Create(nameof(StrokeColor), typeof(Color), typeof(OutlineButton), Color.FromArgb("#000000"));
    public static readonly BindableProperty BackgroundColorProperty =
        BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(OutlineButton), Color.FromArgb("#000000"));
    public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(OutlineButton));
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(OutlineButton));
    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(string), typeof(OutlineButton), string.Empty);
    /**
     * In-ward Properties
     */
    public int StrokeThickness
    {
        get => (int)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }
    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
    public int MaximumWidthRequest
    {
        get => (int)GetValue(MaximumWidthRequestProperty);
        set => SetValue(MaximumWidthRequestProperty, value);
    }
    public Color StrokeColor
    {
        get => (Color)GetValue(StrokeColorProperty);
        set => SetValue(StrokeColorProperty, value);
    }
    public Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }
    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }
    public OutlineButton()
	{
		InitializeComponent();
	}
}