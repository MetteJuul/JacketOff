using DataAccess.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccess.Interfaces {
    public interface IWardrobeControlRepository {
        Task<bool> DeleteByWardrobeControlID(int ID, SqlConnection connection = null);
        Task<IEnumerable<WardrobeControl>> GetAllWardrobeControls(SqlConnection connection = null);
        Task<WardrobeControl> GetWardrobeControlById(string ID, SqlConnection connection = null);
        Task<bool> UpdateCount(WardrobeControl wardrobeControl, SqlConnection connection = null);
    }
}