using EmotionalTweets.Helpers;
using EmotionalTweets.RequestFactory;
using EmotionalTweets.ServiceAdapters;
using Moq;

namespace EmotionalTweetsTests.ServiceAdapterTests.TwitterApiAdapterTests
{
    public abstract class TwitterServiceAdapterTests
    {
        public ITwitterApiAdapter TwitterApiAdapter { get; set; }
        public Mock<ITwitterApiRequestFactory> TwitterApiRequestFactory { get; set; }
        public Mock<IHttpHelper> HttpWebRequestHelper { get; set; }
        public Mock<IObjectSerializer> ObjectSerializer { get; set; }

        public void Initialise()
        {
            TwitterApiRequestFactory = new Mock<ITwitterApiRequestFactory>();
            HttpWebRequestHelper = new Mock<IHttpHelper>();
            ObjectSerializer = new Mock<IObjectSerializer>();

            TwitterApiAdapter = new TwitterApiAdapter(
                TwitterApiRequestFactory.Object,
                HttpWebRequestHelper.Object,
                ObjectSerializer.Object);
        }
    }
}