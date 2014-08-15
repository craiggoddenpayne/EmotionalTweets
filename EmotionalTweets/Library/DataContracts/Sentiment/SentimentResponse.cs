namespace EmotionalTweets.DataContracts.Sentiment
{
    public class SentimentResponse
    {
        public string sentiment { get; set; }
        public double score { get; set; }
        public int request_count { get; set; }
        public int request_limit { get; set; }
    }
}
