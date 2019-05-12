using System;
using System.Collections.Generic;
using GOLTestFullStack.Api.Context;
using GOLTestFullStack.Api.Entity;
using GOLTestFullStack.Api.Repository;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GOLTestFullStack.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

         
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
