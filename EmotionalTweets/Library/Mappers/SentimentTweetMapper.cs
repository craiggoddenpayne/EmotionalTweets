using EmotionalTweets.DataContracts.Sentiment;
using EmotionalTweets.DataContracts.Twitter;

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