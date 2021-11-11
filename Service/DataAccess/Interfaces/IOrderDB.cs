
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    internal interface IOrdderDB
    {
        int createOrder(Order order);
        List<Order> getAllOrders();
        Order getByID(int iD);
        int updateOrder(Order order);
        bool deleteByID(int iD);
    }
}
