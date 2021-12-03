using System;
using DataAccess;
using System.Collections.Generic;
using DataAccess.Model;

namespace API.DTOs.Converters {
    public static class DTOConverter {

        #region Reservation converter methods

        public static ReservationDTO ToDTO(this Reservation reservationDTOToConvert) {
            var reservationDTO = new ReservationDTO();
            reservationDTOToConvert.CopyPropertiesTo(reservationDTO);
            return reservationDTO;
        }

        public static Reservation FromDTO(this ReservationDTO reservationToConvert) {

            var reservation = new Reservation();
            reservationToConvert.CopyPropertiesTo(reservation);
            return reservation;
        }

        public static IEnumerable<ReservationDTO> ToDTOs(this IEnumerable<Reservation> reservationsToConvert) {

            foreach (var reservation in reservationsToConvert) {
                yield return reservation.ToDTO();
            }
        }

        public static IEnumerable<Reservation> FromDTOs(this IEnumerable<ReservationDTO> reservationDTOsToConvert) {

            foreach (var reservationDTO in reservationDTOsToConvert) {

                yield return reservationDTO.FromDTO();
            }
        }
        #endregion

        #region Wardrobe converter methods

        public static WardrobeDTO ToDTO(this Wardrobe wardrobeToConvert) {
            var wardrobeDTO = new WardrobeDTO();
            wardrobeToConvert.CopyPropertiesTo(wardrobeDTO);
            return wardrobeDTO;
        }


        public static Wardrobe FromDTO(this WardrobeDTO wardrobeDTOToConvert) {
            var wardrobe = new Wardrobe();
            wardrobeDTOToConvert.CopyPropertiesTo(wardrobe);
            return wardrobe;
        }

        #endregion

        #region WardrobeControl converter methods

        public static WardrobeControlDTO ToDTO(this WardrobeControl wardrobeControlToConvert) {
            var wardrobeControlDTO = new WardrobeControlDTO();
            wardrobeControlToConvert.CopyPropertiesTo(wardrobeControlDTO);
            return wardrobeControlDTO;
        }
        public static WardrobeControl FromDTO(this WardrobeControlDTO wardrobeControlDTOToConvert) {
            var wardrobeControl = new WardrobeControl();
            wardrobeControlDTOToConvert.CopyPropertiesTo(wardrobeControl);
            return wardrobeControl;
        }

        #endregion

    }
}
