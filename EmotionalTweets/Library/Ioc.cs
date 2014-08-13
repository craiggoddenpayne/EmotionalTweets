using Autofac;
using EmotionalTweets.Helpers;
using EmotionalTweets.RequestFactory;
using EmotionalTweets.ServiceAdapters;

namespace EmotionalTweets
{
    public class Ioc
    {
        public static IContainer Container { get; private set; }

        public static void Register()
        {
            var container = new ContainerBuilder();
            container.Register<IObjectSerializer>(x => new ObjectSerializer());

            container.Register<IEmotionalTweetsApplication>(x => new EmotionalTweetsApplication());
            container.Register<ISentimentApiAdapter>(x => new SentimentApiAdapter());
            container.Register<ITwitterApiAdapter>(x => new TwitterApiAdapter(
                x.Resolve<ITwitterApiRequestFactory>(),
                x.Resolve<IHttpHelper>(),
                x.Resolve<IObjectSerializer>()));

            container.Register<ITwitterApiRequestFactory>(x => new TwitterApiRequestFactory());
            container.Register<IHttpHelper>(x => new HttpHelper());
            Container = container.Build();
        }

        public static TResult Resolve<TResult>()
        {
            return Container.Resolve<TResult>();
        }
    }

}
