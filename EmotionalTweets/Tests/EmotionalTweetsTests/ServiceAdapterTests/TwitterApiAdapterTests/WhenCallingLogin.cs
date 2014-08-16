using System.IO;
using System.Net;
using System.Threading.Tasks;
using EmotionalTweetsShared.DataContracts.Twitter;
using EmotionalTweetsTests.Builders;
using Moq;
using NUnit.Framework;

namespace EmotionalTweetsTests.ServiceAdapterTests.TwitterApiAdapterTests
{
    [TestFixture]
    public class WhenCallingLogin : TwitterServiceAdapterTests
    {
        private Mock<HttpWebRequest> _webRequest;
        private Stream _requestStream;
        private Mock<HttpWebResponse> _webResponse;
        private TwitterAuthentication _authenticationResult;
        private TwitterAuthentication _result;


        [SetUp]
        public void Setup()
        {
            Initialise();

            _webRequest = new Mock<HttpWebRequest>();
            TwitterApiRequestFactory
                .Setup(x => x.CreateLoginRequest())
                .Returns(_webRequest.Object);
        
            _requestStream = new MemoryStream();
            HttpWebRequestHelper
                .Setup(x => x.GetRequestStream(_webRequest.Object))
                .Returns(Task.FromResult(_requestStream));

            _webResponse = new Mock<HttpWebResponse>();
            HttpWebRequestHelper
                .Setup(x => x.GetResponse(_webRequest.Object))
                .Returns(Task.FromResult(_webResponse.Object));

            _authenticationResult = TwitterAuthenticationBuilder.Build.AnInstance();
            ObjectSerializer
                .Setup(x => x.DeserializeJson<TwitterAuthentication>(_webResponse.Object))
                .Returns(_authenticationResult);

            _result = TwitterApiAdapter.Login().Result;
        }

        [Test]
        public void ItShouldCreateARequest()
        {
            TwitterApiRequestFactory.Verify(x => x.CreateLoginRequest());
        }

        [Test]
        public void ItShouldGetRequestStream()
        {
            HttpWebRequestHelper.Verify(x => x.GetRequestStream(_webRequest.Object));
        }

        [Test]
        public void ItShouldGetWebResponse()
        {
            HttpWebRequestHelper.Verify(x => x.GetResponse(_webRequest.Object));
        }

        [Test]
        public void ItShouldWriteDataToRequestStream()
        {
            Assert.That(_requestStream.Length, Is.GreaterThan(0));
        }

        [Test]
        public void ItShouldDeserializeWebResponse()
        {
            ObjectSerializer.Verify(x => x.DeserializeJson<TwitterAuthentication>(_webResponse.Object));
        }

        [Test]
        public void ItShouldReturnResult()
        {
            Assert.That(_result, Is.SameAs(_authenticationResult));
        }
    }
}