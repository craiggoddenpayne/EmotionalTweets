using Autofac;
using EmotionalTweets;
using EmotionalTweetsAndroid.Helpers;

namespace EmotionalTweetsAndroid
{
    public class IocRegistration
    {
        public static void RegisterAndroidTypes()
        {
            Ioc.Builder.Register<IEmoticonResourceFinder>(x => new EmoticonResourceFinder()).SingleInstance();
            Ioc.Builder.Register<IDateTimeParser>(x => new DateTimeParser()).SingleInstance();
        }
    }
}