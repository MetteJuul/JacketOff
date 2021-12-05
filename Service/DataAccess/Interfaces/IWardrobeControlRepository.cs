using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces {
    public interface IWardrobeControlRepository {
        Task<bool> AddCount(long bigRowID, int count);
        Task<int> GetWardrobeControlCount(string ID);
        Task<IEnumerable<WardrobeControl>> GetWardrobeControlsById(string ID);
        Task<WardrobeControl> GetWardrobeControlById(string ID);
        Task<bool> SubtractCount(long bigRowID, int count);
    }
}
