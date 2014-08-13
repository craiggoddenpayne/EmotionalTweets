using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace EmotionalTweets.Helpers
{
    public interface IHttpHelper
    {
        Task<Stream> GetRequestStream(HttpWebRequest webRequest);
        Task<HttpWebResponse> GetResponse(HttpWebRequest request);
    }
}