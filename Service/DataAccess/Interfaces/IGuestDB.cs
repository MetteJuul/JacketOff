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
        int createGuest(Guest guest);
        List<Guest> getAllGuests();
        Guest getbyID(int iD);
        int updateGuest(Guest guest);
        bool deleteByID(int iD);
        List<Guest> getByGuest(int guestID);
    }
}
