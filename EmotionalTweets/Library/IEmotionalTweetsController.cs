using System.Threading.Tasks;
using EmotionalTweetsShared.DataContracts.Sentiment;
using EmotionalTweetsShared.DataContracts.Twitter;

namespace EmotionalTweets
{
    public interface IEmotionalTweetsController
    {
        Task<TweetCollection> SearchTweets(string searchQuery);
        Task<SentimentTweet> GetSentiment(Tweet tweet);
    }
}
