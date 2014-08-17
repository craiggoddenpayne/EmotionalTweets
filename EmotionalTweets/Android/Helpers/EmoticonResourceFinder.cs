using EmotionalTweetsShared.DataContracts.Sentiment;

namespace EmotionalTweetsAndroid.Helpers
{
    public class EmoticonResourceFinder : IEmoticonResourceFinder
    {
        public int FindEmoticonForSentiment(SentimentResponse sentiment)
        {
            if(sentiment.score > 0.3)
                return Resource.Drawable.Happy;
            
            if(sentiment.score < -0.3)
                return Resource.Drawable.Sad;

            return Resource.Drawable.Neutral;
                
        }
    }
}