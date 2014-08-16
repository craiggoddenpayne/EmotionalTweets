using EmotionalTweetsShared.DataContracts.Sentiment;
using EmotionalTweetsShared.DataContracts.Twitter;

namespace EmotionalTweets.Mappers
{
    public class SentimentTweetMapper : ISentimentTweetMapper
    {
        public SentimentTweet MapFor(SentimentResponse sentiment, Tweet tweet)
        {
            return new SentimentTweet
            {
                Sentiment = sentiment,
                Tweet = tweet
            };
        }
    }
}