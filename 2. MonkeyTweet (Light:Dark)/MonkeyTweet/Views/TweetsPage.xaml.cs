using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MonkeyTweet
{
	public partial class TweetsPage : ContentPage
	{
		bool isDarkTheme = true;

		public TweetsPage ()
		{
			InitializeComponent ();

			BindingContext = new TweetViewModel ();

			listView.ItemSelected += (sender, e) => {
				listView.SelectedItem = null;
			};
		}

		void OnThemeButtonClicked (object sender, EventArgs e)
		{
			var toolbarItem = (ToolbarItem)sender;
			if (isDarkTheme) {
				toolbarItem.Text = "Light";

				App.Current.Resources ["backgroundColor"] = Color.White;
				App.Current.Resources ["textColor"] = Color.Black;
			} else {
				toolbarItem.Text = "Dark";

				App.Current.Resources ["backgroundColor"] = Color.FromHex ("33302E");
				App.Current.Resources ["textColor"] = Color.White;
			}

			isDarkTheme = !isDarkTheme;
		}

		private TweetViewModel ViewModel
		{
			get { return BindingContext as TweetViewModel; }
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsBusy || ViewModel.Tweets.Count > 0)
				return;

			ViewModel.LoadTweetsCommand.Execute(null);
		}
	}
}

