using System;
using System.Net;
using EmotionalTweets.DataContracts.Twitter;

namespace EmotionalTweets.RequestFactory
{
    public interface ISentimentRequestFactory
    {
        HttpWebRequest CreateSentimentForTweetRequest(Tweet tweet);
    }

    public class SentimentRequestFactory : ISentimentRequestFactory
    {
        public HttpWebRequest CreateSentimentForTweetRequest(Tweet tweet)
        {
            var url = "https://jamiembrown-tweet-sentiment-analysis.p.mashape.com/api/"
                + string.Format("?key={0}&text={1}", "e0377bc2cd4f4e0694878329b5439c1f131e67d2", WebUtility.UrlEncode(tweet.text));

            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            request.Headers["X-Mashape-Key"] = "2mx5T0Hm3pmshi1ibNb9ej03NTo3p1j9AGPjsnKotgzvmMXm9m";
            return request;
        }
    }
}