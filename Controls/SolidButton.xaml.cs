using System.Windows.Input;

namespace Mads195.MadsMauiLib.Controls;

public enum ButtonShapeType
{
    Rectangular,
    Square,
    Circle
}

public partial class SolidButton : ContentView
{
    /**
     * Bindable Properties
     */
    public static readonly BindableProperty StrokeThicknessProperty =
        BindableProperty.Create(nameof(StrokeThickness), typeof(int), typeof(SolidButton), 1);

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(SolidButton), 10,
            propertyChanged: OnButtonShapeChanged);

    public static readonly BindableProperty MaximumWidthRequestProperty =
        BindableProperty.Create(nameof(MaximumWidthRequest), typeof(int), typeof(SolidButton));

    public static readonly BindableProperty StrokeColorProperty =
        BindableProperty.Create(nameof(StrokeColor), typeof(Color), typeof(SolidButton), Color.FromArgb("#000000"));

    public static readonly BindableProperty BackgroundColorProperty =
        BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(SolidButton), Color.FromArgb("#000000"));

    public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(SolidButton));
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(SolidButton));
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(SolidButton));

    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(string), typeof(SolidButton), string.Empty);

    public static readonly BindableProperty ButtonShapeProperty =
        BindableProperty.Create(nameof(ButtonShape), typeof(ButtonShapeType), typeof(SolidButton), ButtonShapeType.Rectangular,
            propertyChanged: OnButtonShapeChanged);

    public static readonly BindableProperty WidthRequestProperty =
        BindableProperty.Create(nameof(WidthRequest), typeof(double), typeof(SolidButton), -1.0,
            propertyChanged: OnButtonShapeChanged);

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
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
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

    public ButtonShapeType ButtonShape
    {
        get => (ButtonShapeType)GetValue(ButtonShapeProperty);
        set => SetValue(ButtonShapeProperty, value);
    }

    public double WidthRequest
    {
        get => (double)GetValue(WidthRequestProperty);
        set => SetValue(WidthRequestProperty, value);
    }

    public SolidButton()
    {
        InitializeComponent();
    }

    private static void OnButtonShapeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not SolidButton button)
            return;

        switch (button.ButtonShape)
        {
            case ButtonShapeType.Rectangular:
                button.HeightRequest = -1;
                break;
            case ButtonShapeType.Square:
                button.HeightRequest = button.WidthRequest;
                break;
            case ButtonShapeType.Circle:
                button.HeightRequest = button.WidthRequest;
                button.CornerRadius = (int)(button.WidthRequest / 2);
                break;
        }
    }
}
