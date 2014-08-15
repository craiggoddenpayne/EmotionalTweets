using System.Net;
using System.Threading.Tasks;
using EmotionalTweets.DataContracts;
using EmotionalTweets.DataContracts.Twitter;
using EmotionalTweetsTests.Builders;
using Moq;
using NUnit.Framework;

namespace EmotionalTweetsTests.ServiceAdapterTests.TwitterApiAdapterTests
{
    [TestFixture]
    public class WhenCallingSearchTweets : TwitterServiceAdapterTests
    {
        private TweetCollection _result;
        private string _query;
        private TwitterAuthentication _authToken;
        private Mock<HttpWebRequest> _webRequest;
        private Mock<HttpWebResponse> _webResponse;
        private TweetCollection _tweetCollection;

        [SetUp]
        public void Setup()
        {
            Initialise();

            _query = "Search criteria";
            _authToken = TwitterAuthenticationBuilder.Build.AnInstance();

            _webRequest = new Mock<HttpWebRequest>();
            TwitterApiRequestFactory
                .Setup(x => x.CreateSearchTweetRequest())
                .Returns(_webRequest.Object);

            _webResponse = new Mock<HttpWebResponse>();
            HttpWebRequestHelper
                .Setup(x => x.GetResponse(_webRequest.Object))
                .Returns(Task.FromResult(_webResponse.Object));

            _tweetCollection = TweetCollectionBuilder.Build.AnInstance();
            ObjectSerializer
                .Setup(x => x.DeserializeJson<TweetCollection>(_webResponse.Object))
                .Returns(Task.FromResult(_tweetCollection));

            _result = TwitterApiAdapter.Search(_query, _authToken).Result;
        }

        [Test]
        public void ItShouldCreateWebRequest()
        {
            TwitterApiRequestFactory.Verify(x => x.CreateSearchTweetRequest());
        }

        [Test]
        public void ItShouldGetWebResponse()
        {
            HttpWebRequestHelper.Verify(x => x.GetResponse(_webRequest.Object));
        }

        [Test]
        public void ItShouldDeserializeResponse()
        {
            ObjectSerializer.Verify(x => x.DeserializeJson<TweetCollection>(_webResponse.Object));
        }

        [Test]
        public void ItShouldReturnResult()
        {
            Assert.That(_result, Is.SameAs(_tweetCollection));
        }
    }
}