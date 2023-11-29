using Engine.Objects.Definitions.Abstracts.TestingProject;

namespace Engine.Objects.Implementations
{
    public partial class DotSIDEImplementation : AbsTestingPoject
    {
        public override string? Id { get; set; }
        public override string? Name { get; set; }
        public override string? Version { get; set; }
        public override string? Url { get; set; }
        public new List<string>? Urls { get; set; }
        public new List<Test>? Tests { get; set; }
        public new List<Suite>? Suites { get; set; }
        //public new List<Plugin> Plugins { get; private set; }
    }
}
