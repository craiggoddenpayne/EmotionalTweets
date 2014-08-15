using System.Threading.Tasks;
using EmotionalTweets.DataContracts;
using EmotionalTweets.DataContracts.Sentiment;
using EmotionalTweets.DataContracts.Twitter;
using EmotionalTweets.Helpers;
using EmotionalTweets.RequestFactory;

namespace EmotionalTweets.ServiceAdapters
{
    public class SentimentApiAdapter : ISentimentApiAdapter
    {
        private readonly IObjectSerializer _objectSerializer;
        private readonly ISentimentRequestFactory _sentimentRequestFactory;
        private readonly IHttpHelper _httpHelper;
        private readonly ISentimentTweetMapper _sentimentTweetMapper;

        public SentimentApiAdapter(IObjectSerializer objectSerializer,
            ISentimentRequestFactory sentimentRequestFactory,
            IHttpHelper httpHelper,
            ISentimentTweetMapper sentimentTweetMapper)
        {
            _sentimentRequestFactory = sentimentRequestFactory;
            _httpHelper = httpHelper;
            _sentimentTweetMapper = sentimentTweetMapper;
            _objectSerializer = objectSerializer;
        }

        public async Task<SentimentTweetCollection> GetSentimentForTweets(TweetCollection tweets)
        {
            var result = new SentimentTweetCollection(); 
            foreach (var tweet in tweets.statuses)
            {
                var request = _sentimentRequestFactory.CreateSentimentForTweetRequest(tweet);
                var webResponse = _httpHelper.GetResponse(request);
                var sentiment = _objectSerializer.DeserializeJson<SentimentResponse>(await webResponse);
                var sentimentTweet =_sentimentTweetMapper.MapFor(sentiment, tweet);
                result.Add(sentimentTweet);
            }
            return result;
        }
    }

    public interface ISentimentTweetMapper
    {
        SentimentTweet MapFor(SentimentResponse sentiment, Tweet tweet);
    }
}