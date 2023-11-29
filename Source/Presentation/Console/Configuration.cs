using Microsoft.Extensions.Configuration;
using Engine.Adapters.Selenium.Support.WebDriver;

namespace TestFuncional
{
    public static class Configuration
    {
        private static IConfiguration _config = null;

        public static string? Url { get => _config["Url"]; }
        public static string? SeleniumTestsUrl { get => _config["SeleniumTestsUrl"]; }
        public static string? _StepsPerSeconds_string { get => _config["StepsPerSeconds"]; }
        public static int StepsPerSeconds 
        {
            get {
                if (int.TryParse(_StepsPerSeconds_string, out int steps)) 
                {
                    return steps *1000;
                }
                return 0;
            }
        }
        public static string? _Buscador_string { get => _config["Buscador"]; }
        public static WebDriverKinds Buscador { 
            get {
                WebDriverKinds b = WebDriverKinds.None;
                if (_config != null || !String.IsNullOrEmpty(_Buscador_string))
                {
                    WebDriverKindsHelper.TryParse(_Buscador_string, out b);
                }
                return b;
            }
        }
        public static string? _MostrarBuscador_string { get => _config["MostrarBuscador"]; }
        public static bool MostrarBuscador { 
            get => bool.TryParse(_MostrarBuscador_string, out bool mostrar) && mostrar;
        }

        public static string? Get(string key)
        {
            return _config[key];
        }

        public static void LoadConfiguration(string[] args) 
        {
            var path = Path.GetFullPath(Directory.GetCurrentDirectory());
            var envname = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (String.IsNullOrEmpty(envname))
            {
                envname = "production";
            }
            else
            {
                envname = envname.ToLower().Trim();
            }
            var cb = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(path, "appsettings.json"), true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .AddJsonFile(Path.Combine(path, $"appsettings.{envname}.json"), true);
            _config = cb.Build();
        }
    }
}
