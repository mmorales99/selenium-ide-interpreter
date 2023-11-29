using OpenQA.Selenium;
using System.Reflection;

namespace Engine.Objects.Implementations
{
    public partial class TestCommand
    {
        private static MethodInfo[] myMethods = null;
        private static MethodInfo GetMethod(string methodName)
        {
            if (myMethods is null)
            {
                var type = typeof(TestCommand);
                myMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(x => x.ReturnType == typeof(int) && x.DeclaringType == type).ToArray();
            }
            var method = myMethods.Where(x => x.Name.ToLower() == methodName.ToLower())?.First();
            return method;
        }

        private IWebDriver? driver;
        private void IsDriverPresent()
        {
            if (driver is null) { throw new ArgumentNullException("El Web Driver se ha encontrado nulo en medio de una operación de selenium. Revise la traza."); }
        }
        private void IsVarsPresent(IDictionary<string, object> vars)
        {
            if (vars is null) { throw new ArgumentNullException("Se ha intentado realizar una operación con variables no inicializadas"); }
        }
    }
}
