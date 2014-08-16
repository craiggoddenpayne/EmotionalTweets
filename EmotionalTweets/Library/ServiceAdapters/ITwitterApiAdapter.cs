using System.Threading.Tasks;
using EmotionalTweetsShared.DataContracts.Twitter;
using EmotionalTweetsShared.DataContracts.Twitter;

namespace EmotionalTweets.ServiceAdapters
{
    public interface ITwitterApiAdapter
    {
        Task<TwitterAuthentication> Login();
        Task<TweetCollection> Search(string query, TwitterAuthentication authentication);
    }
}