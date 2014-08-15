namespace EmotionalTweets.DataContracts.Twitter
{
    public class Tweet
    {
        //"Tue Aug 12 21:13:41 +0000 2014"
        public string created_at { get; set; }
        public string text { get; set; }

        public TwitterUser user { get; set; }
        public int followers_count { get; set; }

        public string profile_background_image_url { get; set; }   
    }
}