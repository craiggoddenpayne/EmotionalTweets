using System.Net;
using System.Threading.Tasks;

namespace EmotionalTweets.Helpers
{
    public class ObjectSerializer : IObjectSerializer
    {
        public TResult DeserializeJson<TResult>(string serializedJson)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> DeserializeJson<TResult>(HttpWebResponse webResponse)
        {
            throw new System.NotImplementedException();
        }
    }
}