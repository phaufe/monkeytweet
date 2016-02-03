using System;
using Humanizer;

namespace MonkeyTweet
{
	public class Tweet
	{
		public string AvatarUrl { get; set; }
		public string Name { get; set; }
		public DateTime Time { get; set; }
		public string Text { get; set; }
	}
}