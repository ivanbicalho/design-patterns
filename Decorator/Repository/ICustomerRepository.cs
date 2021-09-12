using System.Threading.Tasks;
using Decorator.Domain;

namespace Decorator.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(int id);
    }
}