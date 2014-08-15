using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace EmotionalTweets.Helpers
{
    public class ObjectSerializer : IObjectSerializer
    {
        private readonly JsonSerializer _jsonSerializer;

		public ObjectSerializer ()
		{
		    _jsonSerializer = new JsonSerializer();
		}

        public TResult DeserializeJson<TResult> (string serializedJson)
		{
			return _jsonSerializer.Deserialize<TResult>(new JsonTextReader(new StringReader(serializedJson)));
		}

		public TResult DeserializeJson<TResult> (HttpWebResponse message)
		{
		    using (var responseStream = new StreamReader(message.GetResponseStream()))
		    {
		        var jsonObject = responseStream.ReadToEnd();
		        return DeserializeJson<TResult>(jsonObject);
		    }
		}
	}
}