using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Views;
using Android.Widget;
using EmotionalTweets;
using EmotionalTweetsShared.DataContracts;

namespace EmotionalTweetsAndroid
{
    [Activity(Label = "EmotionalTweets")]
    public class EmotionalTweetsResults : Activity
    {
        protected override async void OnResume()
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnResume();
            SetContentView(Resource.Layout.EmotionalTweetsResults);

            var sentimentTweets = await GetSentimentsAsync();

            var listView = ((ListView) FindViewById(Resource.Id.listView1));
            listView.Adapter = new SentimentTweetCollectionAdapter(this, sentimentTweets);
        }

        public async Task<SentimentTweetCollection> GetSentimentsAsync()
        {
            var controller = Ioc.Resolve<IEmotionalTweetsController>();
            var tweets = EmotionalTweetsApplication.ApplicationState.LastSearch;
            var getSentimentTasks = tweets.statuses.Select(controller.GetSentiment);
            var sentimentTweets = await Task.WhenAll(getSentimentTasks);
            return new SentimentTweetCollection(sentimentTweets);
        }
    }
}