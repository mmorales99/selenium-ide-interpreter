namespace Engine.Objects.Implementations
{
    public partial class TestCommand
    {
        public override int Open()
        {
            try 
            {
                // TODO: hacer host dinámico por configuracion
                //driver.Navigate().GoToUrl(Configuration.Url);
                driver.Navigate().GoToUrl(Target);
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
