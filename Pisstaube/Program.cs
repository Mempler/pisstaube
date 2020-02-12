﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using dotenv.net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Org.BouncyCastle.Utilities.Net;
using osu.Framework.Logging;

namespace Pisstaube
{
    internal class Program
    {
        private static readonly CancellationTokenSource Cts = new CancellationTokenSource();
        
        private static async Task Main(string[] args)
        {
            if (Environment.GetEnvironmentVariable("IS_CONTAINER") != "true")
                DotEnv.Config();
            
            if (!Directory.Exists("./data"))
                Directory.CreateDirectory("data");

            var host = WebHost.CreateDefaultBuilder(args)
                .UseKestrel(opt =>
                {
                    opt.Limits.MaxRequestBodySize = null;
                    opt.Listen(IPAddress.Any, 5000);
                })
                .ConfigureServices(services => services.AddAutofac())
                .UseContentRoot(Path.Join(Directory.GetCurrentDirectory(), "data"))
                .UseStartup<Startup>()
                .UseShutdownTimeout(TimeSpan.FromSeconds(5))
                .Build();

            await host.RunAsync(Cts.Token);
        }
        
        private static void OnProcessExit(object sender, EventArgs e)
        {
            Logger.LogPrint("Killing everything..", LoggingTarget.Information, LogLevel.Important);
            Cts.Cancel();
        }
    }
}