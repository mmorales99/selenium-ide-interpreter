namespace Engine.Objects.Implementations
{
    public partial class TestCommand
    {
        public override int SelectWindow(IDictionary<string, object> vars)
        {
            try
            {
                IsVarsPresent(vars);
                IsDriverPresent();
                var window = Target.Replace("handle=${", "").TrimEnd('}');
                driver.SwitchTo().Window(vars[window].ToString());
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR al ejecutar un comando del tipo: {Command}\n" +
                    $"Error: {ex.Message}");
                return -1;
            }
        }
    }
}
