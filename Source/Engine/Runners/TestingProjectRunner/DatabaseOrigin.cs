namespace Engine.Runners.TestingProject
{
    public class DatabaseOrigin : AbsTestOrigin
    {
        public override TestOrigins Origin { get => TestOrigins.Database; }
        public string Query { get; init; }
        public System.Data.Common.DbConnection DbDescripr { get; init; }
    }
}
