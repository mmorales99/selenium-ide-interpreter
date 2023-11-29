namespace Engine.Runners.TestingProject
{
    public class LiteralOrigin : AbsTestOrigin
    {
        public override TestOrigins Origin { get => TestOrigins.Literal; }
        public string Value { get; init; }
    }
}
