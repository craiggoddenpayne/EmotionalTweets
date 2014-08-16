using EmotionalTweetsShared.DataContracts.Sentiment;
using EmotionalTweetsShared.DataContracts.Twitter;

namespace EmotionalTweets.Mappers
{
    public interface ISentimentTweetMapper
    {
        SentimentTweet MapFor(SentimentResponse sentiment, Tweet tweet);
    }
}