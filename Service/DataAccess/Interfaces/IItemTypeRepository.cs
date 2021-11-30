using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces {
    public interface IItemTypeRepository {
        Task<IEnumerable<ItemType>> GetAllItemTypes();
        Task<ItemType> GetItemType(int id);
    }
}
