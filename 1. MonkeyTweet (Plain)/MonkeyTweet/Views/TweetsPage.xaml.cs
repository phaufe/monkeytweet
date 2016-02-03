using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MonkeyTweet
{
	public partial class TweetsPage : ContentPage
	{
		public TweetsPage ()
		{
			InitializeComponent ();

			BindingContext = new TweetViewModel ();

			listView.ItemSelected += (sender, e) => {
				listView.SelectedItem = null;
			};
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

