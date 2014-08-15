using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using EmotionalTweets.DataContracts;
using EmotionalTweets.DataContracts.Sentiment;

namespace EmotionalTweetsAndroid
{
    public class SentimentTweetCollectionAdapter : BaseAdapter<SentimentTweet>
    {

        readonly SentimentTweetCollection _sentimentTweetCollection;

        public SentimentTweetCollectionAdapter(SentimentTweetCollection sentimentTweetCollection)
        {
            _sentimentTweetCollection = sentimentTweetCollection;
        }


            public override SentimentTweet this[int index]
            {
                get
                {
                    return _sentimentTweetCollection[index];
                }
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var context = Application.Context;
                var inflatorservice = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                var sentimentTweet = inflatorservice.Inflate(Resource.Layout.SentimentTweetItem, null);
                
                var tweet = (TextView)sentimentTweet.FindViewById(Resource.Id.tweet);
                var timestamp = (TextView)sentimentTweet.FindViewById(Resource.Id.timestamp);
                var twitterHandle = (TextView)sentimentTweet.FindViewById(Resource.Id.twitterHandle);
                var sentimentText = (TextView)sentimentTweet.FindViewById(Resource.Id.Sentiment);

                var sentimentData = _sentimentTweetCollection[position];
                tweet.Text = sentimentData.Tweet.text;
                timestamp.Text = sentimentData.Tweet.created_at;
                twitterHandle.Text = sentimentData.Tweet.user.screen_name;
                sentimentText.Text = sentimentData.Sentiment.sentiment;

                return sentimentTweet;
            }

            public override int Count { get { return _sentimentTweetCollection.Count; } }
        
    }
}