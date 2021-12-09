using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace DataAccess.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItems(SqlConnection connection = null);
        Task<Item> GetItemByID(int ID, SqlConnection connection = null);
        Task<int> CreateItem(Item item, SqlConnection connection = null);
        Task<bool> DeleteByID(int ID, SqlConnection connection = null);
        Task<IEnumerable<ItemType>> GetAllItemTypes(SqlConnection connection = null);
        Task<ItemType> GetItemTypeByID(int ID, SqlConnection connection = null);
        Task<int> CreateItemType(ItemType itemType, SqlConnection connection = null);
        Task<bool> DeleteItemTypeByID(int ID, SqlConnection connection = null);
    }
}
