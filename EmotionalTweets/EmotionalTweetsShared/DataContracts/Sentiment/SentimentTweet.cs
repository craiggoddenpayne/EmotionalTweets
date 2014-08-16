using EmotionalTweetsShared.DataContracts.Twitter;

namespace EmotionalTweetsShared.DataContracts.Sentiment
{
    public class SentimentTweet
    {
        public SentimentResponse Sentiment { get; set; }
        public Tweet Tweet { get; set; }
    }
}