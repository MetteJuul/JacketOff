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
        int createReservation(Reservation reservation);
        List<Reservation> getAllReservations();
        Reservation getByID(int iD);
        int updateReservation(Reservation reservation);
        bool deleteByID(int iD);
        List<Reservation> getByGuest(int guestID);
        
    }
}
