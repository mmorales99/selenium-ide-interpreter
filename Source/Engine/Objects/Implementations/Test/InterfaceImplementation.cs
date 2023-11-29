using OpenQA.Selenium;

namespace Engine.Objects.Implementations
{
    public partial class Test
    {
        public override void Run(IWebDriver? driver)
        {
            TestVars = new Dictionary<string, object>();
            if (Commands is null) return;
            foreach (TestCommand command in Commands)
            {
                Console.WriteLine($"Ejecutando comando: {ParentSuite}-{Name} ({Id}){command.Id} {command.Command}");
                switch (command.Execute(driver, TestVars))
                {
                    case 0:
                        Console.WriteLine($"Ejecutado comando CON EXITO: {ParentSuite}-{Name} ({Id}){command.Id} {command.Command}");
                        break;
                    case 1:
                        Console.WriteLine($"Comando ignorado: {ParentSuite}-{Name} ({Id}){command.Id} {command.Command}");
                        break;
                    default:
                        Console.WriteLine($"Error durante la ejecución del comando: {ParentSuite}-{Name} ({Id}){command.Id} {command.Command}");
                        return;
                }
                //Thread.Sleep(Configuration.StepsPerSeconds);
            }
        }
        public override void Dispose()
        {
            this.TestVars?.Clear();
            this.TestVars = null;

            foreach (var c in this.Commands) { c.Dispose(); }
            this.Commands?.Clear();
            this.Commands = null;
        }
    }
}
