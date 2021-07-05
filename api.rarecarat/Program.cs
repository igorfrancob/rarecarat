using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.rarecarat
{
    public class Program
    {
        public static void Main( string[] args )
        {
            //Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Information()
            // .WriteTo.Debug( new RenderedCompactJsonFormatter() )
            //// .WriteTo.File( "logs.txt", rollingInterval: RollingInterval.Day )
            //.CreateLogger();

            try
            {
                Log.Information( "Starting Web Host" );
                CreateHostBuilder( args ).Build().Run();
            }
            catch ( Exception ex )
            {
                Log.Fatal( ex, "Host terminated unexpectedly" );
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder( string[] args ) =>
            Host.CreateDefaultBuilder( args )
                //.UseSerilog()
                .ConfigureWebHostDefaults( webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                } );

    }
}
