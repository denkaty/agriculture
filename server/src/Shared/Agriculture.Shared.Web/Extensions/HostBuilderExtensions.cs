﻿using Microsoft.Extensions.Hosting;
using Serilog;

namespace Agriculture.Shared.Web.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddSerilog(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            return hostBuilder;
        }
    }
}
