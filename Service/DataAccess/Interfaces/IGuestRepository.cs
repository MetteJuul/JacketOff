using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Interfaces
{
    public interface IGuestRepository
    {
        Task<Guest> GetByEmail(string email, SqlConnection connection = null);
    }
}
