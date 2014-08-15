using EmotionalTweets.DataContracts.Twitter;

namespace EmotionalTweetsTests.Builders
{
    public class TwitterUserBuilder : Builder<TwitterUserBuilder, TwitterUser>
    {
        private string _description=  "Manchester";
        private string _screen_name = "@_erroroccured_"; 
        private string _name = "Craig Godden Payne";

        public override TwitterUser AnInstance()
        {

            return new TwitterUser
            {
                description = _description,
                name = _name,
                screen_name = _screen_name
            };
        }
    }
}