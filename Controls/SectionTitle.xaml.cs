namespace Mads195.MadsMauiLib.Controls;

public partial class SectionTitle : ContentView
{
    /**
     * Bindable Properties
     */
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(SectionTitle), string.Empty);
    public static readonly BindableProperty PaddingProperty =
        BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(SectionTitle), new Thickness(0, 0, 0, 0));
    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(SectionTitle), Color.FromArgb("#000000"));
    public static readonly BindableProperty FontAttributesProperty =
        BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(SectionTitle), FontAttributes.None);
    public static readonly BindableProperty BackgroundColorProperty =
        BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(SectionTitle), Color.FromArgb("#FFFFFF"));

    public static readonly BindableProperty HorizontalOptionsProperty =
        BindableProperty.Create(nameof(HorizontalOptions), typeof(LayoutOptions), typeof(SectionTitle), LayoutOptions.Start);
    public static readonly BindableProperty VerticalOptionsProperty =
        BindableProperty.Create(nameof(VerticalOptions), typeof(LayoutOptions), typeof(SectionTitle), LayoutOptions.Center);

    public static readonly BindableProperty HorizontalTextProperty =
        BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(SectionTitle), TextAlignment.Start);
    public static readonly BindableProperty VerticalTextProperty =
        BindableProperty.Create(nameof(VerticalTextAlignment), typeof(TextAlignment), typeof(SectionTitle), TextAlignment.Center);

    /**
     * In-ward Properties
     */
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }
    public Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }
    public Thickness Padding
    {
        get => (Thickness)GetValue(PaddingProperty);
        set => SetValue(PaddingProperty, value);
    }
    public FontAttributes FontAttributes
    {
        get => (FontAttributes)GetValue(FontAttributesProperty);
        set => SetValue(FontAttributesProperty, value);
    }
    public LayoutOptions HorizontalOptions
    {
        get => (LayoutOptions)GetValue(HorizontalOptionsProperty);
        set => SetValue(HorizontalOptionsProperty, value);
    }
    public LayoutOptions VerticalOptions
    {
        get => (LayoutOptions)GetValue(VerticalOptionsProperty);
        set => SetValue(VerticalOptionsProperty, value);
    }
    public TextAlignment HorizontalTextAlignment
    {
        get => (TextAlignment)GetValue(HorizontalTextProperty);
        set => SetValue(HorizontalTextProperty, value);
    }
    public TextAlignment VerticalTextAlignment
    {
        get => (TextAlignment)GetValue(VerticalTextProperty);
        set => SetValue(VerticalTextProperty, value);
    }

    /**
     * Constructor
     */
    public SectionTitle()
	{
		InitializeComponent();
    }
}