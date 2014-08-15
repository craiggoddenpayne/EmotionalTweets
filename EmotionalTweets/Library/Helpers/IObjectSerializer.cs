using System.Net;

namespace EmotionalTweets.Helpers
{
    public interface IObjectSerializer
    {
        TResult DeserializeJson<TResult>(string serializedJson);
        TResult DeserializeJson<TResult>(HttpWebResponse webResponse);
    }
}