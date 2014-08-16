using System.Linq;
using EmotionalTweets;
using EmotionalTweetsShared.DataContracts;
using NUnit.Framework;

namespace EmotionalTweetsTests.IntegrationTests.EndToEnd
{
    [TestFixture]

    public class EndToEndApiTests
    {
        private SentimentTweetCollection _sentimentTweets;

        [SetUp]
        public void Setup()
        {
            Ioc.Register();
            var controller = Ioc.Resolve<IEmotionalTweetsController>();

            var tweets = controller.SearchTweets("hello").Result;

            _sentimentTweets = new SentimentTweetCollection(
                tweets.statuses.Select(tweet => controller.GetSentiment(tweet).Result));
            
        }


        [Test]
        public void ItShouldReturnSomeResults()
        {
            Assert.That(_sentimentTweets.Count, Is.GreaterThan(0));
        }
    }
}