using System.Net;

namespace EmotionalTweets.RequestFactory
{
    public class TwitterApiRequestFactory : ITwitterApiRequestFactory
    {
        public HttpWebRequest CreateLoginRequest()
        {
            throw new System.NotImplementedException();
        }

        public HttpWebRequest CreateSearchTweetRequest()
        {
            throw new System.NotImplementedException();
        }
    }
}