using System.Threading.Tasks;
using ChainOfResponsability.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace ChainOfResponsability
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<FirstRule>();
            services.AddScoped<SecondRule>();
            services.AddScoped<ThirdRule>();
            services.AddScoped<FourthRule>();
            var sp = services.BuildServiceProvider();

            var rule = sp.GetService<FirstRule>();
            rule
                .SetNext(sp.GetService<SecondRule>())
                .SetNext(sp.GetService<ThirdRule>())
                .SetNext(sp.GetService<FourthRule>());
            
            await rule.Process(new Context());
        }
    }
}