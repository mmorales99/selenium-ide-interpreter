namespace Engine.Objects.Implementations
{
    public partial class TestCommand
    {
        public override int SetWindowSize()
        {
            try
            {
                IsDriverPresent();
                //if (!Configuration.MostrarBuscador) { return 1; }
                if (String.IsNullOrEmpty(Target)) { return 1; }
                (int x, int y) = Target.Split('x') switch { var arr => (Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1])) };
                driver.Manage().Window.Size = new System.Drawing.Size(x, y);
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
