using EmotionalTweets.RequestFactory;

namespace EmotionalTweetsTests.RequestFactoriesTests.TwitterApiRequestFactoryTests
{
    public abstract class TwitterApiRequestFactoryTest
    {
        public ITwitterApiRequestFactory TwitterApiRequestFactory { get; set; }

        public void Initialise()
        {
            TwitterApiRequestFactory = new TwitterApiRequestFactory();
        }
    }
}