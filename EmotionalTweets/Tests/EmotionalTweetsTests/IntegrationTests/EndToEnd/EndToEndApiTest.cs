using EmotionalTweets;
using EmotionalTweets.DataContracts;
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

            _sentimentTweets = controller.SearchTweetsWithSentiment("hello").Result;
        }


        [Test]
        public void ItShouldReturnSomeResults()
        {
            Assert.That(_sentimentTweets.Count, Is.GreaterThan(0));
        }
    }
}