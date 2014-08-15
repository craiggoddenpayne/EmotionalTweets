using System.Threading.Tasks;
using EmotionalTweets.DataContracts;
using EmotionalTweets.DataContracts.Twitter;
using EmotionalTweetsTests.Builders;
using NUnit.Framework;

namespace EmotionalTweetsTests.EmotionalTweetsControllerTests
{
    [TestFixture]
    public class WhenCallingSearchTweetsWithSentiment : EmotionalTweetsControllerTests
    {
        private SentimentTweetCollection _result;
        private string _query;
        private TwitterAuthentication _twitterAuthorisation;
        private TweetCollection _tweetResults;
        private SentimentTweetCollection _sentimentTweetCollection;

        [SetUp]
        public void Setup()
        {
            Initialise();
            _query = "some text";

            _twitterAuthorisation = TwitterAuthenticationBuilder.Build.AnInstance();
            TwitterApiAdapter
                .Setup(x => x.Login())
                .Returns(Task.FromResult(_twitterAuthorisation));

            _tweetResults = TweetCollectionBuilder.Build.AnInstance();
            TwitterApiAdapter
                .Setup(x => x.Search(_query, _twitterAuthorisation))
                .Returns(Task.FromResult(_tweetResults));

            _sentimentTweetCollection = SentimentTweetCollectionBuilder.Build.AnInstance();
            SentimentApiAdapter
                .Setup(x => x.GetSentimentForTweets(_tweetResults))
                .Returns(Task.FromResult(_sentimentTweetCollection));

            _result = Controller.SearchTweetsWithSentiment(_query).Result;
        }

        [Test]
        public void ItShouldLoginToTwitter()
        {
            TwitterApiAdapter.Verify(x => x.Login());
        }

        [Test]
        public void ItShouldSearchTwitterToGetTweets()
        {
            TwitterApiAdapter.Verify(x => x.Search(_query, _twitterAuthorisation));
        }

        [Test]
        public void ItShouldCallSentimentService()
        {
            SentimentApiAdapter.Verify(x => x.GetSentimentForTweets(_tweetResults));
        }

        [Test]
        public void ItShouldReturnResult()
        {
            Assert.That(_result, Is.SameAs(_sentimentTweetCollection));
        }
    }
}