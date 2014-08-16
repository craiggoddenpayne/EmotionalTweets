using System.Net;
using EmotionalTweetsShared.DataContracts.Twitter;

namespace EmotionalTweets.RequestFactory
{
    public class TwitterApiRequestFactory : ITwitterApiRequestFactory
    {
        //https://dev.twitter.com/docs/auth/application-only-auth
        public HttpWebRequest CreateLoginRequest()
        {    
            var request = WebRequest.Create("https://api.twitter.com/oauth2/token") as HttpWebRequest;
            request.Method = "POST";
            request.Headers["Authorization"] = "Basic Z3BlajZFbXNackhmelhCS0o4ZU11Q2NwMTpIYWpIQml3Rm5QVTBaazVjQ1VVNk9jNkJaa29CTWZFV2h4Y2RVZ09vc3N5aE55N2FhRw==";
            request.ContentType = "application/x-www-form-urlencoded";
            return request;
        }


        public HttpWebRequest CreateSearchTweetRequest(string query, TwitterAuthentication authentication)
        {
            var request = WebRequest.Create("https://api.twitter.com/1.1/search/tweets.json?q=" + WebUtility.UrlEncode(query)) as HttpWebRequest;
            request.Method = "GET";
            request.Headers["Authorization"] = "Bearer " + authentication.access_token;
            return request;
        }
    }
}