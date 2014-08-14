using System;
using Android.App;
using Android.Runtime;

namespace EmotionalTweets.Android
{
    [Application(Debuggable = true, Label = "Emotional Tweets")]
    public class EmotionalTweetsApplication : Application
    {
        public EmotionalTweetsApplication(IntPtr ptr, JniHandleOwnership ownership)
            : base(ptr, ownership)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Ioc.Register();
        }
    }
}