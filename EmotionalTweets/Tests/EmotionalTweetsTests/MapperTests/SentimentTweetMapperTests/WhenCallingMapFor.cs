using EmotionalTweetsShared.DataContracts.Sentiment;
using EmotionalTweetsShared.DataContracts.Twitter;
using EmotionalTweetsTests.Builders;
using NUnit.Framework;

namespace EmotionalTweetsTests.MapperTests.SentimentTweetMapperTests
{
    [TestFixture]
    public class WhenCallingMapFor : SentimentTweetMapperTest
    {
        private SentimentResponse _sentiment;
        private Tweet _tweet;
        private SentimentTweet _result;

        [SetUp]
        public void Setup()
        {
            Initialise();

            _sentiment = SentimentResponseBuilder.Build.AnInstance();
            _tweet = TweetBuilder.Build.AnInstance();

            _result = SentimentTweetMapper.MapFor(_sentiment, _tweet);
        }

        [Test]
        public void ItShouldMapSentiment()
        {
            Assert.That(_result.Sentiment, Is.SameAs(_sentiment));
        }

        [Test]
        public void ItShouldMapTweet()
        {
            Assert.That(_result.Tweet, Is.SameAs(_tweet));
        }
    }
}