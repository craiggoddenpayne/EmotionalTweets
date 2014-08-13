using System.Threading.Tasks;
using EmotionalTweets.DataContracts;

namespace EmotionalTweets.ServiceAdapters
{
    public class TwitterApiAdapter : ITwitterApiAdapter
    {
        public Task<TwitterApplicationAuthentication> Login()
        {
            throw new System.NotImplementedException();
        }

        public Task<TweetCollection> Search(string query, string authenticationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}