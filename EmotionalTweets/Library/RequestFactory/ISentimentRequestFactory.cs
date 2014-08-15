using System.Net;
using EmotionalTweets.DataContracts.Twitter;

namespace EmotionalTweets.RequestFactory
{
    public interface ISentimentRequestFactory
    {
        HttpWebRequest CreateSentimentForTweetRequest(Tweet tweet);
    }
}