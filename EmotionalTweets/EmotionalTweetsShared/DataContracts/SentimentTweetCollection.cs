using System.Collections.Generic;
using System.Collections.ObjectModel;
using EmotionalTweetsShared.DataContracts.Sentiment;

namespace EmotionalTweetsShared.DataContracts
{
    public class SentimentTweetCollection : Collection<SentimentTweet>
    {
        public SentimentTweetCollection(IEnumerable<SentimentTweet> sentimentTweets)
        {
            foreach (var sentimentTweet in sentimentTweets)
            {
                Add(sentimentTweet);
            }
        }
    }
}