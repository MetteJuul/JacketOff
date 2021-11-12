using DataAccess;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers {
    
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase {

        ReservationDB _reservationDB;

        public ReservationsController(ReservationDB reservationDB) {
            _reservationDB = reservationDB;
        }

        //GET: api/reservations/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetByID(int iD) {
            var reservation = await _reservationDB.GetByID(iD);
            if(reservation == null) { return NotFound(); } 
            else { return Ok(reservation); }
        }


        ////GET: api/reservations
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ReservationDB>>> GetByID([FromQuery] int reservationID) {
        //    IEnumerable<Reservation> reservations = null;
        //    if (reservationID > 0) { 
        //        reservations = new List<Reservation>() { await _reservationDB.GetByID(reservationID) 
        //        }; 
        //    } else {
        //        reservations = await _reservationDB.GetAllReservations();
        //    }
        //    return Ok(reservations);
        //}

        //// GET: api/<ReservationsController>
        //[HttpGet]
        //public IEnumerable<string> Get() {
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ReservationsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id) {
        //    return "value";
        //}

        //// POST api/<ReservationsController>
        //[HttpPost]
        //public void Post([FromBody] string value) {
        //}

        //// PUT api/<ReservationsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value) {
        //}

        //// DELETE api/<ReservationsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id) {
        //}
    }
}
