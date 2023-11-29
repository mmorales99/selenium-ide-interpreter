using Engine.Objects.Definitions.Abstracts;

namespace Engine.Objects.Implementations
{
    public partial class Suite : AbsSuite
    {
        public override string? Id { get; set; }
        public override string? Name { get; set; }
        public override string? Description { get; set; }
        public override bool PersistSession { get; set; }
        public override bool Parallel { get; set; }
        public override int TimeOut { get; set; }
        public new List<string>? Tests { get; set; }
        public new List<Test>? TestsObjectList { get; set; }
    }
}
