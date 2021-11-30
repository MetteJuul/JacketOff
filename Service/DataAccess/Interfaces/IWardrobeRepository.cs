using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IWardrobeRepository
    {
        Task<IEnumerable<Wardrobe>> GetAllWardrobes();
        Task<Wardrobe> GetWardrobeById(string ID);
        Task<bool> UpdateCount(Wardrobe wardrobe, int amountOfTotalItems);
    }
}
