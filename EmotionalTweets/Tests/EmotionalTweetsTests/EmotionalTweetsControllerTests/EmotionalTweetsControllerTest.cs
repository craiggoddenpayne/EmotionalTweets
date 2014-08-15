using EmotionalTweets;
using EmotionalTweets.ServiceAdapters;
using Moq;

namespace EmotionalTweetsTests.EmotionalTweetsControllerTests
{
    public abstract class EmotionalTweetsControllerTests
    {
        public IEmotionalTweetsController Controller { get; set; }
        public Mock<ITwitterApiAdapter> TwitterApiAdapter { get; set; }
        public Mock<ISentimentApiAdapter> SentimentApiAdapter { get; set; }
        public void Initialise()
        {
            TwitterApiAdapter = new Mock<ITwitterApiAdapter>();

            Controller = new EmotionalTweetsController(
                TwitterApiAdapter.Object,
                SentimentApiAdapter.Object);
        }   
    }
}