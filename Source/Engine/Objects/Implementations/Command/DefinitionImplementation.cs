using Engine.Objects.Definitions.Abstracts;

namespace Engine.Objects.Implementations
{
    public partial class TestCommand : AbsCommand
    {
        public override string? Id { get; set; }
        public override string? Comment { get; set; }
        public override string? Command { get; set; }
        public override string? Description { get; set; }
        public override string? Target { get; set; }
        public override string? Value { get; set; }
        public override bool OpensWindow { get; set; }
        public override string? WindowHandleName { get; set; }
        public override int WindowTimeout { get; set; }
        public new List<string[]>? Targets { get; set; }
    }
}
