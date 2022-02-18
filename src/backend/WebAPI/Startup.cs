using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Model;
using Model.DataContext;
using Model.DataServices;
using Model.Messages;
using Service.Authentications;
using System.Reflection;
using WebAPI.Filters;
using WebAPI.Policies;

namespace WebAPI;

/// <summary>スタートアップ</summary>
public class Startup
{
    /// <summary>環境情報</summary>
    private readonly IWebHostEnvironment environment;

    /// <summary>設定情報</summary>
    private readonly IConfiguration configuration;

    /// <summary>コンストラクタ</summary>
    /// <param name="environment">環境情報</param>
    /// <param name="configuration">設定情報</param>
    public Startup(IWebHostEnvironment environment, IConfiguration configuration)
    {
        this.environment = environment;
        this.configuration = configuration;
    }

    /// <summary>DIコンテナ設定</summary>
    /// <param name="services">サービスコレクション</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }).AddCookie(options =>
        {
            options.Events.OnRedirectToLogin = x =>
            {
                x.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.CompletedTask;
            };
            options.Events.OnRedirectToAccessDenied = x =>
            {
                x.Response.StatusCode = StatusCodes.Status403Forbidden;
                return Task.CompletedTask;
            };
            options.Events.OnRedirectToLogout = _ => Task.CompletedTask;
        });
        services.AddAuthorization(options =>
        {
            options.FallbackPolicy = options.DefaultPolicy;
            options.AddPolicy("AdministratorPolicy", policy => policy.Requirements.Add(new AdministratorRequirement()));
        });
        services.AddScoped<IAuthorizationHandler, AdministratorAuthorizationHandler>();

        if (environment.IsDevelopment())
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApp", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
                x.CustomSchemaIds(type => type.FullName);
                x.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

        services.AddMvc(options =>
        {
            options.EnableEndpointRouting = false;
            options.Filters.Add<LogWriteExceptionFilter>();
            options.Filters.Add<ResultServiceFilter>();
        });

        services.Configure<Config>(configuration);
        services.AddDbContext<SQLServerDataContext>();
        services.AddScoped<IDataContext, SQLServerDataContext>();
        services.AddScoped<IDataService, DataService>();
        services.AddScoped<IMessageGenerator, MessageGenerator>();

        services.AddScoped<LoginChecker>();
        services.AddScoped<LoginUserGetter>();
    }

    /// <summary>アプリケーション設定</summary>
    /// <param name="app">アプリケーションビルダ</param>
    /// <param name="env">環境情報</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI");
            });
        }
        else
        {
            app.UseHttpsRedirection();
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}