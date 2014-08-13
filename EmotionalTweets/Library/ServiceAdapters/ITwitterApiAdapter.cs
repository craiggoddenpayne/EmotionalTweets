using System.Threading.Tasks;
using EmotionalTweets.DataContracts;

namespace EmotionalTweets.ServiceAdapters
{
    public interface ITwitterApiAdapter
    {
        Task<TwitterApplicationAuthentication> Login();
        Task<TweetCollection> Search(string query, string authenticationToken);
    }
}