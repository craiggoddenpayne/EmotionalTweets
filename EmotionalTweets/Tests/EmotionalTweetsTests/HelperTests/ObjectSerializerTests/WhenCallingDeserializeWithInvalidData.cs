using System;
using NUnit.Framework;

namespace EmotionalTweetsTests.HelperTests.ObjectSerializerTests
{
    [TestFixture]
    public class WhenCallingDeserializeWithInvalidData : ObjectSerializerTest
    {
        private Exception _exception;

        class MockClass
        {
            public int Number { get; set; }
            public string Text { get; set; }
        }

        [SetUp]
        public void Setup()
        {
            Initialise();

            try
            {
                ObjectSerializer.DeserializeJson<MockClass>("ssa;flmas;lfmas;lfm");
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Test]
        public void ItShouldThrowExceptionWithMessage()
        {
            Assert.That(_exception.Message, Is.EqualTo("Unexpected character encountered while parsing value: s. Path '', line 0, position 0."));
        }
    }
}