using System.Threading.Tasks;

namespace DataAccess.Services {
    public interface IOrderService {
        Task<int> CreateOrder(Order order);
    }
}