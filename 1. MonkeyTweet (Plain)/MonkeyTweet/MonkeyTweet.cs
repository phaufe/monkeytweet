using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MonkeyTweet
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			var navigationPage = new NavigationPage (new TweetsPage ()) {
				// BackgroundColor = ""
			};

			MainPage = navigationPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

