
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> CreateOrder(Order order, SqlConnection connection = null);
        Task<bool> DeleteByID(int ID, SqlConnection connection = null);
    }
}
