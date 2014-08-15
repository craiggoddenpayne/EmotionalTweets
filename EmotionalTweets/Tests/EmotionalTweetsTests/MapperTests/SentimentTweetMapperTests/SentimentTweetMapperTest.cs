using EmotionalTweets.Mappers;

namespace EmotionalTweetsTests.MapperTests.SentimentTweetMapperTests
{
    public class SentimentTweetMapperTest
    {
        public ISentimentTweetMapper SentimentTweetMapper { get; set; }

        public void Initialise()
        {
            SentimentTweetMapper = new SentimentTweetMapper();
        }
    }
}