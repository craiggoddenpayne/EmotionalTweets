using EmotionalTweets.Helpers;

namespace EmotionalTweetsTests.HelperTests.ObjectSerializerTests
{
    public abstract class ObjectSerializerTest 
    {
        public IObjectSerializer ObjectSerializer { get; set; }

        public void Initialise()
        {
            ObjectSerializer = new ObjectSerializer();
        }
    }
}