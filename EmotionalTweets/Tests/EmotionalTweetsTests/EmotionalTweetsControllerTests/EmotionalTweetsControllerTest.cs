using EmotionalTweets;
using EmotionalTweets.Mappers;
using EmotionalTweets.ServiceAdapters;
using Moq;

namespace EmotionalTweetsTests.EmotionalTweetsControllerTests
{
    public abstract class EmotionalTweetsControllerTests
    {
        public IEmotionalTweetsController Controller { get; set; }
        public Mock<ITwitterApiAdapter> TwitterApiAdapter { get; set; }
        public Mock<ISentimentApiAdapter> SentimentApiAdapter { get; set; }
        public Mock<ISentimentTweetMapper> SentimentTweetMapper { get; set; }
        public void Initialise()
        {
            TwitterApiAdapter = new Mock<ITwitterApiAdapter>();
            SentimentApiAdapter = new Mock<ISentimentApiAdapter>();
            SentimentTweetMapper = new Mock<ISentimentTweetMapper>();

            Controller = new EmotionalTweetsController(
                TwitterApiAdapter.Object,
                SentimentApiAdapter.Object,
                SentimentTweetMapper.Object);
        }   
    }
}