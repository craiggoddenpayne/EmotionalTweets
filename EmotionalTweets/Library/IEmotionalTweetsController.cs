using System.Threading.Tasks;
using EmotionalTweets.DataContracts;

namespace EmotionalTweets
{
    public interface IEmotionalTweetsController
    {
        Task<SentimentTweetCollection> SearchTweetsWithSentiment(string searchQuery);
    }
}
