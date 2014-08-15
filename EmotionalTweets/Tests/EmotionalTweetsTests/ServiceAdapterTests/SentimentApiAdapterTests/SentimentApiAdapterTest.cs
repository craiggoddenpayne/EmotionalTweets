using EmotionalTweets.Helpers;
using EmotionalTweets.RequestFactory;
using EmotionalTweets.ServiceAdapters;
using Moq;

namespace EmotionalTweetsTests.ServiceAdapterTests.SentimentApiAdapterTests
{
    public abstract class SentimentApiAdapterTest
    {
        public ISentimentApiAdapter SentimentApiAdapter { get; set; }

        public Mock<IObjectSerializer> ObjectSerializer { get; set; }
        public Mock<ISentimentRequestFactory> SentimentRequestFactory { get; set; }
        public Mock<IHttpHelper> HttpHelper { get; set; }
        public Mock<ISentimentTweetMapper> SentimentTweetMapper { get; set; }

        public void Initialise()
        {
            ObjectSerializer = new Mock<IObjectSerializer>();
            SentimentRequestFactory = new Mock<ISentimentRequestFactory>();
            HttpHelper = new Mock<IHttpHelper>();
            SentimentTweetMapper = new Mock<ISentimentTweetMapper>();

            SentimentApiAdapter = new SentimentApiAdapter(
                ObjectSerializer.Object,
                SentimentRequestFactory.Object,
                HttpHelper.Object,
                SentimentTweetMapper.Object);
        }
    }
}