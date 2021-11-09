using Core.Services;
using Core.Specifications;
using Microsoft.Extensions.DependencyInjection;
using Nandel.Modules;

namespace Core
{
    public class CoreModule : IModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // services
            services
                .AddTransient(typeof(IValidator<>), typeof(Validator<>))
                ;
            
            // specs
            services
                .AddTransient(typeof(ISpecification<>), typeof(MediaKeyShouldBeUniqueSpecification<>))
                .AddTransient(typeof(ISpecification<>), typeof(MediaKeyIsRequiredSpecification<>))
                ;
        }
    }
}