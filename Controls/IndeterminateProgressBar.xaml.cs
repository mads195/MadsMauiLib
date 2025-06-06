using Microsoft.Maui.Controls.Shapes;

namespace Mads195.MadsMauiLib.Controls;

public enum ProgressSpeeds
{
    Slow,
    Medium,
    Fast
}
public partial class IndeterminateProgressBar : ContentView
{
    public static readonly BindableProperty BackgroundColorProperty =
        BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(IndeterminateProgressBar), Color.FromArgb("#ffffff"));
    public static readonly BindableProperty IndicatorColorProperty =
        BindableProperty.Create(nameof(IndicatorColor), typeof(Color), typeof(IndeterminateProgressBar), Color.FromArgb("#ffffff"));
    public static readonly BindableProperty HeightRequestProperty =
        BindableProperty.Create(nameof(HeightRequest), typeof(int), typeof(IndeterminateProgressBar), 10);
    public static readonly BindableProperty IndicatorWidthProperty =
        BindableProperty.Create(nameof(IndicatorWidth), typeof(int), typeof(IndeterminateProgressBar), 100);
    public static readonly BindableProperty StrokeShapeProperty =
        BindableProperty.Create(nameof(StrokeShape), typeof(IShape), typeof(IndeterminateProgressBar), new RoundRectangle { CornerRadius = new CornerRadius(5) });
    public static readonly BindableProperty IndicatorImageProperty =
        BindableProperty.Create(nameof(IndicatorImage), typeof(string), typeof(IndeterminateProgressBar), "mml_chevron_right.png");
    public static readonly BindableProperty ProgressSpeedProperty =
        BindableProperty.Create(nameof(ProgressSpeed), typeof(ProgressSpeeds), typeof(IndeterminateProgressBar), ProgressSpeeds.Medium);

    public Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }
    public Color IndicatorColor
    {
        get => (Color)GetValue(IndicatorColorProperty);
        set => SetValue(IndicatorColorProperty, value);
    }
    public int HeightRequest
    {
        get => (int)GetValue(HeightRequestProperty);
        set => SetValue(HeightRequestProperty, value);
    }
    public int IndicatorWidth
    {
        get => (int)GetValue(IndicatorWidthProperty);
        set => SetValue(IndicatorWidthProperty, value);
    }
    public IShape StrokeShape
    {
        get => (IShape)GetValue(StrokeShapeProperty);
        set => SetValue(StrokeShapeProperty, value);
    }
    public string IndicatorImage
    {
        get => (string)GetValue(IndicatorImageProperty);
        set => SetValue(IndicatorImageProperty, value);
    }
    public ProgressSpeeds ProgressSpeed
    {
        get => (ProgressSpeeds)GetValue(ProgressSpeedProperty);
        set => SetValue(ProgressSpeedProperty, value);
    }
    private bool _isAnimating = false;

    public IndeterminateProgressBar()
    {
        InitializeComponent();
    }

    protected override void OnParentSet()
    {
        base.OnParentSet();
        StartAnimation();
    }

    public void StartAnimation()
    {
        if (_isAnimating)
            return;

        _isAnimating = true;
        _ = AnimateBarAsync();
    }

    public void StopAnimation()
    {
        _isAnimating = false;
    }

    private async Task AnimateBarAsync()
    {
        uint iProgressSpeed = 1000;
        switch (ProgressSpeed)
        {
            case ProgressSpeeds.Slow:
                iProgressSpeed = 500;
                break;
            case ProgressSpeeds.Fast:
                iProgressSpeed = 2000;
                break;
        }

        while (_isAnimating)
        {
            ProgressBarIndicator.TranslationX = -ProgressBarIndicator.Width;

            await ProgressBarIndicator.TranslateTo(ProgressBarContainer.Width, 0, iProgressSpeed, Easing.Linear);

            await Task.Delay(200); // brief pause between cycles
        }
    }
}