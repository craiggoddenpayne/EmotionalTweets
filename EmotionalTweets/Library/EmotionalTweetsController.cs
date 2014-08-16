using System.Threading.Tasks;
using EmotionalTweetsShared.DataContracts.Sentiment;
using EmotionalTweetsShared.DataContracts.Twitter;
using EmotionalTweets.Mappers;
using EmotionalTweets.ServiceAdapters;

namespace EmotionalTweets
{
    public class EmotionalTweetsController : IEmotionalTweetsController
    {
        private readonly ITwitterApiAdapter _twitterApiAdapter;
        private readonly ISentimentApiAdapter _sentimentApiAdapter;
        private readonly ISentimentTweetMapper _sentimentTweetMapper;

        public EmotionalTweetsController(ITwitterApiAdapter twitterApiAdapter,
            ISentimentApiAdapter sentimentApiAdapter,
            ISentimentTweetMapper sentimentTweetMapper)
        {
            _twitterApiAdapter = twitterApiAdapter;
            _sentimentApiAdapter = sentimentApiAdapter;
            _sentimentTweetMapper = sentimentTweetMapper;
        }

        public async Task<TweetCollection> SearchTweets(string searchQuery)
        {
            var bearerToken = _twitterApiAdapter.Login();
            return await _twitterApiAdapter.Search(searchQuery, await bearerToken);
        }

        public async Task<SentimentTweet> GetSentiment(Tweet tweet)
        {
            var sentiment = await _sentimentApiAdapter.GetSentiment(tweet);
            return _sentimentTweetMapper.MapFor(sentiment, tweet);
        }
    }
}