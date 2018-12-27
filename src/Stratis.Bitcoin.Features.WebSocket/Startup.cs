﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Stratis.Bitcoin.Features.WebSocket
{
    public class Startup
    {
        public static IServiceProvider Provider { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSignalR();

          //  services.AddCors(options => options.AddPolicy("CorsPolicy",
          //builder =>
          //{
          //    builder.AllowAnyMethod().AllowAnyHeader()
          //           .WithOrigins("http://localhost:55830")
          //           .AllowCredentials();
          //}));

            //ServiceProvider provider = services.BuildServiceProvider();

            // Hold on to the reference to the connectionManager
            //var connManager = provider.GetService(typeof(IConnectionManager)) as IConnectionManager;

            //services.AddSignalR(hubOptions =>
            //{
            //    hubOptions.EnableDetailedErrors = true;
            //    hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
            //});

            //services.AddAzureSignalR();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Provider = app.ApplicationServices;

            //todo: this currently always go to DefaultRoute
            var settings = (WebSocketSettings)app.ApplicationServices.GetService(typeof(WebSocketSettings));

            //app.UseCors("CorsPolicy");

            // TODO: ADD CORS, should be configureable with settings!
            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowCredentials());

            app.UseSignalR(routes =>
            {
                routes.MapHub<FullNodeHub>("/node");
            });


            //app.UseSignalR(routes =>
            //{
            //    routes.MapHub<FullNodeHub>("/");
            //});

            //app.UseSign
            //app.UseSignalR(routes => routes.MapHub<SignalRHub>($"/{settings?.HubRoute ?? SignalRSettings.DefaultSignalRHubRoute}"));
        }
    }
}
