using EmotionalTweets.DataContracts.Twitter;
using EmotionalTweets.Helpers;
using EmotionalTweets.RequestFactory;
using EmotionalTweets.ServiceAdapters;
using NUnit.Framework;

namespace EmotionalTweetsTests.IntegrationTests.TwitterApiAdapterTests
{
    [TestFixture]

    public class TwitterApiLogin
    {
        private ITwitterApiAdapter _twitterApiAdapter;
        private TweetCollection _tweets;

        [SetUp]
        public void Setup()
        {
            _twitterApiAdapter = new TwitterApiAdapter(
                new TwitterApiRequestFactory(), new HttpHelper(), new ObjectSerializer());

            var login = _twitterApiAdapter.Login().Result;
            _tweets = _twitterApiAdapter.Search("hello", login).Result;
        }


        [Test]
        public void ItShouldReturnSomeResults()
        {
            Assert.That(_tweets.statuses.Length, Is.GreaterThan(0));
        }
    }
}