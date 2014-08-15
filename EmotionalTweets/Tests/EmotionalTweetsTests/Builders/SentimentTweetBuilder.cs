using EmotionalTweets.DataContracts;
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

    public class SentimentTweetCollectionBuilder : Builder<SentimentTweetCollectionBuilder, SentimentTweetCollection>
    {
        public override SentimentTweetCollection AnInstance()
        {
            return new SentimentTweetCollection
            {
            };
        }
    }
}