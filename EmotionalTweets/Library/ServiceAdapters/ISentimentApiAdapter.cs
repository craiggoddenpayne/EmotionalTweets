using System.Threading.Tasks;
using EmotionalTweetsShared.DataContracts.Sentiment;
using EmotionalTweetsShared.DataContracts.Twitter;

namespace EmotionalTweets.ServiceAdapters
{
    public interface ISentimentApiAdapter
    {
        Task<SentimentResponse> GetSentiment(Tweet tweet);
    }
}