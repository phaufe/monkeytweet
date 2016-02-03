using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MonkeyTweet
{
	public partial class StylePage : ContentPage
	{
		public StylePage ()
		{
			InitializeComponent ();
		}

		void OnApplyThemeClicked (object sender, EventArgs e)
		{
			App.Current.Resources ["backgroundColor"] = Color.FromHex (backgroundColorEntry.Text);
			App.Current.Resources ["textColor"] = Color.FromHex (textColorEntry.Text);
		}

		void OnDoneButtonClicked (object sender, EventArgs e)
		{
			Navigation.PopModalAsync ();
		}
	}
}

