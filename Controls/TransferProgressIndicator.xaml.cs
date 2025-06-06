namespace Mads195.MadsMauiLib.Controls;

public partial class TransferProgressIndicator : ContentView
{
    public static readonly BindableProperty TransferImageWidthProperty =
        BindableProperty.Create(nameof(TransferImageWidth), typeof(int), typeof(TransferProgressIndicator), 30);
    public static readonly BindableProperty TransferBarHeightProperty =
        BindableProperty.Create(nameof(TransferBarHeight), typeof(int), typeof(TransferProgressIndicator), 30);
    public static readonly BindableProperty TransferImageLProperty =
        BindableProperty.Create(nameof(TransferImageL), typeof(string), typeof(IndeterminateProgressBar), "mml_box.png");
    public static readonly BindableProperty TransferImageRProperty =
        BindableProperty.Create(nameof(TransferImageR), typeof(string), typeof(IndeterminateProgressBar), "mml_box_fill.png");

    public int TransferImageWidth
    {
        get => (int)GetValue(TransferImageWidthProperty);
        set => SetValue(TransferImageWidthProperty, value);
    }
    public int TransferBarHeight
    {
        get => (int)GetValue(TransferBarHeightProperty);
        set => SetValue(TransferBarHeightProperty, value);
    }
    public string TransferImageL
    {
        get => (string)GetValue(TransferImageLProperty);
        set => SetValue(TransferImageLProperty, value);
    }
    public string TransferImageR
    {
        get => (string)GetValue(TransferImageRProperty);
        set => SetValue(TransferImageRProperty, value);
    }

    public TransferProgressIndicator()
	{
		InitializeComponent();
	}
}