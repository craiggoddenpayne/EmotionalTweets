using EmotionalTweets.DataContracts.Twitter;

namespace EmotionalTweets.DataContracts.Sentiment
{
    public class SentimentTweet
    {
        public SentimentResponse Sentiment { get; set; }
        public Tweet Tweet { get; set; }
    }
}