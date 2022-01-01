using APIClient.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsumerWebClient.Models {
    public class ReservationViewModel {
        private DateTime _onlyDate;
        private DateTime _onlyTime;
        private int _amountOfTests;

        public ReservationDTO Reservation { get; set; }
        public IEnumerable<ItemTypeDTO> ItemTypes { get; set; }

        //Tilføjet efter aflevering
        //Indsamler tidspunkt for ankomst separat
        //fra datoen, for at gøre det nemmere at arbejde
        //med wardrobe control i systemet

        //TODO Opret validering af tidspunkter
        [DataType(DataType.Time)]
        [Required]
        public DateTime OnlyTime {
            get {
                return _onlyTime;
            }
            set {
                _onlyTime = value;
            }
        }

        //Tilføjet efter aflevering
        //Indsamler datoen for reservationen separat
        //fra ankomsttidspunkt, for at gøre det nemmere at arbejde
        //med wardrobe control i systemet

        //TODO Fix validering af dato range
        [DataType(DataType.Date)]
        [Required]
        public DateTime OnlyDate {
            get {
                return _onlyDate;
            }
            set {
                _onlyDate = value;
                var timeOfDay = _onlyTime.TimeOfDay;

                ////Alternativ til dato tjek i API'en. Her sikrer vi os at, datoen og tiden samles
                ////til en datetime variabel, der passer på den dato angivet, selv hvis ankomst
                ////sker efter midnat. Dette passer med systemets logik,
                ////men kan logikken kan være problematisk.
                Reservation.ArrivalTime = new DateTime(_onlyDate.Year, _onlyDate.Month, _onlyDate.Day, _onlyTime.Hour, _onlyTime.Minute, _onlyTime.Second);
            }
        }
    }
}
