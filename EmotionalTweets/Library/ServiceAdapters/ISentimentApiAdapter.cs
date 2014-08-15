using System.Threading.Tasks;
using EmotionalTweets.DataContracts;
using EmotionalTweets.DataContracts.Twitter;

namespace EmotionalTweets.ServiceAdapters
{
    public interface ISentimentApiAdapter
    {
        Task<SentimentTweetCollection> GetSentimentForTweets(TweetCollection tweetCollection);
    }
}