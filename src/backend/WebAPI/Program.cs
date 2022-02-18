namespace WebAPI;

/// <summary>�G���g���|�C���g���܂ރN���X</summary>
public class Program
{
    /// <summary>�G���g���|�C���g</summary>
    public static void Main()
    {
        CreateHostBuilder().Build().Run();
    }

    /// <summary>Host��������</summary>
    /// <returns>Host�r���_�[</returns>
    public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
#if DEBUG
                .UseEnvironment("Development")
#elif TEST
                .UseEnvironment("Staging")
#elif RELEASE
                .UseEnvironment("Production")
#endif
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
}