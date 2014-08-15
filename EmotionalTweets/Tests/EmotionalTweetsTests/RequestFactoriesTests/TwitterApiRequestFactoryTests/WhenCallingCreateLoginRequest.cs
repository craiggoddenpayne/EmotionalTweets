﻿using System.Net;
using EmotionalTweets.DataContracts.Twitter;
using EmotionalTweetsTests.Builders;
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

    public class WhenCallingCreateSearchTweetsRequest : TwitterApiRequestFactoryTest
    {
        private string _query;
        private TwitterAuthentication _twitterAuthorisation;
        private HttpWebRequest _result;

        [SetUp]
        public void Setup()
        {
            Initialise();

            _query = "some text";
            _twitterAuthorisation = TwitterAuthenticationBuilder.Build.AnInstance();

            _result = TwitterApiRequestFactory.CreateSearchTweetRequest(_query, _twitterAuthorisation);
        }

        [Test]
        public void ItShouldSetUrl()
        {
            Assert.That(_result.RequestUri.AbsoluteUri, Is.EqualTo("https://api.twitter.com/1.1/search/tweets.json?q=some+text"));
        }

        [Test]
        public void ItShouldSetMethod()
        {
            Assert.That(_result.Method, Is.EqualTo("GET"));
        }

        [Test]
        public void ItShouldSetAuthorisationHeaderWithSecretKey()
        {
            Assert.That(_result.Headers["Authorization"], Is.EqualTo("Bearer " + _twitterAuthorisation.access_token));
        }
    }
}