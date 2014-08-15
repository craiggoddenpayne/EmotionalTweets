using System.Text;
using System.Threading.Tasks;
using EmotionalTweets.DataContracts.Twitter;
using EmotionalTweets.Helpers;
using EmotionalTweets.RequestFactory;

namespace EmotionalTweets.ServiceAdapters
{
    public class TwitterApiAdapter : ITwitterApiAdapter
    {
        private readonly ITwitterApiRequestFactory _twitterApiRequestFactory;
        private readonly IHttpHelper _webRequestHelper;
        private readonly IObjectSerializer _objectSerializer;

        public TwitterApiAdapter(ITwitterApiRequestFactory twitterApiRequestFactory,
            IHttpHelper webRequestHelper,
            IObjectSerializer objectSerializer)
        {
            _twitterApiRequestFactory = twitterApiRequestFactory;
            _webRequestHelper = webRequestHelper;
            _objectSerializer = objectSerializer;
        }

        public async Task<TwitterAuthentication> Login()
        {
            var loginRequest = _twitterApiRequestFactory.CreateLoginRequest();

            var stream = await _webRequestHelper.GetRequestStream(loginRequest);
            var data = Encoding.UTF8.GetBytes("grant_type=client_credentials");
            stream.Write(data, 0, data.Length);
            
            var webResponse = await _webRequestHelper.GetResponse(loginRequest);
            return await _objectSerializer.DeserializeJson<TwitterAuthentication>(webResponse);
        }

        public async Task<TweetCollection> Search(string query, TwitterAuthentication authentication)
        {
            var request = _twitterApiRequestFactory.CreateSearchTweetRequest();
            var webResponse = await _webRequestHelper.GetResponse(request);
            return await _objectSerializer.DeserializeJson<TweetCollection>(webResponse);
        }
    }
}