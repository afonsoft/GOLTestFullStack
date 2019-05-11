using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOLTestFullStack.Api.Context;
using GOLTestFullStack.Api.Iinterface;
using GOLTestFullStack.Api.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GOLTestFullStack.Api.DependencyInjection
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            UserNativeInjection.RegisterServices(services);
            services.AddScoped<GolContext>();
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();  
        }
    }
}
