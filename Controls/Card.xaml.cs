using System.Windows.Input;

namespace Mads195.MadsMauiLib.Controls;

public partial class Card : ContentView
{
    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(Card), string.Empty);
    public static readonly BindableProperty CardContentProperty =
        BindableProperty.Create(nameof(CardContent), typeof(string), typeof(Card), string.Empty);
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(Card));
    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(string), typeof(Card), string.Empty);
    public static readonly BindableProperty StrokeColorProperty =
        BindableProperty.Create(nameof(StrokeColor), typeof(Color), typeof(Card), Color.FromArgb("#000000"));
    public static readonly BindableProperty BackgroundColorProperty =
        BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(Card), Color.FromArgb("#ffffff"));
    public static readonly BindableProperty IconSourceProperty =
        BindableProperty.Create(nameof(IconSource), typeof(string), typeof(Card), "mml_pencil_square.png");
    public static readonly BindableProperty ShowEditIconProperty =
        BindableProperty.Create(nameof(ShowEditIcon), typeof(bool), typeof(Card), false);
    public static readonly BindableProperty StrokeThicknessProperty =
        BindableProperty.Create(nameof(StrokeThickness), typeof(int), typeof(Card), 1);
    public static readonly BindableProperty ShowSeparatorProperty =
        BindableProperty.Create(nameof(ShowSeparator), typeof(bool), typeof(Card), false);
    public static readonly BindableProperty TitleFontAttributesProperty =
        BindableProperty.Create(nameof(TitleFontAttributes), typeof(FontAttributes), typeof(Card), FontAttributes.Bold);
    public static readonly BindableProperty ShowTitleProperty =
        BindableProperty.Create(nameof(ShowTitle), typeof(bool), typeof(Card), true);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    public string CardContent
    {
        get => (string)GetValue(CardContentProperty);
        set => SetValue(CardContentProperty, value);
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
    public int StrokeThickness
    {
        get => (int)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
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
    public string IconSource
    {
        get => (string)GetValue(IconSourceProperty);
        set => SetValue(IconSourceProperty, value);
    }
    public bool ShowEditIcon
    {
        get => (bool)GetValue(ShowEditIconProperty);
        set => SetValue(ShowEditIconProperty, value);
    }
    public bool ShowSeparator
    {
        get => (bool)GetValue(ShowSeparatorProperty);
        set => SetValue(ShowSeparatorProperty, value);
    }
    public FontAttributes TitleFontAttributes
    {
        get => (FontAttributes)GetValue(TitleFontAttributesProperty);
        set => SetValue(TitleFontAttributesProperty, value);
    }
    public bool ShowTitle
    {
        get => (bool)GetValue(ShowTitleProperty);
        set => SetValue(ShowTitleProperty, value);
    }

    public Card()
	{
		InitializeComponent();
	}
}