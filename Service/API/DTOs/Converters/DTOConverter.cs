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

        #region ItemType
        public static ItemTypeDTO ItemTypeToDTO(this ItemType itemTypeDTOToConvert)
        {
            var itemTypeDTO = new ItemTypeDTO();
            itemTypeDTOToConvert.CopyPropertiesTo(itemTypeDTO);
            return itemTypeDTO;
        }

        public static IEnumerable<ItemTypeDTO> ItemTypeToDTOs(this IEnumerable<ItemType> ItemTypeToConvert)
        {

            foreach (var itemType in ItemTypeToConvert)
            {
                yield return itemType.ItemTypeToDTO();
            }
        }

        #endregion

        #region Item
        public static ItemDTO ToDTO(this Item itemToConvert) {
            var itemDTO = new ItemDTO();
            itemToConvert.CopyPropertiesTo(itemDTO);
            return itemDTO;
        }

        public static Item FromDTO(this ItemDTO itemDTOToConvert) {
            var item = new Item();
            itemDTOToConvert.CopyPropertiesTo(item);
            return item;
        }
        #endregion

        #region Guest
        public static GuestDTO ToDTO(this Guest guestToConvert) {
            var guestDTO = new GuestDTO();
            guestToConvert.CopyPropertiesTo(guestDTO);
            return guestDTO;
        }

        public static Guest FromDTO(this GuestDTO guestDTOToConvert) {
            var guest = new Guest();
            guestDTOToConvert.CopyPropertiesTo(guest);
            return guest;
        }
        #endregion

        #region Order
        public static OrderDTO ToDTO(this Order orderToConvert) {
            var orderDTO = new OrderDTO();
            orderToConvert.CopyPropertiesTo(orderDTO);
            return orderDTO;
        }

        public static Order FromDTO(this OrderDTO orderDTOToConvert) {
            var order = new Order();
            orderDTOToConvert.CopyPropertiesTo(order);
            return order;
        }
        #endregion

    }
}
