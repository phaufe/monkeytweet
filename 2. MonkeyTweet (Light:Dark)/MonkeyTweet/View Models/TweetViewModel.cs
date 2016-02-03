using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using LinqToTwitter;
using Xamarin.Forms;

namespace MonkeyTweet
{
	public class TweetViewModel : BaseViewModel
	{
		public ObservableCollection<Tweet> Tweets { get; set; }

		public TweetViewModel ()
		{
			Tweets = new ObservableCollection<Tweet> ();
		}

		private Command loadTweetsCommand;

		public Command LoadTweetsCommand
		{
			get
			{
				return loadTweetsCommand ??
					(loadTweetsCommand = new Command(async () =>
						{
							await ExecuteLoadTweetsCommand();
						}, () =>
						{
							return !IsBusy;
						}));
			}
		}

		async Task ExecuteLoadTweetsCommand ()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			Tweets.Clear ();

			var auth = new ApplicationOnlyAuthorizer
			{
				CredentialStore = new InMemoryCredentialStore
				{
					ConsumerKey = "4a8c7X6NqcBT5GY6nWOX9b32P",
					ConsumerSecret = "QOIvLNS05WfORaQTwvkaxnfH7Rejwi7NgBVUBudtJ0yhiFpCjL",
				},
			};

			await auth.AuthorizeAsync();

			var twitterContext = new TwitterContext(auth);

			var queryResponse = await
				(from tweet in twitterContext.Status
					where tweet.Type == StatusType.User &&
					tweet.ScreenName == "xamarinhq" &&
					tweet.Count == 20 &&
					tweet.IncludeRetweets == true &&
					tweet.ExcludeReplies == true
					select tweet).ToListAsync();

			var tweets =
				(from tweet in queryResponse
					select new Tweet
					{
						Name = tweet.User.Name,
						Time = tweet.CreatedAt,
						Text = tweet.Text,
						AvatarUrl = (tweet.RetweetedStatus != null && tweet.RetweetedStatus.User != null ?
							tweet.RetweetedStatus.User.ProfileImageUrl.Replace("http://", "https://") : tweet.User.ProfileImageUrl.Replace("http://", "https://"))
					}).ToList();
			foreach (var tweet in tweets)
			{
				Tweets.Add(tweet);
			}

			IsBusy = false;
		}
	}
}