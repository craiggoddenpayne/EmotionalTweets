using System.Threading.Tasks;
using EmotionalTweets.DataContracts;
using EmotionalTweets.DataContracts.Twitter;

namespace EmotionalTweets.ServiceAdapters
{
    public class SentimentApiAdapter : ISentimentApiAdapter
    {
        public Task<SentimentTweetCollection> CheckSentimentForTweets(TweetCollection tweetCollection)
        {
            throw new System.NotImplementedException();
        }
    }
}