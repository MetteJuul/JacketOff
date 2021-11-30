using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    internal interface IWardrobeRepository
    {
        Task<IEnumerable<Wardrobe>> GetAllWardrobes();
        Task<Wardrobe> GetWardrobeById(int ID);
        Task<bool> UpdateWardrobe(Wardrobe wardrobe);
    }
}
