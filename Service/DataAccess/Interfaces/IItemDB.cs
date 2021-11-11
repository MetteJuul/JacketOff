using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess.Interfaces
{
    internal interface IItemDB
    {
        int createItem(Item item);
        List<Item> getAllItems();
        Item GetItem(int iD);
        int updateItem(Item item);
        int deleteByID(int iD);
    }
}
