using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace EmotionalTweetsAndroid
{
	[Activity (Label = "EmotionalTweetsAndroid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
	    private Button _submit;
	    private ProgressBar _progress;
	    private EditText _searchField;

	    protected override void OnCreate(Bundle bundle)
		{
			RequestWindowFeature(WindowFeatures.NoTitle);
			base.OnCreate(bundle);
		    SetContentView(Resource.Layout.EmotionalTweetsSearch);

            _progress = (ProgressBar)FindViewById(Resource.Id.Progress);
			_searchField = (EditText)FindViewById(Resource.Id.SearchField);
			_submit = (Button)FindViewById(Resource.Id.Submit);

			_progress.Visibility = ViewStates.Invisible; 
		}
	}
}


