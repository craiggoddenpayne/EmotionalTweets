using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace EmotionalTweets.Helpers
{
    public class HttpHelper : IHttpHelper
    {
        public async Task<Stream> GetRequestStream(HttpWebRequest webRequest)
        {
            return await Task.Factory.FromAsync(
                (cb, o) => ((HttpWebRequest)o).BeginGetRequestStream(cb, o),
                res => ((HttpWebRequest)res.AsyncState).EndGetRequestStream(res), webRequest);
        }

        public async Task<HttpWebResponse> GetResponse(HttpWebRequest request)
        {
            return await Task.Factory.FromAsync(
                (cb, o) => ((HttpWebRequest)o).BeginGetResponse(cb, o),
                res => ((HttpWebRequest)res.AsyncState).EndGetResponse(res), request) as HttpWebResponse;
        }
    }
}