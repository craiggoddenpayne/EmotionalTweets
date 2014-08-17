using Autofac;

namespace EmotionalTweets
{
    public class Ioc
    {
        private static readonly ContainerBuilder ContainerBuilder = new ContainerBuilder();
        public static IContainer Container { get; private set; }

        public static ContainerBuilder Builder
        {
            get { return ContainerBuilder; }
        }

        public static void Initialise()
        {
            Container = ContainerBuilder.Build();
        }

        public static TResult Resolve<TResult>()
        {
            return Container.Resolve<TResult>();
        }
    }

}
