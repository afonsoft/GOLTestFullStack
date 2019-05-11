using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOLTestFullStack.Api.Iinterface;
using GOLTestFullStack.Api.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GOLTestFullStack.Api.DependencyInjection
{
    public class UserNativeInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterRepositories(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();
        }

        
    }
}
