namespace Mads195.MadsMauiLib.Controls;

public partial class SectionTitle : ContentView
{
    /**
     * Bindable Properties
     */
    public static readonly BindableProperty oTextPropertyZ =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(SectionTitle), string.Empty, propertyChanged: OnTextChanged);
    public static readonly BindableProperty oPaddingPropertyZ =
        BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(SectionTitle), new Thickness(0, 0, 0, 0), propertyChanged: OnPaddingChanged);
    public static readonly BindableProperty oTextColorPropertyZ =
        BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(SectionTitle), Color.FromArgb("#000000"), propertyChanged: OnTextColorChanged);
    public static readonly BindableProperty oFontAttributesPropertyZ =
        BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(SectionTitle), FontAttributes.None, propertyChanged: OnFontAttributesChanged);
    public static readonly BindableProperty oBackgroundColorPropertyZ =
        BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(SectionTitle), Color.FromArgb("#FFFFFF"), propertyChanged: OnBackgroundColorChanged);

    public static readonly BindableProperty oHorizontalOptionsPropertyZ =
        BindableProperty.Create(nameof(HorizontalOptions), typeof(LayoutOptions), typeof(SectionTitle), LayoutOptions.Start, propertyChanged: OnHorizontalOptionsChanged);
    public static readonly BindableProperty oVerticalOptionsPropertyZ =
        BindableProperty.Create(nameof(VerticalOptions), typeof(LayoutOptions), typeof(SectionTitle), LayoutOptions.Center, propertyChanged: OnVerticalOptionsChanged);

    public static readonly BindableProperty oHorizontalTextPropertyZ =
        BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(SectionTitle), TextAlignment.Start, propertyChanged: OnHorizontalTextChanged);
    public static readonly BindableProperty oVerticalTextPropertyZ =
        BindableProperty.Create(nameof(VerticalTextAlignment), typeof(TextAlignment), typeof(SectionTitle), TextAlignment.Center, propertyChanged: OnVerticalTextChanged);

    /**
     * In-ward Properties
     */
    public string Text
    {
        get => (string)GetValue(oTextPropertyZ);
        set => SetValue(oTextPropertyZ, value);
    }
    public Color TextColor
    {
        get => (Color)GetValue(oTextColorPropertyZ);
        set => SetValue(oTextColorPropertyZ, value);
    }
    public Color BackgroundColor
    {
        get => (Color)GetValue(oBackgroundColorPropertyZ);
        set => SetValue(oBackgroundColorPropertyZ, value);
    }
    public Thickness Padding
    {
        get => (Thickness)GetValue(oPaddingPropertyZ);
        set => SetValue(oPaddingPropertyZ, value);
    }
    public FontAttributes FontAttributes
    {
        get => (FontAttributes)GetValue(oFontAttributesPropertyZ);
        set => SetValue(oFontAttributesPropertyZ, value);
    }
    public LayoutOptions HorizontalOptions
    {
        get => (LayoutOptions)GetValue(oHorizontalOptionsPropertyZ);
        set => SetValue(oHorizontalOptionsPropertyZ, value);
    }
    public LayoutOptions VerticalOptions
    {
        get => (LayoutOptions)GetValue(oVerticalOptionsPropertyZ);
        set => SetValue(oVerticalOptionsPropertyZ, value);
    }
    public TextAlignment HorizontalTextAlignment
    {
        get => (TextAlignment)GetValue(oHorizontalTextPropertyZ);
        set => SetValue(oHorizontalTextPropertyZ, value);
    }
    public TextAlignment VerticalTextAlignment
    {
        get => (TextAlignment)GetValue(oVerticalTextPropertyZ);
        set => SetValue(oVerticalTextPropertyZ, value);
    }

    /**
     * Constructor
     */
    public SectionTitle()
	{
		InitializeComponent();
        BindingContext = this;
    }
    /**
     * Event Handlers
     */
    private static void OnTextColorChanged(BindableObject oBindableZ, object oOldValueZ, object oNewValueZ)
    {
        if (oBindableZ is SectionTitle sectionTitle && oNewValueZ is Color oNewColorZ)
        {
            sectionTitle.TitleLabel.TextColor = oNewColorZ;
        }
    }
    private static void OnBackgroundColorChanged(BindableObject oBindableZ, object oOldValueZ, object oNewValueZ)
    {
        if (oBindableZ is SectionTitle sectionTitle && oNewValueZ is Color oNewBackgroundColorZ)
        {
            sectionTitle.BackgroundColor = oNewBackgroundColorZ;
        }
    }
    private static void OnTextChanged(BindableObject oBindableZ, object oOldValueZ, object oNewValueZ)
    {
        if (oBindableZ is SectionTitle sectionTitle && oNewValueZ is string oNewTextZ)
        {
            sectionTitle.TitleLabel.Text = oNewTextZ;
        }
    }
    private static void OnFontAttributesChanged(BindableObject oBindableZ, object oOldValueZ, object oNewValueZ)
    {
        if (oBindableZ is SectionTitle sectionTitle && oNewValueZ is FontAttributes oNewAttributesZ)
        {
            sectionTitle.TitleLabel.FontAttributes = oNewAttributesZ;
        }
    }
    private static void OnPaddingChanged(BindableObject oBindableZ, object oOldValueZ, object oNewValueZ)
    {
        if (oBindableZ is SectionTitle sectionTitle && oNewValueZ is Thickness oNewPaddingZ)
        {
            sectionTitle.TitleLabelPadding.Padding = oNewPaddingZ;
        }
    }
    private static void OnHorizontalOptionsChanged(BindableObject oBindableZ, object oOldValueZ, object oNewValueZ)
    {
        if (oBindableZ is SectionTitle sectionTitle && oNewValueZ is LayoutOptions oNewLayoutZ)
        {
            sectionTitle.TitleLabel.HorizontalOptions = oNewLayoutZ;
        }
    }
    private static void OnVerticalOptionsChanged(BindableObject oBindableZ, object oOldValueZ, object oNewValueZ)
    {
        if (oBindableZ is SectionTitle sectionTitle && oNewValueZ is LayoutOptions oNewLayoutZ)
        {
            sectionTitle.TitleLabel.VerticalOptions = oNewLayoutZ;
        }
    }
    private static void OnHorizontalTextChanged(BindableObject oBindableZ, object oOldValueZ, object oNewValueZ)
    {
        if (oBindableZ is SectionTitle sectionTitle && oNewValueZ is TextAlignment oNewAlignmentZ)
        {
            sectionTitle.TitleLabel.HorizontalTextAlignment = oNewAlignmentZ;
        }
    }
    private static void OnVerticalTextChanged(BindableObject oBindableZ, object oOldValueZ, object oNewValueZ)
    {
        if (oBindableZ is SectionTitle sectionTitle && oNewValueZ is TextAlignment oNewAlignmentZ)
        {
            sectionTitle.TitleLabel.VerticalTextAlignment = oNewAlignmentZ;
        }
    }
}