using Mads195.MadsMauiLib.ViewModels.Controls;
using Microsoft.Maui.Graphics.Text;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Mads195.MadsMauiLib.Controls;
public enum DisplayStyle
{
    Text,
    Badge,
    NoEndText
}
public partial class LabelItem : ContentView
{
    public static readonly BindableProperty TextStartProperty =
        BindableProperty.Create(nameof(TextStart), typeof(string), typeof(LabelItem), string.Empty);
    public static readonly BindableProperty TextStartColorProperty =
        BindableProperty.Create(nameof(TextStartColor), typeof(Color), typeof(LabelItem), Color.FromArgb("#000000"));

    public static readonly BindableProperty TextEndProperty =
        BindableProperty.Create(nameof(TextEnd), typeof(string), typeof(LabelItem), string.Empty);
    public static readonly BindableProperty TextEndColorProperty =
        BindableProperty.Create(nameof(TextEndColor), typeof(Color), typeof(LabelItem), Color.FromArgb("#000000"));

    public static readonly BindableProperty BackgroundColorProperty =
        BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(LabelItem), Color.FromArgb("#ffffff"));

    public static readonly BindableProperty TapCommandProperty =
        BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(LabelItem));

    public static readonly BindableProperty IconSourceProperty =
        BindableProperty.Create(nameof(IconSource), typeof(string), typeof(LabelItem), string.Empty);

    public static readonly BindableProperty IconHeightProperty =
        BindableProperty.Create(nameof(IconHeight), typeof(int), typeof(LabelItem), 16);

    public static readonly BindableProperty IconWidthProperty =
        BindableProperty.Create(nameof(IconWidth), typeof(int), typeof(LabelItem), 16);

    public static readonly BindableProperty TextStartFontAttributesProperty =
        BindableProperty.Create(nameof(TextStartFontAttributes), typeof(FontAttributes), typeof(LabelItem), FontAttributes.Bold);

    public static readonly BindableProperty TextEndFontAttributesProperty =
        BindableProperty.Create(nameof(TextEndFontAttributes), typeof(FontAttributes), typeof(LabelItem), FontAttributes.Bold);

    public static readonly BindableProperty TextEndDisplayStyleProperty =
        BindableProperty.Create(nameof(TextEndDisplayStyle), typeof(DisplayStyle), typeof(LabelItem), DisplayStyle.Text,
            propertyChanged: OnTextEndDisplayStyleChanged);

    public static readonly BindableProperty TextStartFontSizeProperty =
        BindableProperty.Create(nameof(TextStartFontSize), typeof(double), typeof(LabelItem), 12);

    public static readonly BindableProperty TextStartIsVisibleProperty =
        BindableProperty.Create(nameof(TextStartIsVisible), typeof(bool), typeof(LabelItem), true);

    public static readonly BindableProperty TextStartOpacityProperty =
    BindableProperty.Create(nameof(TextStartOpacity), typeof(double), typeof(LabelItem), 1.0);

    public static readonly BindableProperty TextEndFontSizeProperty =
        BindableProperty.Create(nameof(TextEndFontSize), typeof(double), typeof(LabelItem), 12);

    public static readonly BindableProperty TextEndOpacityProperty =
    BindableProperty.Create(nameof(TextEndOpacity), typeof(double), typeof(LabelItem), 1.0);

    public static readonly BindableProperty HighlightColorProperty =
        BindableProperty.Create(nameof(HighlightColor), typeof(Color), typeof(LabelItem), Color.FromArgb("#cccccc"));

    public static readonly BindableProperty InternalPaddingStartProperty =
    BindableProperty.Create(
        nameof(InternalPaddingStart),
        typeof(Thickness),
        typeof(ScreenTitle),
        new Thickness(10, 10, 10, 10));

    public static readonly BindableProperty InternalPaddingEndProperty =
    BindableProperty.Create(
        nameof(InternalPaddingEnd),
        typeof(Thickness),
        typeof(ScreenTitle),
        new Thickness(10, 10, 10, 10));

    public static readonly BindableProperty BadgePaddingProperty =
    BindableProperty.Create(
        nameof(BadgePadding),
        typeof(Thickness),
        typeof(ScreenTitle),
        new Thickness(2, 2, 2, 2));

    public string TextStart
    {
        get => (string)GetValue(TextStartProperty);
        set => SetValue(TextStartProperty, value);
    }
    public Color TextStartColor
    {
        get => (Color)GetValue(TextStartColorProperty);
        set => SetValue(TextStartColorProperty, value);
    }
    public string TextEnd
    {
        get => (string)GetValue(TextEndProperty);
        set => SetValue(TextEndProperty, value);
    }
    public Color TextEndColor
    {
        get => (Color)GetValue(TextEndColorProperty);
        set => SetValue(TextEndColorProperty, value);
    }
    public Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
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
    public FontAttributes TextStartFontAttributes
    {
        get => (FontAttributes)GetValue(TextStartFontAttributesProperty);
        set => SetValue(TextStartFontAttributesProperty, value);
    }
    public FontAttributes TextEndFontAttributes
    {
        get => (FontAttributes)GetValue(TextEndFontAttributesProperty);
        set => SetValue(TextEndFontAttributesProperty, value);
    }
    public DisplayStyle TextEndDisplayStyle
    {
        get => (DisplayStyle)GetValue(TextEndDisplayStyleProperty);
        set => SetValue(TextEndDisplayStyleProperty, value);
    }
    public Color HighlightColor
    {
        get => (Color)GetValue(HighlightColorProperty);
        set => SetValue(HighlightColorProperty, value);
    }
    public double TextStartFontSize
    {
        get => (double)GetValue(TextStartFontSizeProperty);
        set => SetValue(TextStartFontSizeProperty, value);
    }
    public bool TextStartIsVisible
    {
        get => (bool)GetValue(TextStartIsVisibleProperty);
        set => SetValue(TextStartIsVisibleProperty, value);
    }
    public double TextStartOpacity
    {
        get => (double)GetValue(TextStartOpacityProperty);
        set => SetValue(TextStartOpacityProperty, value);
    }
    public double TextEndFontSize
    {
        get => (double)GetValue(TextEndFontSizeProperty);
        set => SetValue(TextEndFontSizeProperty, value);
    }
    public double TextEndOpacity
    {
        get => (double)GetValue(TextEndOpacityProperty);
        set => SetValue(TextEndOpacityProperty, value);
    }
    public Thickness InternalPaddingStart
    {
        get => (Thickness)GetValue(InternalPaddingStartProperty);
        set => SetValue(InternalPaddingStartProperty, value);
    }
    public Thickness InternalPaddingEnd
    {
        get => (Thickness)GetValue(InternalPaddingEndProperty);
        set => SetValue(InternalPaddingEndProperty, value);
    }
    public Thickness BadgePadding
    {
        get => (Thickness)GetValue(BadgePaddingProperty);
        set => SetValue(BadgePaddingProperty, value);
    }
    public LabelItem()
    {
        InitializeComponent();
    }
    
    private static void OnTextEndDisplayStyleChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not LabelItem labelItem)
            return;

        switch (labelItem.TextEndDisplayStyle)
        {
            case DisplayStyle.Text:
                //
                break;
            case DisplayStyle.Badge:
                //
                break;
        }
    }
}