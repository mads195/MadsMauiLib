using MadsMauiLib.ViewModels;

namespace MadsMauiLib.Controls;

public partial class SectionTitle : ContentView
{
    public static readonly BindableProperty SectionTitleBackgroundColorProperty =
        BindableProperty.Create(nameof(SectionTitleBackgroundColor),
                                typeof(Color),
                                typeof(SectionTitle),
                                Colors.Transparent,
                                propertyChanged: OnBackgroundColorChanged);

    public Color SectionTitleBackgroundColor
    {
        get => (Color)GetValue(SectionTitleBackgroundColorProperty);
        set => SetValue(SectionTitleBackgroundColorProperty, value);
    }

    public SectionTitle()
    {
        InitializeComponent();
        BindingContext = new SectionTitleViewModel();
    }

    private static void OnBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is SectionTitle control)
        {
            control.BackgroundColor = (Color)newValue;
        }
    }
}