using System.Net;
using EmotionalTweetsShared.DataContracts.Twitter;

namespace EmotionalTweets.RequestFactory
{
    public interface ITwitterApiRequestFactory
    {
        HttpWebRequest CreateLoginRequest();
        HttpWebRequest CreateSearchTweetRequest(string query, TwitterAuthentication authentication);
    }
}