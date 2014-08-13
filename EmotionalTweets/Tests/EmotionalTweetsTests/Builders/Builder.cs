namespace EmotionalTweetsTests.Builders
{
    public abstract class Builder<TBuilder, TBuild> where TBuilder : new()
    {
        public abstract TBuild AnInstance();

        public static TBuilder Build { get { return new TBuilder();} }
    }
}