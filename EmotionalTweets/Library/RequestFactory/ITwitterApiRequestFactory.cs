using System.Net;

namespace EmotionalTweets.RequestFactory
{
    public interface ITwitterApiRequestFactory
    {
        HttpWebRequest CreateLoginRequest();
        HttpWebRequest CreateSearchTweetRequest();
    }
}