using EmotionalTweetsShared.DataContracts.Twitter;

namespace EmotionalTweetsTests.Builders
{
    public class TwitterAuthenticationBuilder :
        Builder<TwitterAuthenticationBuilder, TwitterAuthentication>
    {
        private string _access_token = "TOKEN";
        private string _token_type = "BEARER";
        public override TwitterAuthentication AnInstance()
        {
            return new TwitterAuthentication
            {
                access_token = _access_token,
                token_type = _token_type 
            };
        }
    }
}