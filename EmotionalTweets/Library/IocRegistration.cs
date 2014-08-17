using Autofac;
using EmotionalTweets.Helpers;
using EmotionalTweets.Mappers;
using EmotionalTweets.RequestFactory;
using EmotionalTweets.ServiceAdapters;

namespace EmotionalTweets
{
    public static class IocRegistration
    {
        public static void Register()
        {
            Ioc.Builder.Register<IObjectSerializer>(x => new ObjectSerializer()).SingleInstance();

            Ioc.Builder.Register<IEmotionalTweetsController>(x => new EmotionalTweetsController(
                x.Resolve<ITwitterApiAdapter>(),
                x.Resolve<ISentimentApiAdapter>(),
                x.Resolve<ISentimentTweetMapper>())).SingleInstance();

            Ioc.Builder.Register<ISentimentRequestFactory>(x => new SentimentRequestFactory()).SingleInstance();

            Ioc.Builder.Register<ISentimentTweetMapper>(x => new SentimentTweetMapper()).SingleInstance();
            Ioc.Builder.Register<ISentimentApiAdapter>(x => new SentimentApiAdapter(
                x.Resolve<IObjectSerializer>(),
                x.Resolve<ISentimentRequestFactory>(),
                x.Resolve<IHttpHelper>())).SingleInstance();

            Ioc.Builder.Register<ITwitterApiAdapter>(x => new TwitterApiAdapter(
                x.Resolve<ITwitterApiRequestFactory>(),
                x.Resolve<IHttpHelper>(),
                x.Resolve<IObjectSerializer>())).SingleInstance();

            Ioc.Builder.Register<ITwitterApiRequestFactory>(x => new TwitterApiRequestFactory()).SingleInstance();
            Ioc.Builder.Register<IHttpHelper>(x => new HttpHelper()).SingleInstance();
        }
    }
}