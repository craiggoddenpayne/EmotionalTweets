using EmotionalTweets.DataContracts.Sentiment;

namespace EmotionalTweetsTests.Builders
{
    public class SentimentTweetBuilder : Builder<SentimentTweetBuilder, SentimentTweet>
    {
        public override SentimentTweet AnInstance()
        {
            return new SentimentTweet
            {
                
            };
        }
    }
}