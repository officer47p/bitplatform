﻿using Bit.Websites.Platform.Web;
using Bit.Websites.Platform.Web.Shared;
#if BlazorServer
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
#endif

namespace Bit.Websites.Platform.Web;

public partial class Program
{
#if BlazorServer
    public static WebApplication CreateHostBuilder(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddJsonStream(typeof(MainLayout).Assembly.GetManifestResourceStream("Bit.Websites.Platform.Web.appsettings.json")!);

        Startup.Services.Add(builder.Services, builder.Configuration);

        var app = builder.Build();

        Startup.Middlewares.Use(app, builder.Environment);

        return app;
    }
#endif
}
