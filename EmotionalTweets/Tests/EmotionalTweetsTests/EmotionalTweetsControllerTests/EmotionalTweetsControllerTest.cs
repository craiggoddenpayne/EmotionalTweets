using EmotionalTweets;
using EmotionalTweets.ServiceAdapters;
using Moq;

namespace EmotionalTweetsTests.EmotionalTweetsController
{
    public abstract class EmotionalTweetsControllerTests
    {
        public IEmotionalTweetsController Controller { get; set; }
        public Mock<ITwitterApiAdapter> TwitterApiAdapter { get; set; }
        public void Initialise()
        {
            TwitterApiAdapter = new Mock<ITwitterApiAdapter>();

            Controller = new EmotionalTweets.EmotionalTweetsController(
                TwitterApiAdapter.Object);
        }   
    }
}