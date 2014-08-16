using System.Threading.Tasks;
using EmotionalTweetsShared.DataContracts.Twitter;
using EmotionalTweetsTests.Builders;
using NUnit.Framework;

namespace EmotionalTweetsTests.EmotionalTweetsControllerTests
{
    [TestFixture]
    public class WhenCallingSearchTweets : EmotionalTweetsControllerTests
    {
        private TweetCollection _result;
        private string _query;
        private TwitterAuthentication _twitterAuthorisation;
        private TweetCollection _tweetCollection;

        [SetUp]
        public void Setup()
        {
            Initialise();
            _query = "some text";

            _twitterAuthorisation = TwitterAuthenticationBuilder.Build.AnInstance();
            TwitterApiAdapter
                .Setup(x => x.Login())
                .Returns(Task.FromResult(_twitterAuthorisation));

            _tweetCollection = TweetCollectionBuilder.Build.AnInstance();
            TwitterApiAdapter
                .Setup(x => x.Search(_query, _twitterAuthorisation))
                .Returns(Task.FromResult(_tweetCollection));

            _result = Controller.SearchTweets(_query).Result;
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
        public void ItShouldReturnResult()
        {
            Assert.That(_result, Is.SameAs(_tweetCollection));
        }
    }
}