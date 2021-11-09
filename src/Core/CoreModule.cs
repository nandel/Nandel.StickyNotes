using Microsoft.Extensions.DependencyInjection;
using Nandel.Modules;
using Nandel.StikyNotes.Core.Services;
using Nandel.StikyNotes.Core.Specifications;

namespace Nandel.StikyNotes.Core
{
    public class CoreModule : IModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // services
            services
                .AddTransient(typeof(IValidator<>), typeof(Validator<>))
                .AddScoped<IUserContext, UserContext>()
                ;
            
            // specs
            services
                .AddTransient(typeof(ISpecification<>), typeof(MediaKeyShouldBeUniqueSpecification<>))
                .AddTransient(typeof(ISpecification<>), typeof(MediaKeyIsRequiredSpecification<>))
                ;
        }
    }
}