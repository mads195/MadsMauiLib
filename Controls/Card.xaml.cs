using Microsoft.Maui;
using System.ComponentModel;
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
    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(Card), Color.FromArgb("#000000"));
    public static readonly BindableProperty TitleBackgroundColorProperty =
        BindableProperty.Create(nameof(TitleBackgroundColor), typeof(Color), typeof(Card), Color.FromArgb("#ffffff"));
    public static readonly BindableProperty ContentBackgroundColorProperty =
        BindableProperty.Create(nameof(ContentBackgroundColor), typeof(Color), typeof(Card), Color.FromArgb("#ffffff"));
    public static readonly BindableProperty TitleTextColorProperty =
        BindableProperty.Create(nameof(TitleTextColor), typeof(Color), typeof(Card), Color.FromArgb("#000000"));
    public static readonly BindableProperty ContentTextColorProperty =
        BindableProperty.Create(nameof(ContentTextColor), typeof(Color), typeof(Card), Color.FromArgb("#000000"));
    public static readonly BindableProperty EditIconProperty =
        BindableProperty.Create(nameof(EditIcon), typeof(string), typeof(Card), "mml_pencil_square.png");
    public static readonly BindableProperty ShowEditIconProperty =
        BindableProperty.Create(nameof(ShowEditIcon), typeof(bool), typeof(Card), false);
    public static readonly BindableProperty BorderThicknessProperty =
        BindableProperty.Create(nameof(BorderThickness), typeof(int), typeof(Card), 1);
    public static readonly BindableProperty ShowSeparatorProperty =
        BindableProperty.Create(nameof(ShowSeparator), typeof(bool), typeof(Card), false);
    public static readonly BindableProperty TitleFontAttributesProperty =
        BindableProperty.Create(nameof(TitleFontAttributes), typeof(FontAttributes), typeof(Card), FontAttributes.Bold);
    public static readonly BindableProperty ShowTitleProperty =
        BindableProperty.Create(nameof(ShowTitle), typeof(bool), typeof(Card), true);
    public static readonly BindableProperty BorderRadiusProperty =
        BindableProperty.Create(nameof(BorderRadius), typeof(int), typeof(Card), 15);
    public static readonly BindableProperty InnerContentProperty =
        BindableProperty.Create(nameof(InnerContent), typeof(View), typeof(Card), propertyChanged: OnInnerContentChanged);
    public static readonly BindableProperty ShowCardContentProperty =
        BindableProperty.Create(nameof(ShowCardContent), typeof(bool), typeof(Card), true);
    public static readonly BindableProperty UseAlternateBorderColorProperty =
    BindableProperty.Create(nameof(UseAlternateBorderColor), typeof(bool), typeof(Card), false, propertyChanged: OnBorderColorTriggerChanged);
    public static readonly BindableProperty AlternateBorderColorProperty =
        BindableProperty.Create(nameof(AlternateBorderColor), typeof(Color), typeof(Card), Colors.Red, propertyChanged: OnBorderColorTriggerChanged);


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
    public int BorderThickness
    {
        get => (int)GetValue(BorderThicknessProperty);
        set => SetValue(BorderThicknessProperty, value);
    }
    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }
    public int BorderRadius
    {
        get => (int)GetValue(BorderRadiusProperty);
        set => SetValue(BorderRadiusProperty, value);
    }
    public Color TitleBackgroundColor
    {
        get => (Color)GetValue(TitleBackgroundColorProperty);
        set => SetValue(TitleBackgroundColorProperty, value);
    }
    public Color ContentBackgroundColor
    {
        get => (Color)GetValue(ContentBackgroundColorProperty);
        set => SetValue(ContentBackgroundColorProperty, value);
    }
    public Color TitleTextColor
    {
        get => (Color)GetValue(TitleTextColorProperty);
        set => SetValue(TitleTextColorProperty, value);
    }
    public Color ContentTextColor
    {
        get => (Color)GetValue(ContentTextColorProperty);
        set => SetValue(ContentTextColorProperty, value);
    }
    public string EditIcon
    {
        get => (string)GetValue(EditIconProperty);
        set => SetValue(EditIconProperty, value);
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
    public View InnerContent
    {
        get => (View)GetValue(InnerContentProperty);
        set => SetValue(InnerContentProperty, value);
    }
    public bool ShowCardContent
    {
        get => (bool)GetValue(ShowCardContentProperty);
        set => SetValue(ShowCardContentProperty, value);
    }
    public bool UseAlternateBorderColor
    {
        get => (bool)GetValue(UseAlternateBorderColorProperty);
        set => SetValue(UseAlternateBorderColorProperty, value);
    }
    public Color AlternateBorderColor
    {
        get => (Color)GetValue(AlternateBorderColorProperty);
        set => SetValue(AlternateBorderColorProperty, value);
    }

    public Card()
	{
		InitializeComponent();

        BindingContextChanged += (s, e) =>
        {
            if (InnerContent != null)
                InnerContent.BindingContext = BindingContext;
        };
    }

    protected override void OnParentSet()
    {
        base.OnParentSet();

        if (InnerContent != null)
        {
            InnerContent.BindingContext = BindingContext;
        }
    }
    private static void OnInnerContentChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is Card card)
        {
            if (card.ContentPlaceholder == null)
                return;

            if (newValue is View newView)
            {
                card.ContentPlaceholder.Content = newView;

                // Important: forward BindingContext
                newView.BindingContext = card.BindingContext;
            }
            else
            {
                card.ContentPlaceholder.Content = null;
            }
        }
    }
    private static void OnBorderColorTriggerChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is Card card)
        {
            card.OnPropertyChanged(nameof(EffectiveBorderColor));
        }
    }
    public Color EffectiveBorderColor => UseAlternateBorderColor ? AlternateBorderColor : BorderColor;
}