using System.Collections.Generic;
using System.Linq;
using EmotionalTweets.DataContracts.Twitter;

namespace EmotionalTweetsTests.Builders
{
    public class TweetCollectionBuilder : Builder<TweetCollectionBuilder, TweetCollection>
    {
        private Tweet[] _statuses = {TweetBuilder.Build.AnInstance()};

        public override TweetCollection AnInstance()
        {
            return new TweetCollection
            {
                statuses = _statuses
            };
        }

        public TweetCollectionBuilder WithStatuses(IEnumerable<Tweet> statuses)
        {
            _statuses = statuses.ToArray();
            return this;
        }
    }
}