using System.Net;
using EmotionalTweets.DataContracts.Twitter;

namespace EmotionalTweets.RequestFactory
{
    public interface ITwitterApiRequestFactory
    {
        HttpWebRequest CreateLoginRequest();
        HttpWebRequest CreateSearchTweetRequest(string query, TwitterAuthentication authentication);
    }
}