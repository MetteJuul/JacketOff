using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient.DTOs {
    public class GuestDTO {
        public int GuestId { get; set; }

        [Display(Name = "E-mailadresse")]
        [Required(ErrorMessage = "Det er nødvendigt med en e-mailmailadresse")]
        [EmailAddress(ErrorMessage = "Ugyldig e-mailadresse")]
        public string Email { get; set; }
    }
}
