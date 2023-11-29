namespace Engine.Runners.TestingProject
{
    public abstract class AbsTestOrigin 
    {
        public abstract TestOrigins Origin { get; }
        public string Path { get; init; }
        public string User { get; init; }
        public string Password { get; init; }
    }
}
