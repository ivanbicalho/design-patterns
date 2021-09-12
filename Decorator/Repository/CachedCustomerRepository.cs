using System;
using System.Threading;
using System.Threading.Tasks;
using Decorator.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace Decorator.Repository
{
    public class CachedCustomerRepository : ICustomerRepository
    {
        private static readonly SemaphoreSlim _semaphore = new(1);
        private readonly ICustomerRepository _customerRepository;
        private readonly IMemoryCache _cache;

        public CachedCustomerRepository(ICustomerRepository customerRepository, IMemoryCache cache)
        {
            _customerRepository = customerRepository;
            _cache = cache;
        }

        public async Task<Customer> GetById(int id)
        {
            if (_cache.TryGetValue(id, out Customer customer))
                return customer;

            await _semaphore.WaitAsync();
            try
            {
                if (_cache.TryGetValue(id, out customer))
                    return customer;

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3));

                customer = await _customerRepository.GetById(id);

                _cache.Set(id, customer, cacheEntryOptions);

                return customer;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}