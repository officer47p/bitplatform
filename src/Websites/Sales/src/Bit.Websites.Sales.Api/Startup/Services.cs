﻿using System.IO.Compression;
using System.Net.Mail;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.ResponseCompression;
using Bit.Websites.Sales.Api.Services;
#if BlazorWebAssembly
using Microsoft.AspNetCore.Components;
using Bit.Websites.Sales.Web.Services.Implementations;
using Bit.Websites.Sales.Web.Services.Implementations;
#endif

namespace Bit.Websites.Sales.Api.Startup;

public static class Services
{
    public static void Add(IServiceCollection services, IWebHostEnvironment env, IConfiguration configuration)
    {
        // Services being registered here can get injected into controllers and services in Api project.

        var appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();

        services.AddSharedServices();

#if BlazorWebAssembly
        services.AddClientSharedServices();

        // In the Pre-Rendering mode, the configured HttpClient will use the access_token provided by the cookie in the request, so the pre-rendered content would be fitting for the current user.
        services.AddHttpClient("WebAssemblyPreRenderingHttpClient")
            .ConfigurePrimaryHttpMessageHandler<AppHttpClientHandler>()
            .ConfigureHttpClient((sp, httpClient) =>
            {
                NavigationManager navManager = sp.GetRequiredService<IHttpContextAccessor>().HttpContext!.RequestServices.GetRequiredService<NavigationManager>();
                httpClient.BaseAddress = new Uri($"{navManager.BaseUri}api/");
            });
        services.AddScoped<Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader>();

        services.AddScoped(sp =>
        {
            IHttpClientFactory httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
            return httpClientFactory.CreateClient("WebAssemblyPreRenderingHttpClient");
            // this is for pre rendering of blazor webassembly
            // for other usages of httpclient, for example calling 3rd party apis, either use services.AddHttpClient("NamedHttpClient") or services.AddHttpClient<TypedHttpClient>();
        });
        services.AddRazorPages();
        services.AddMvcCore();
#endif
        services.AddHttpClient<TelegramBotApiClient>();
        services.AddScoped<TelegramBotService>();
        services.AddCors();

        services
            .AddControllers()
            .AddOData(options => options.EnableQueryFeatures())
            .AddDataAnnotationsLocalization(options => options.DataAnnotationLocalizerProvider = StringLocalizerProvider.ProvideLocalizer)
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    throw new ResourceValidationException(context.ModelState.Select(ms => (ms.Key, ms.Value!.Errors.Select(e => new LocalizedString(e.ErrorMessage, e.ErrorMessage)).ToArray())).ToArray());
                };
            });

        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.All;
            options.ForwardedHostHeaderName = "X-Host";
        });

        services.AddResponseCaching();

        services.AddHttpContextAccessor();

        services.AddResponseCompression(opts =>
        {
            opts.EnableForHttps = true;
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" }).ToArray();
            opts.Providers.Add<BrotliCompressionProvider>();
            opts.Providers.Add<GzipCompressionProvider>();
        })
            .Configure<BrotliCompressionProviderOptions>(opt => opt.Level = CompressionLevel.Fastest)
            .Configure<GzipCompressionProviderOptions>(opt => opt.Level = CompressionLevel.Fastest);

        services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));

        services.AddScoped(sp => sp.GetRequiredService<IOptionsSnapshot<AppSettings>>().Value);

        services.AddEndpointsApiExplorer();

        services.AddAutoMapper(typeof(Program).Assembly);

        services.AddSwaggerGen();

        services.AddHealthChecks(env, configuration);
    }
}
