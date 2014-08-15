using NUnit.Framework;

namespace EmotionalTweetsTests.HelperTests.ObjectSerializerTests
{
    [TestFixture]
    public class WhenCallingDeserialize : ObjectSerializerTest
    {
        private MockClass _result;

        class MockClass
        {
            public int Number { get; set; }
            public string Text { get; set; }
        }

        [SetUp]
        public void Setup()
        {
            Initialise();

            _result = ObjectSerializer.DeserializeJson<MockClass>("{ Number: 1, Text: \"SomeValue\" }");
        }

        [Test]
        public void ItShouldDeserialiseCorrectly()
        {
            Assert.That(_result.Number, Is.EqualTo(1));
            Assert.That(_result.Text, Is.EqualTo("SomeValue"));
        }
    }
}