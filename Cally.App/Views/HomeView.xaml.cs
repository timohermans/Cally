namespace Cally.App.Views;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Sheet.OpenSheet();
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Sheet.CloseSheet();
    }
}