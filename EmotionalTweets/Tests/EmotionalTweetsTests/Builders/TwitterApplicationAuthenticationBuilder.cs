using EmotionalTweets.DataContracts;

namespace EmotionalTweetsTests.Builders
{
    public class TwitterApplicationAuthenticationBuilder :
        Builder<TwitterApplicationAuthenticationBuilder, TwitterApplicationAuthentication>
    {
        public override TwitterApplicationAuthentication AnInstance()
        {
            return new TwitterApplicationAuthentication();
        }
    }
}