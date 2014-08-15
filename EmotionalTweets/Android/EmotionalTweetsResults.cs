using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace EmotionalTweetsAndroid
{
    [Activity(Label = "EmotionalTweets")]
    public class EmotionalTweetsResults : Activity
    {
        protected override void OnResume()
        {
            base.OnResume();
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.EmotionalTweetsResults);

            var listView = (ListView)FindViewById(Resource.Id.listView1);
            listView.Adapter = new SentimentTweetCollectionAdapter(EmotionalTweetsApplication.ApplicationState.LastSearch);
        }
    }
}