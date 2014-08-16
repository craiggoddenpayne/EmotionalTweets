using EmotionalTweetsShared.DataContracts;
using EmotionalTweetsShared.DataContracts.Sentiment;

namespace EmotionalTweetsTests.Builders
{
    public class SentimentTweetCollectionBuilder : Builder<SentimentTweetCollectionBuilder, SentimentTweetCollection>
    {
        public override SentimentTweetCollection AnInstance()
        {
            return new SentimentTweetCollection(new SentimentTweet[0]);
        }
    }
}