namespace Engine.Objects.Implementations
{
    public partial class TestCommand
    {
        public override int Assert()
        {
            throw new NotImplementedException(
                @"
                This is a development version of the final product.
                Some of the expected functionality may not be implemented or not stable enough to be released.
                If you hitted this exception, please, contact to mjmorales.mcv+dev@gmail.com with the .side file that caused this crash.
                "
                );
        }
    }
}
