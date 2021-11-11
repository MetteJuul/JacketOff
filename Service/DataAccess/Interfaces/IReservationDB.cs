using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess.Interfaces
{
    internal interface IReservationDB
    {
        int CreateReservation(Reservation reservation);
        List<Reservation> GetAllReservations();
        Reservation GetByID(int iD);
        int UpdateReservation(Reservation reservation);
        bool DeleteByID(int iD);
        List<Reservation> GetByGuest(int guestID);
        
    }
}
