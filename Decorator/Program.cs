using System;
using System.Threading.Tasks;
using Decorator.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Decorator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<Program>();
            services.AddMemoryCache();

            // adding the repository first
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            
            // next, adding the decorator
            // will be delivered when ICustomerRepository is requested
            services.Decorate<ICustomerRepository, CachedCustomerRepository>();
            
            var sp = services.BuildServiceProvider();
            await sp.GetService<Program>()!.RunAsync();
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
                
                // LastGet will be refreshed every 3 seconds (cache time)
                Console.WriteLine($"Customer: {customer.Name}, LastGet: {customer.LastGet}");
                
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}