using System.Net;
using NUnit.Framework;

namespace EmotionalTweetsTests.RequestFactoriesTests.TwitterApiRequestFactoryTests
{
    public class WhenCallingCreateLoginRequest : TwitterApiRequestFactoryTest
    {
        private HttpWebRequest _result;

        [SetUp]
        public void Setup()
        {
            Initialise();
            _result = TwitterApiRequestFactory.CreateLoginRequest();
        }

        [Test]
        public void ItShouldSetUrl()
        {
            Assert.That(_result.RequestUri.AbsoluteUri, Is.EqualTo("https://api.twitter.com/oauth2/token"));
        }

        [Test]
        public void ItShouldSetMethodToPost()
        {
            Assert.That(_result.Method, Is.EqualTo("POST"));
        }

        [Test]
        public void ItShouldSetAuthorisationHeaderWithSecretKey()
        {
            Assert.That(_result.Headers["Authorization"], Is.EqualTo("Basic Z3BlajZFbXNackhmelhCS0o4ZU11Q2NwMTpIYWpIQml3Rm5QVTBaazVjQ1VVNk9jNkJaa29CTWZFV2h4Y2RVZ09vc3N5aE55N2FhRw=="));
        }

        [Test]
        public void ItShouldSetContentType()
        {
            Assert.That(_result.ContentType, Is.EqualTo("application/x-www-form-urlencoded"));
        }
    }
}