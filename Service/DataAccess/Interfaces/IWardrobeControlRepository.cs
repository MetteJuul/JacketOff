using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces {
    public interface IWardrobeControlRepository {

        Task<WardrobeControl> GetWardrobeControlById(string ID);

        Task<bool> UpdateCount(WardrobeControl wardrobeControl);

    }
}
