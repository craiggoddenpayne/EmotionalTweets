using System.Threading.Tasks;
using EmotionalTweets.DataContracts;
using EmotionalTweets.DataContracts.Twitter;
using EmotionalTweets.Helpers;
using EmotionalTweets.RequestFactory;
using EmotionalTweets.ServiceAdapters;
using Moq;
using NUnit.Framework;

namespace EmotionalTweetsTests.IntegrationTests.EndToEnd
{
    [TestFixture]

    public class EndToEndApiTests
    {
        private ITwitterApiAdapter _twitterApiAdapter;
        private TweetCollection _tweets;
        private SentimentApiAdapter _sentimentApiAdapter;
        private SentimentTweetCollection _sentimentTweets;

        [SetUp]
        public void Setup()
        {
            _twitterApiAdapter = new TwitterApiAdapter(
                new TwitterApiRequestFactory(), new HttpHelper(), new ObjectSerializer());

            var login = _twitterApiAdapter.Login().Result;
            _tweets = _twitterApiAdapter.Search("hello", login).Result;

            _sentimentApiAdapter = new SentimentApiAdapter(
                new ObjectSerializer(), new SentimentRequestFactory(),
                new HttpHelper(), new Mock<ISentimentTweetMapper>().Object);

            _sentimentTweets = _sentimentApiAdapter.GetSentimentForTweets(_tweets).Result;
        }


        [Test]
        public void ItShouldReturnSomeResults()
        {
            Assert.That(_tweets.statuses.Length, Is.GreaterThan(0));
            Assert.That(_tweets.statuses.Length, Is.EqualTo(_sentimentTweets.Count));

        }    
    }
}