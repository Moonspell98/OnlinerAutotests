using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace OnlinerAutotests.Services;

public class ConfiguratorService
{
    private static readonly Lazy<IConfiguration> s_configuration;

    public static IConfiguration Configuration => s_configuration.Value;

    public static string BaseUrl => Configuration[nameof(BaseUrl)];

    static ConfiguratorService()
    {
        s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json");

        var appSettingsFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

        foreach (var appSettingsFile in appSettingsFiles)
        {
            builder.AddJsonFile(appSettingsFile);
        }

        return builder.Build();
    }

}