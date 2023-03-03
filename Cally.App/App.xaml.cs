using Cally.App.Views;

namespace Cally.App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new HomeView();
	}
}
