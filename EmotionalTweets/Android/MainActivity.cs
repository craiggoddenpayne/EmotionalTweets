using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using EmotionalTweets;

namespace EmotionalTweetsAndroid
{
	[Activity (Label = "EmotionalTweetsAndroid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
	    private Button _submit;
	    private ProgressBar _progress;
	    private EditText _searchField;
	    private IEmotionalTweetsController _controller;

	    protected override void OnCreate(Bundle bundle)
		{
			RequestWindowFeature(WindowFeatures.NoTitle);
			base.OnCreate(bundle);
		    SetContentView(Resource.Layout.EmotionalTweetsSearch);
            _controller = Ioc.Resolve<IEmotionalTweetsController>();

            _progress = (ProgressBar)FindViewById(Resource.Id.Progress);
			_searchField = (EditText)FindViewById(Resource.Id.SearchField);
			_submit = (Button)FindViewById(Resource.Id.Submit);

			_progress.Visibility = ViewStates.Invisible; 
            _submit.Click += HandleClick;
		}

	    private async void HandleClick(object sender, EventArgs e)
	    {
	        _progress.Visibility = ViewStates.Visible;
	        _submit.Enabled = false;

            var sentimentTweets = await _controller.SearchTweetsWithSentiment(_searchField.Text);
	        EmotionalTweetsApplication.ApplicationState.LastSearch = sentimentTweets;

	        RunOnUiThread(() =>
	        {
	            _progress.Visibility = ViewStates.Invisible;
	            _submit.Enabled = true;
	        });
	    }
	}
}


