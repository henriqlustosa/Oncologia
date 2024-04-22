using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serilog;
/// <summary>
/// Summary description for Global
/// </summary>

public class Global : HttpApplication
{
    protected void Application_Start(object sender, EventArgs e)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File(@"C:\MyLogs\myapp.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Information("Application Starting Up");
    }

    protected void Application_End(object sender, EventArgs e)
    {
        Log.Information("Application Shutting Down");
        Log.CloseAndFlush();
    }
}