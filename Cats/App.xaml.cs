using Xamarin.Forms;

namespace Cats
{
	public partial class App : Application
	{
		public App()
		{
			// The root page of your application
			var content = new Cats.Views.CatsPage();

			MainPage = new NavigationPage(content);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
