namespace EmotionalTweets.DataContracts.Twitter
{
    public class TwitterAuthentication
    {
        //"{\"token_type\":\"bearer\",\"access_token\":\"AAAAAAAAAAAAAAAAAAAAAPJXZQAAAAAArOm%2FMx%2FvopKkFKe9VwT%2B4f5Gul8%3DJcGzDZmHZO2DFu4we6AqvMSTS06XCthLotgGXdZ95nuXUIrSYP\"}"
		public string token_type{ get; set;}
		public string access_token {get;set;}
    }
}