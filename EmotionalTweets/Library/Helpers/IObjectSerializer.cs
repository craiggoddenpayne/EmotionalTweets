using System.Net;
using System.Threading.Tasks;

namespace EmotionalTweets.Helpers
{
    public interface IObjectSerializer
    {
        TResult DeserializeJson<TResult>(string serializedJson);
        Task<TResult> DeserializeJson<TResult>(HttpWebResponse webResponse);
    }
}