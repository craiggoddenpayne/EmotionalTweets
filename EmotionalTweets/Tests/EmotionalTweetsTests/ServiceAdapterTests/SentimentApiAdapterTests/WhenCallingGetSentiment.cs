using System.Net;
using System.Threading.Tasks;
using EmotionalTweetsShared.DataContracts.Sentiment;
using EmotionalTweetsShared.DataContracts.Twitter;
using EmotionalTweetsTests.Builders;
using Moq;
using NUnit.Framework;

namespace EmotionalTweetsTests.ServiceAdapterTests.SentimentApiAdapterTests
{
    [TestFixture]
    public class WhenCallingGetSentiment : SentimentApiAdapterTest
    {
        private SentimentResponse _result;
        private Tweet _tweet;
        private Mock<HttpWebRequest> _httpRequest;
        private Mock<HttpWebResponse> _httpResponse;
        private SentimentResponse _sentimentResponse;

        [SetUp]
        public void Setup()
        {
            Initialise();

            _tweet = TweetBuilder.Build.WithText("1").AnInstance();

            _httpRequest = new Mock<HttpWebRequest>(); 
            SentimentRequestFactory
                .Setup(x => x.CreateSentimentForTweetRequest(_tweet))
                .Returns(_httpRequest.Object);

            _httpResponse = new Mock<HttpWebResponse>();
            HttpHelper
                .Setup(x => x.GetResponse(_httpRequest.Object))
                .Returns(Task.FromResult(_httpResponse.Object));

            _sentimentResponse = SentimentResponseBuilder.Build.WithScore(1.0).AnInstance();
            ObjectSerializer
                .Setup(x => x.DeserializeJson<SentimentResponse>(_httpResponse.Object))
                .Returns(_sentimentResponse);

            _result = SentimentApiAdapter.GetSentiment(_tweet).Result;
        }

        [Test]
        public void ItShouldCreateARequestForEachTweet()
        {
            SentimentRequestFactory.Verify(x => x.CreateSentimentForTweetRequest(_tweet));
        }

        [Test]
        public void ItShouldSendRequests()
        {
            HttpHelper.Verify(x => x.GetResponse(_httpRequest.Object));
        }

        [Test]
        public void ItShouldDeserializeAllResponses()
        {
            ObjectSerializer.Verify(x => x.DeserializeJson<SentimentResponse>(_httpResponse.Object));
        }

        [Test]
        public void ItShouldReturnResults()
        {
            Assert.That(_result, Is.SameAs(_sentimentResponse));
        }
    }
}