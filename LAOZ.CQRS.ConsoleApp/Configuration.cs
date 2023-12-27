using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;

namespace LAOZ.CQRS.ConsoleApp
{
    public class Configuration : IConfiguration
    {
        // Un diccionario para almacenar las configuraciones
        private readonly Dictionary<string, string> _configurations;

        public Configuration() { 
            //CreateHostBuilder().Build().Run();
        }
        public Configuration(Dictionary<string, string> configurations)
        {
            _configurations = configurations ?? throw new ArgumentNullException(nameof(configurations));
        }

        // Implementación de la interfaz IConfiguration

        public string this[string key]
        {
            get => _configurations.TryGetValue(key, out var value) ? value : null;
            set => _configurations[key] = value;
        }

        public IEnumerable<IConfigurationSection> GetChildren() => throw new NotImplementedException();

        public IChangeToken GetReloadToken() => throw new NotImplementedException();

        public IConfigurationSection GetSection(string key) => throw new NotImplementedException();
        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddEnvironmentVariables();
            }).ConfigureAppConfiguration(builder =>
            {
                builder.AddUserSecrets<Configuration>();
            });
        }
    }
}
