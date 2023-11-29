using Engine.Objects.Definitions.Abstracts;

namespace Engine.Objects.Implementations
{
    public partial class Test : AbsTest
    {
        public override string? Id { get; set; }
        public override string? Name { get; set; }
        public override string? Description { get; set; }
        public override string? ParentSuite { get; set; }
        public new List<TestCommand>? Commands { get; set; }

        public new Dictionary<string, object>? TestVars { get; set; }
    }
}
