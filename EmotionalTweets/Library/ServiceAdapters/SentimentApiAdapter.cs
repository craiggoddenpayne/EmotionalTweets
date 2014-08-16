using System.Threading.Tasks;
using EmotionalTweetsShared.DataContracts.Sentiment;
using EmotionalTweetsShared.DataContracts.Twitter;
using EmotionalTweets.Helpers;
using EmotionalTweets.RequestFactory;

namespace EmotionalTweets.ServiceAdapters
{
    public class SentimentApiAdapter : ISentimentApiAdapter
    {
        private readonly IObjectSerializer _objectSerializer;
        private readonly ISentimentRequestFactory _sentimentRequestFactory;
        private readonly IHttpHelper _httpHelper;

        public SentimentApiAdapter(IObjectSerializer objectSerializer,
            ISentimentRequestFactory sentimentRequestFactory,
            IHttpHelper httpHelper)
        {
            _sentimentRequestFactory = sentimentRequestFactory;
            _httpHelper = httpHelper;
            _objectSerializer = objectSerializer;
        }

        public async Task<SentimentResponse> GetSentiment(Tweet tweet)
        {
            var request = _sentimentRequestFactory.CreateSentimentForTweetRequest(tweet);
            var webResponse = _httpHelper.GetResponse(request);
            var sentiment = _objectSerializer.DeserializeJson<SentimentResponse>(await webResponse);
            return sentiment;
        }
    }
}