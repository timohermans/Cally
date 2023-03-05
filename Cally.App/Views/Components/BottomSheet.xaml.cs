namespace Cally.App.Views.Components;

/// <summary>
/// Based on https://xamarinhowto.com/xamarin-forms-lightweight-bottom-sheet-modal/
/// </summary>
public partial class BottomSheet : ContentView
{
    public double SheetHeight
    {
        get { return (double)GetValue(SheetHeightProperty); }
        set { SetValue(SheetHeightProperty, value); OnPropertyChanged(); }
    }

    public static BindableProperty SheetHeightProperty = BindableProperty.Create(
        nameof(SheetHeight),
        typeof(double),
        typeof(BottomSheet),
        defaultValue: default(double),
        defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty SheetContentProperty = BindableProperty.Create(
            nameof(SheetContent),
            typeof(View),
            typeof(BottomSheet),
            defaultValue: default(View),
            defaultBindingMode: BindingMode.TwoWay);

    public View SheetContent
    {
        get { return (View)GetValue(SheetContentProperty); }
        set { SetValue(SheetContentProperty, value); OnPropertyChanged(); }
    }

    public BottomSheet()
    {
        InitializeComponent();
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        PanContainerRef.Content.TranslationY = SheetHeight + 60;
    }

    uint duration = 250;
    double openPosition = (DeviceInfo.Platform == DevicePlatform.Android) ? 20 : 60;
    double currentPosition = 0;

    private async void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
    {
        switch (e.StatusType)
        {
            case GestureStatus.Running:
                currentPosition = e.TotalY;
                if (e.TotalY > 0)
                {
                    PanContainerRef.Content.TranslationY = openPosition + e.TotalY;
                }
                break;

            case GestureStatus.Completed:
                var threshold = SheetHeight * 0.55;

                if (currentPosition < threshold)
                {
                    await OpenSheet();
                }
                else
                {
                    await CloseSheet();
                }
                break;
        }
    }

    public async Task OpenSheet()
    {
        Backdrop.InputTransparent = BottomSheetRef.InputTransparent = false;

        await Task.WhenAll(
            Backdrop.FadeTo(0.4, length: duration),
            Sheet.TranslateTo(0, openPosition, length: duration, easing: Easing.SinIn)
            );
    }

    public async Task CloseSheet()
    {
        await Task.WhenAll(
            Backdrop.FadeTo(0, length: duration),
            Sheet.TranslateTo(x: 0, y: SheetHeight + 60, length: duration, easing: Easing.SinIn)
            );

        BottomSheetRef.InputTransparent = Backdrop.InputTransparent = true;
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await CloseSheet();
    }

}