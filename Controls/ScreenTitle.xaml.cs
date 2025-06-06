using Microsoft.Maui.Controls.Shapes;
using System.Windows.Input;

namespace Mads195.MadsMauiLib.Controls;

public partial class ScreenTitle : ContentView
{
    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(ScreenTitle), string.Empty);
    public static readonly BindableProperty BylineProperty =
        BindableProperty.Create(nameof(Byline), typeof(string), typeof(ScreenTitle), string.Empty);
    public static readonly BindableProperty ImageWidthProperty =
        BindableProperty.Create(nameof(ImageWidth), typeof(int), typeof(ScreenTitle), 35);
    public static readonly BindableProperty ImageHeightProperty =
        BindableProperty.Create(nameof(ImageHeight), typeof(int), typeof(ScreenTitle), 35);
    public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(ScreenTitle), "mml_two_dots_vertical.png");
    public static readonly BindableProperty ImageAspectProperty =
        BindableProperty.Create(nameof(ImageAspect), typeof(Aspect), typeof(ScreenTitle), Aspect.Fill);
    public static readonly BindableProperty TitleTextColorProperty =
        BindableProperty.Create(nameof(TitleTextColor), typeof(Color), typeof(ScreenTitle), Color.FromArgb("#000000"));
    public static readonly BindableProperty TitleFontSizeProperty =
        BindableProperty.Create(nameof(TitleFontSize), typeof(int), typeof(ScreenTitle), 14);
    public static readonly BindableProperty TitleFontAttributesProperty =
        BindableProperty.Create(nameof(TitleFontAttributes), typeof(FontAttributes), typeof(ScreenTitle), FontAttributes.Bold);
    public static readonly BindableProperty BylineTextColorProperty =
        BindableProperty.Create(nameof(BylineTextColor), typeof(Color), typeof(ScreenTitle), Color.FromArgb("#000000"));
    public static readonly BindableProperty BylineFontSizeProperty =
        BindableProperty.Create(nameof(BylineFontSize), typeof(int), typeof(ScreenTitle), 12);
    public static readonly BindableProperty BylineFontAttributesProperty =
        BindableProperty.Create(nameof(BylineFontAttributes), typeof(FontAttributes), typeof(ScreenTitle), FontAttributes.Bold);
    public static readonly BindableProperty ImageCommandProperty =
        BindableProperty.Create(nameof(ImageCommand), typeof(ICommand), typeof(ScreenTitle));
    public static readonly BindableProperty ImageCommandParameterProperty =
        BindableProperty.Create(nameof(ImageCommandParameter), typeof(string), typeof(ScreenTitle), string.Empty);
    public static readonly BindableProperty TitleCommandProperty =
        BindableProperty.Create(nameof(TitleCommand), typeof(ICommand), typeof(ScreenTitle));
    public static readonly BindableProperty TitleCommandParameterProperty =
        BindableProperty.Create(nameof(TitleCommandParameter), typeof(string), typeof(ScreenTitle), string.Empty);
    public static readonly BindableProperty ImageColumnWidthProperty =
        BindableProperty.Create(nameof(ImageColumnWidth), typeof(int), typeof(ScreenTitle), 60);
    public static readonly BindableProperty PaddingProperty =
        BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(ScreenTitle), new Thickness(20, 20));
    public static readonly BindableProperty BackgroundColorProperty =
        BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(ScreenTitle), Color.FromArgb("#ffffff"));
    public static readonly BindableProperty EndImageSourceProperty =
        BindableProperty.Create(nameof(EndImageSource), typeof(string), typeof(ScreenTitle), "mml_chevron_right.png");
    public static readonly BindableProperty EndImageCommandProperty =
        BindableProperty.Create(nameof(EndImageCommand), typeof(ICommand), typeof(ScreenTitle));
    public static readonly BindableProperty EndImageCommandParameterProperty =
        BindableProperty.Create(nameof(EndImageCommandParameter), typeof(string), typeof(ScreenTitle), string.Empty);
    public static readonly BindableProperty EndImageWidthProperty =
        BindableProperty.Create(nameof(EndImageWidth), typeof(int), typeof(ScreenTitle), 24);
    public static readonly BindableProperty EndImageHeightProperty =
        BindableProperty.Create(nameof(EndImageHeight), typeof(int), typeof(ScreenTitle), 24);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    public string Byline
    {
        get => (string)GetValue(BylineProperty);
        set => SetValue(BylineProperty, value);
    }
    public int ImageWidth
    {
        get => (int)GetValue(ImageWidthProperty);
        set => SetValue(ImageWidthProperty, value);
    }
    public int ImageHeight
    {
        get => (int)GetValue(ImageHeightProperty);
        set => SetValue(ImageHeightProperty, value);
    }
    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }
    public Aspect ImageAspect
    {
        get => (Aspect)GetValue(ImageAspectProperty);
        set => SetValue(ImageAspectProperty, value);
    }
    public Color TitleTextColor
    {
        get => (Color)GetValue(TitleTextColorProperty);
        set => SetValue(TitleTextColorProperty, value);
    }
    public int TitleFontSize
    {
        get => (int)GetValue(TitleFontSizeProperty);
        set => SetValue(TitleFontSizeProperty, value);
    }
    public FontAttributes TitleFontAttributes
    {
        get => (FontAttributes)GetValue(TitleFontAttributesProperty);
        set => SetValue(TitleFontAttributesProperty, value);
    }
    public Color BylineTextColor
    {
        get => (Color)GetValue(BylineTextColorProperty);
        set => SetValue(BylineTextColorProperty, value);
    }
    public int BylineFontSize
    {
        get => (int)GetValue(BylineFontSizeProperty);
        set => SetValue(BylineFontSizeProperty, value);
    }
    public FontAttributes BylineFontAttributes
    {
        get => (FontAttributes)GetValue(BylineFontAttributesProperty);
        set => SetValue(BylineFontAttributesProperty, value);
    }
    public ICommand ImageCommand
    {
        get => (ICommand)GetValue(ImageCommandProperty);
        set => SetValue(ImageCommandProperty, value);
    }
    public string ImageCommandParameter
    {
        get => (string)GetValue(ImageCommandParameterProperty);
        set => SetValue(ImageCommandParameterProperty, value);
    }
    public ICommand TitleCommand
    {
        get => (ICommand)GetValue(TitleCommandProperty);
        set => SetValue(TitleCommandProperty, value);
    }
    public string TitleCommandParameter
    {
        get => (string)GetValue(TitleCommandParameterProperty);
        set => SetValue(TitleCommandParameterProperty, value);
    }
    public int ImageColumnWidth
    {
        get => (int)GetValue(ImageColumnWidthProperty);
        set => SetValue(ImageColumnWidthProperty, value);
    }
    public Thickness Padding
    {
        get => (Thickness)GetValue(PaddingProperty);
        set => SetValue(PaddingProperty, value);
    }
    public Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }
    public string EndImageSource
    {
        get => (string)GetValue(EndImageSourceProperty);
        set => SetValue(EndImageSourceProperty, value);
    }
    public ICommand EndImageCommand
    {
        get => (ICommand)GetValue(EndImageCommandProperty);
        set => SetValue(EndImageCommandProperty, value);
    }
    public string EndImageCommandParameter
    {
        get => (string)GetValue(EndImageCommandParameterProperty);
        set => SetValue(EndImageCommandParameterProperty, value);
    }
    public int EndImageWidth
    {
        get => (int)GetValue(EndImageWidthProperty);
        set => SetValue(EndImageWidthProperty, value);
    }
    public int EndImageHeight
    {
        get => (int)GetValue(EndImageHeightProperty);
        set => SetValue(EndImageHeightProperty, value);
    }
    public ScreenTitle()
	{
		InitializeComponent();
	}
}