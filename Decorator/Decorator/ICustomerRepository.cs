using System.Threading.Tasks;

namespace Decorator
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(int id);
    }
}