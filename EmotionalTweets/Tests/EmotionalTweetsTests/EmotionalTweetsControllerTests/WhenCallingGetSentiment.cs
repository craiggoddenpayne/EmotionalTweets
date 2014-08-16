using System.Threading.Tasks;
using EmotionalTweetsShared.DataContracts.Sentiment;
using EmotionalTweetsShared.DataContracts.Twitter;
using EmotionalTweetsTests.Builders;
using NUnit.Framework;

namespace EmotionalTweetsTests.EmotionalTweetsControllerTests
{
    [TestFixture]
    public class WhenCallingGetSentiment : EmotionalTweetsControllerTests
    {
        private SentimentTweet _result;
        private Tweet _tweet;
        private SentimentResponse _sentimentReponse;
        private SentimentTweet _sentimentTweet;

        [SetUp]
        public void Setup()
        {
            Initialise();

            _tweet = TweetBuilder.Build.AnInstance();

            _sentimentReponse = SentimentResponseBuilder.Build.AnInstance();
            SentimentApiAdapter
                .Setup(x => x.GetSentiment(_tweet))
                .Returns(Task.FromResult(_sentimentReponse));

            _sentimentTweet = SentimentTweetBuilder.Build.AnInstance();
            SentimentTweetMapper
                .Setup(x => x.MapFor(_sentimentReponse, _tweet))
                .Returns(_sentimentTweet);

            _result = Controller.GetSentiment(_tweet).Result;
        }

        [Test]
        public void ItShouldGetSentimentFromService()
        {
            SentimentApiAdapter.Verify(x => x.GetSentiment(_tweet));
        }

        [Test]
        public void ItShouldMapValues()
        {
            SentimentTweetMapper.Verify(x => x.MapFor(_sentimentReponse, _tweet));
        }

        [Test]
        public void ItShouldReturnResult()
        {
            Assert.That(_result, Is.SameAs(_sentimentTweet));
        }
    }
}