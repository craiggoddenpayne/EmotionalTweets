using Android.App;
using Android.Content.PM;
using Xamarin.Forms.Platform.Android;


namespace EmotionalTweets.Android
{
	[Activity (Label = "Emotional Tweets", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : AndroidActivity
	{
	}
}

