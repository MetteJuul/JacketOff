using System;
using DataAccess;
using System.Collections.Generic;

namespace API.DTOs.Converters {
    public static class DTOConverter {

        //Reservation
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

        //ItemType
        public static ItemTypeDTO ItemTypeToDTO(this ItemType itemTypeToConvert) {
            var itemTypeDTO = new ItemTypeDTO();
            itemTypeToConvert.CopyPropertiesTo(itemTypeDTO);
            return itemTypeDTO;
        }


        public static ItemType ItemTypeFromDTO(this ItemTypeDTO itemTypeDTOToConvert) {

            var itemType = new ItemType();
            itemTypeDTOToConvert.CopyPropertiesTo(itemType);
            return itemType;
        }

        public static IEnumerable<ItemTypeDTO> ItemTypesToDTOs(this IEnumerable<ItemType> itemTypesToConvert) {

            foreach (var itemType in itemTypesToConvert) {
                yield return itemType.ItemTypeToDTO();
            }
        }

        public static IEnumerable<ItemType> ItemTypesFromDTOs(this IEnumerable<ItemTypeDTO> itemTypeDTOsToConvert) {

            foreach (var itemTypeDTO in itemTypeDTOsToConvert) {
                yield return itemTypeDTO.ItemTypeFromDTO();
            }
        }
    }
}
