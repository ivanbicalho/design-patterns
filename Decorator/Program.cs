using System;
using System.IO;
using System.Threading.Tasks;
using Decorator.Repository;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Decorator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<Program>();
            services.AddMemoryCache();

            // adding first the repository
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            
            // next, adding the decorator
            // will be delivered when ICustomerRepository is requested
            services.Decorate<ICustomerRepository, CachedCustomerRepository>();
            
            var serviceProvider = services.BuildServiceProvider();
            await serviceProvider.GetService<Program>()!.RunAsync();
        }
        
        private readonly ICustomerRepository _customerRepository;

        public Program(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                var customer = await _customerRepository.GetById(1);
                
                Console.WriteLine($"Customer: {customer.Name}, LastGet: {customer.LastGet}");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}