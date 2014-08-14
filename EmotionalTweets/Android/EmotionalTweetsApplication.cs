using System;
using Android.App;
using Android.Runtime;
using EmotionalTweets;

namespace EmotionalTweetsAndroid
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