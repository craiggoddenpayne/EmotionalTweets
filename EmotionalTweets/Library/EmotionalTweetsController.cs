using System.Threading.Tasks;
using EmotionalTweets.DataContracts;
using EmotionalTweets.ServiceAdapters;

namespace EmotionalTweets
{
    public class EmotionalTweetsController : IEmotionalTweetsController
    {
        private readonly ITwitterApiAdapter _twitterApiAdapter;
        private readonly ISentimentApiAdapter _sentimentApiAdapter;

        public EmotionalTweetsController(ITwitterApiAdapter twitterApiAdapter,
            ISentimentApiAdapter sentimentApiAdapter)
        {
            _twitterApiAdapter = twitterApiAdapter;
            _sentimentApiAdapter = sentimentApiAdapter;
        }

        public async Task<SentimentTweetCollection> SearchTweetsWithSentiment(string searchQuery)
        {
            var bearerToken = _twitterApiAdapter.Login();
            var tweetResults = _twitterApiAdapter.Search(searchQuery, await bearerToken);
            return await _sentimentApiAdapter.GetSentimentForTweets(await tweetResults);
        }
    }
}