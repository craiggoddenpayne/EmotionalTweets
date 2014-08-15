using EmotionalTweets.RequestFactory;

namespace EmotionalTweetsTests.RequestFactoriesTests.SentimentRequestFactoryTests
{
    public abstract class SentimentRequestFactoryTest
    {
        public ISentimentRequestFactory SentimentRequestFactory { get; set; }

        public void Initialise()
        {
            SentimentRequestFactory = new SentimentRequestFactory();
        }
    }
}