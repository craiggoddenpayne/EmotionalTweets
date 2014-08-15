using EmotionalTweets.DataContracts.Sentiment;
using EmotionalTweets.DataContracts.Twitter;

namespace EmotionalTweets.Mappers
{
    public interface ISentimentTweetMapper
    {
        SentimentTweet MapFor(SentimentResponse sentiment, Tweet tweet);
    }
}