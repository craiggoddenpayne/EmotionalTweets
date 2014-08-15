using System;
using Android.App;
using Android.Runtime;
using EmotionalTweets;

namespace EmotionalTweetsAndroid
{
    [Application(Debuggable = true, Label = "Emotional Tweets")]
    public class EmotionalTweetsApplication : Application
    {
        public static ApplicationState ApplicationState { get; set; }

        public EmotionalTweetsApplication(IntPtr ptr, JniHandleOwnership ownership)
            : base(ptr, ownership)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            ApplicationState = new ApplicationState();
            Ioc.Register();
        }
    }
}