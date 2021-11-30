using System;
using DataAccess;
using System.Collections.Generic;

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

        public static WardrobeDTO ToDTO(this Wardrobe wardrobeDTOToConvert) {
            var wardrobeDTO = new WardrobeDTO();
            wardrobeDTOToConvert.CopyPropertiesTo(wardrobeDTO);
            return wardrobeDTO;
        }

        public static Wardrobe FromDTO(this WardrobeDTO wardrobeToConvert) {

            var wardrobe = new Wardrobe();
            wardrobeToConvert.CopyPropertiesTo(wardrobe);
            return wardrobe;
        }

        #endregion

    }
}
