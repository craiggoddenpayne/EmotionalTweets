
using EmotionalTweets.ServiceAdapters;
using NUnit.Framework;

namespace EmotionalTweetsTests.ServiceAdapterTests.TwitterApiAdapterTests
{
    public abstract class TwitterServiceAdapterTests
    {
        public ITwitterApiAdapter TwitterApiAdapter { get; set; }

        public void Initialise()
        {
            TwitterApiAdapter = new TwitterApiAdapter();
        }
    }

    [TestFixture]
    public class WhenCallingLogin : TwitterServiceAdapterTests
    {
        [SetUp]
        public void Setup()
        {
            Initialise();
        }

        [Test]
        public void ItShouldPass()
        {
            Assert.Pass();
        }
    }
}