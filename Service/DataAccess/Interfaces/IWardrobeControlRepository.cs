using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces {
    public interface IWardrobeControlRepository {

        Task<IEnumerable<WardrobeControl>> GetWardrobeControlsById(string ID);

        Task<bool> UpdateCount(WardrobeControl wardrobeControl);

    }
}
