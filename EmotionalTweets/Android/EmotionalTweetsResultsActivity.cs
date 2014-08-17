using System;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using EmotionalTweets;
using EmotionalTweetsShared.DataContracts;
using EmotionalTweetsShared.DataContracts.Sentiment;

namespace EmotionalTweetsAndroid
{
    [Activity(Label = "EmotionalTweets", ScreenOrientation = ScreenOrientation.Portrait)]
    public class EmotionalTweetsResults : Activity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.EmotionalTweetsResults);

            var sentimentTweets = await GetSentimentsAsync();

			var progress = FindViewById<ProgressBar>(Resource.Id.Progress);
			var listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = new SentimentTweetCollectionAdapter(this, sentimentTweets);
            progress.Visibility = ViewStates.Invisible;
        }

        public async Task<SentimentTweetCollection> GetSentimentsAsync()
        {
            try
            {
                var controller = Ioc.Resolve<IEmotionalTweetsController>();
                var tweets = EmotionalTweetsApplication.ApplicationState.LastSearch;
                var getSentimentTasks = tweets.statuses.Select(controller.GetSentiment);
                var sentimentTweets = await Task.WhenAll(getSentimentTasks);
                return new SentimentTweetCollection(sentimentTweets);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                return new SentimentTweetCollection(new SentimentTweet[0]);
            }
        }
    }
}