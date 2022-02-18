namespace WebAPI;

/// <summary>エントリポイントを含むクラス</summary>
public class Program
{
    /// <summary>エントリポイント</summary>
    public static void Main()
    {
        CreateHostBuilder().Build().Run();
    }

    /// <summary>Host生成処理</summary>
    /// <returns>Hostビルダー</returns>
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