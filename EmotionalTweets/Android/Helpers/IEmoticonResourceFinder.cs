using EmotionalTweetsShared.DataContracts.Sentiment;

namespace EmotionalTweetsAndroid.Helpers
{
    public interface IEmoticonResourceFinder
    {
        int FindEmoticonForSentiment(SentimentResponse sentiment);
    }
}