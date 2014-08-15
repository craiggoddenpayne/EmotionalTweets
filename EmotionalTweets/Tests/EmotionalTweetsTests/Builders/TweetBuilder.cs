using EmotionalTweets.DataContracts.Twitter;

namespace EmotionalTweetsTests.Builders
{
    public class TweetBuilder : Builder<TweetBuilder, Tweet>
    {
        private string _text = "Some text";
        private string _created_at = "2014-01-01";
        private int _followers_count = 1;
        private string _profile_background_image_url = "http://www.google.com";
        private TwitterUser _user = TwitterUserBuilder.Build.AnInstance();

        public override Tweet AnInstance()
        {
            return new Tweet
            {
                created_at = _created_at,
                followers_count = _followers_count,
                profile_background_image_url = _profile_background_image_url,
                text = _text,
                user = _user,
            };
        }
    }
}