using System.Net;
using EmotionalTweets.DataContracts.Twitter;
using EmotionalTweetsTests.Builders;
using NUnit.Framework;

namespace EmotionalTweetsTests.RequestFactoriesTests.SentimentRequestFactoryTests
{
    [TestFixture]
    public class WhenCallingCreateSentimentForTweetRequest : SentimentRequestFactoryTest
    {
        private HttpWebRequest _result;
        private Tweet _tweet;

        [SetUp]
        public void Setup()
        {
            Initialise();
            _tweet = TweetBuilder.Build.WithText("Tweet Message").AnInstance();
            _result = SentimentRequestFactory.CreateSentimentForTweetRequest(_tweet);
        }

        [Test]
        public void ItShouldSetUrl()
        {
            Assert.That(_result.RequestUri.AbsoluteUri, Is.EqualTo("https://jamiembrown-tweet-sentiment-analysis.p.mashape.com/api/?key=e0377bc2cd4f4e0694878329b5439c1f131e67d2&text=Tweet+Message"));
        }

        [Test]
        public void ItShouldSetMashApeHeader()
        {
            Assert.That(_result.Headers["X-Mashape-Key"], Is.EqualTo("2mx5T0Hm3pmshi1ibNb9ej03NTo3p1j9AGPjsnKotgzvmMXm9m"));
        }
    }
}