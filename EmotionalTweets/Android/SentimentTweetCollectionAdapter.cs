using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using EmotionalTweets;
using EmotionalTweetsAndroid.Helpers;
using EmotionalTweetsShared.DataContracts.Sentiment;

namespace EmotionalTweetsAndroid
{
    public class SentimentTweetCollectionAdapter : BaseAdapter<SentimentTweet>
    {
        private readonly Activity _context;
        private readonly IEnumerable<SentimentTweet> _sentimentTweets;
        private readonly IEmoticonResourceFinder _emoticonResourceFinder;
        private readonly IDateTimeParser _dateTimeParser;

        public SentimentTweetCollectionAdapter(Activity context,
            IEnumerable<SentimentTweet> sentimentTweets)
        {
            _context = context;
            _sentimentTweets = sentimentTweets;
            _emoticonResourceFinder = Ioc.Resolve<IEmoticonResourceFinder>();
            _dateTimeParser = Ioc.Resolve<IDateTimeParser>();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var sentimentTweet = convertView ??
                                 _context.LayoutInflater.Inflate(Resource.Layout.SentimentTweetItem, null);

            var tweet = sentimentTweet.FindViewById<TextView>(Resource.Id.tweet);
            var timestamp = sentimentTweet.FindViewById<TextView>(Resource.Id.timestamp);
            var twitterHandle = sentimentTweet.FindViewById<TextView>(Resource.Id.twitterHandle);
            var emoticon = sentimentTweet.FindViewById<ImageView>(Resource.Id.Emoticon);
            var sentimentTweetData = _sentimentTweets.ElementAt(position);
            tweet.Text = sentimentTweetData.Tweet.text;
            timestamp.Text = _dateTimeParser.GetTimeSince(sentimentTweetData.Tweet.created_at);
            twitterHandle.Text = "@" + sentimentTweetData.Tweet.user.screen_name;
            emoticon.SetImageResource(_emoticonResourceFinder.FindEmoticonForSentiment(sentimentTweetData.Sentiment));
            return sentimentTweet;
        }

        public override int Count
        {
            get { return _sentimentTweets.Count(); }
        }

        public override SentimentTweet this[int position]
        {
            get { return _sentimentTweets.ElementAt(position); }
        }
    }
}