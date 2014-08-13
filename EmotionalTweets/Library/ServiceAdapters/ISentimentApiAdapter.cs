using System.Threading.Tasks;
using EmotionalTweets.DataContracts;

namespace EmotionalTweets.ServiceAdapters
{
    public interface ISentimentApiAdapter
    {
        Task<SentimentTweetCollection> CheckSentimentForTweets(TweetCollection tweetCollection);
    }
}