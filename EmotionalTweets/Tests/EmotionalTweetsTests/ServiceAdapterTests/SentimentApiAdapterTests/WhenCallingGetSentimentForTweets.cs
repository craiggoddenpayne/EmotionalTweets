using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EmotionalTweets.DataContracts;
using EmotionalTweets.DataContracts.Sentiment;
using EmotionalTweets.DataContracts.Twitter;
using EmotionalTweetsTests.Builders;
using Moq;
using NUnit.Framework;

namespace EmotionalTweetsTests.ServiceAdapterTests.SentimentApiAdapterTests
{
    [TestFixture]
    public class WhenCallingGetSentimentForTweets : SentimentApiAdapterTest
    {
        private SentimentTweetCollection _result;
        private TweetCollection _tweetCollection;
        private IEnumerable<Tweet> _tweets;
        private Mock<HttpWebRequest> _httpRequest1;
        private Mock<HttpWebRequest> _httpRequest2;
        private Mock<HttpWebResponse> _httpResponse1;
        private Mock<HttpWebResponse> _httpResponse2;
        private SentimentResponse _sentimentResponse1;
        private SentimentResponse _sentimentResponse2;
        private SentimentTweet _sentimentTweet1;
        private SentimentTweet _sentimentTweet2;

        [SetUp]
        public void Setup()
        {
            Initialise();

            _tweets = new[]
            {
                TweetBuilder.Build.WithText("1").AnInstance(),
                TweetBuilder.Build.WithText("2").AnInstance(),
            };

            _tweetCollection = TweetCollectionBuilder
                .Build
                .WithStatuses(_tweets)
                .AnInstance();

            _httpRequest1 = new Mock<HttpWebRequest>(); 
            SentimentRequestFactory
                .Setup(x => x.CreateSentimentForTweetRequest(_tweetCollection.statuses[0]))
                .Returns(_httpRequest1.Object);

            _httpRequest2 = new Mock<HttpWebRequest>();
            SentimentRequestFactory
                .Setup(x => x.CreateSentimentForTweetRequest(_tweetCollection.statuses[1]))
                .Returns(_httpRequest2.Object);

            _httpResponse1 = new Mock<HttpWebResponse>();
            HttpHelper
                .Setup(x => x.GetResponse(_httpRequest1.Object))
                .Returns(Task.FromResult(_httpResponse1.Object));

            _httpResponse2 = new Mock<HttpWebResponse>();
            HttpHelper
                .Setup(x => x.GetResponse(_httpRequest2.Object))
                .Returns(Task.FromResult(_httpResponse2.Object));

            _sentimentResponse1 = SentimentResponseBuilder.Build.WithScore(1.0).AnInstance();
            ObjectSerializer
                .Setup(x => x.DeserializeJson<SentimentResponse>(_httpResponse1.Object))
                .Returns(_sentimentResponse1);

            _sentimentResponse2 = SentimentResponseBuilder.Build.WithScore(2.0).AnInstance();
            ObjectSerializer
                .Setup(x => x.DeserializeJson<SentimentResponse>(_httpResponse2.Object))
                .Returns(_sentimentResponse2);

            _sentimentTweet1 = SentimentTweetBuilder.Build.AnInstance();
            SentimentTweetMapper
                .Setup(x => x.MapFor(_sentimentResponse1, _tweetCollection.statuses[0]))
                .Returns(_sentimentTweet1);

            _sentimentTweet2 = SentimentTweetBuilder.Build.AnInstance();
            SentimentTweetMapper
                .Setup(x => x.MapFor(_sentimentResponse2, _tweetCollection.statuses[1]))
                .Returns(_sentimentTweet2);

            _result = SentimentApiAdapter.GetSentimentForTweets(_tweetCollection).Result;
        }

        [Test]
        public void ItShouldCreateARequestForEachTweet()
        {
            SentimentRequestFactory.Verify(x => x.CreateSentimentForTweetRequest(_tweets.ElementAt(0)));
            SentimentRequestFactory.Verify(x => x.CreateSentimentForTweetRequest(_tweets.ElementAt(1)));
        }

        [Test]
        public void ItShouldSendRequests()
        {
            HttpHelper.Verify(x => x.GetResponse(_httpRequest1.Object));
            HttpHelper.Verify(x => x.GetResponse(_httpRequest2.Object));
        }

        [Test]
        public void ItShouldDeserializeAllResponses()
        {
            ObjectSerializer.Verify(x => x.DeserializeJson<SentimentResponse>(_httpResponse1.Object));
            ObjectSerializer.Verify(x => x.DeserializeJson<SentimentResponse>(_httpResponse2.Object));
        }

        [Test]
        public void ItShouldMapSentimentAndTweetTogether()
        {
            SentimentTweetMapper.Verify(x => x.MapFor(_sentimentResponse1, _tweets.ElementAt(0)));
            SentimentTweetMapper.Verify(x => x.MapFor(_sentimentResponse2, _tweets.ElementAt(1)));
        }

        [Test]
        public void ItShouldReturnResults()
        {
            Assert.That(_result.ElementAt(0), Is.SameAs(_sentimentTweet1));
            Assert.That(_result.ElementAt(1), Is.SameAs(_sentimentTweet2));
        }
    }
}