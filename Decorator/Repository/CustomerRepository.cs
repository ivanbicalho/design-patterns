using System.Threading.Tasks;
using Decorator.Domain;

namespace Decorator.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<Customer> GetById(int id)
        {
            return await Task.FromResult(
                new Customer
                {
                    Id = 1,
                    Name = "Ivan Bicalho"
                });
        }
    }
}