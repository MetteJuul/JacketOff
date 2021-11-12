using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataAccess.Interfaces
{
    internal interface IGuestDB
    {
        int CreateGuest(Guest guest);
        List<Guest> GetAllGuests();
        Guest GetbyID(int iD);
        int UpdateGuest(Guest guest);
        bool DeleteByID(int iD);
    }
}
