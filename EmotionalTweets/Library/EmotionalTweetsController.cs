using System.Threading.Tasks;
using EmotionalTweets.DataContracts;
using EmotionalTweets.ServiceAdapters;

namespace EmotionalTweets
{
    public class EmotionalTweetsController : IEmotionalTweetsController
    {
        private readonly ITwitterApiAdapter _twitterApiAdapter;

        public EmotionalTweetsController(ITwitterApiAdapter twitterApiAdapter)
        {
            _twitterApiAdapter = twitterApiAdapter;
        }

        public async Task<SentimentTweetCollection> SearchTweetsWithSentiment(string searchQuery)
        {
            var bearerToken = await _twitterApiAdapter.Login();
            var tweetResults = await _twitterApiAdapter.Search(searchQuery, bearerToken);
            return null;
        }
    }
}