using EmotionalTweets.DataContracts;

namespace EmotionalTweetsTests.Builders
{
    public class TweetCollectionBuilder : Builder<TweetCollectionBuilder, TweetCollection>
    {
        public override TweetCollection AnInstance()
        {
            return new TweetCollection();
        }
    }
}