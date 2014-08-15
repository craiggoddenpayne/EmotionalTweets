using EmotionalTweets.DataContracts;
using EmotionalTweets.DataContracts.Twitter;

namespace EmotionalTweetsTests.Builders
{
    public class TweetCollectionBuilder : Builder<TweetCollectionBuilder, TweetCollection>
    {
        public Tweet[] statuses = new[] {TweetBuilder.Build.AnInstance()};

        public override TweetCollection AnInstance()
        {
            return new TweetCollection();
        }
    }
}