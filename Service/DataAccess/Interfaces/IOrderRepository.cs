﻿
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    internal interface IOrderRepository
    {
        int CreateOrder(Order order);
        List<Order> GetAllOrders();
        Order GetByID(int iD);
        int UpdateOrder(Order order);
        bool DeleteByID(int iD);
    }
}