using EmotionalTweets.DataContracts.Sentiment;

namespace EmotionalTweetsTests.Builders
{
    public class SentimentResponseBuilder : Builder<SentimentResponseBuilder, SentimentResponse>
    {
        private double _score = 5.0;
        private string _sentiment = "Positive";
        private int _request_count = 1;
        private int _request_limit = 2;

        public override SentimentResponse AnInstance()
        {
            return new SentimentResponse
            {
                request_count = _request_count,
                request_limit = _request_limit,
                score = _score,
                sentiment = _sentiment
            };
        }

        public SentimentResponseBuilder WithScore(double score)
        {
            _score = score;
            return this;
        }
    }
}