namespace Mads195.MadsMauiLib.Controls;

public partial class SectionTitle : ContentView
{
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(SectionTitle), string.Empty, propertyChanged: OnTextChanged);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public SectionTitle()
	{
		InitializeComponent();
        BindingContext = this;
    }
    private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is SectionTitle sectionTitle && newValue is string newText)
        {
            sectionTitle.TitleLabel.Text = newText; // Directly update the Label when Text changes
        }
    }
}