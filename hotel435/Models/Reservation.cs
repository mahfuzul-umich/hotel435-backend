using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hotel435.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string ConfirmationNumber { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s-]*$",
            ErrorMessage = "First Name is required and should only contain letters or a hyphen")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s-]*$",
            ErrorMessage = "Last Name is required and should only contain letters or a hyphen")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        public DateTime? ActualCheckIn { get; set; } = null;
        public DateTime? ActualCheckOut { get; set; } = null;
        [Required] 
        public Decimal Price { get; set; }
        [Required]
        public string RoomId { get; set; }
        [Required]
        [RegularExpression(@"^\d{10,16}$",
            ErrorMessage = "Credit Card Numbers must be between 10-16 digits")]
        public string CreditCardNum { get; set; }
        [Required]
        public string ExpMonth { get; set; }
        [Required]
        public string ExpYear { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}$",
            ErrorMessage = "CVV must be 3 digits long")]
        public string Cvv { get; set; }
        //Address represents street name
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [RegularExpression(@"^\d+$",
            ErrorMessage = "Valid zip code required")]
        public string Zip { get; set; }
        [Required]
        public string State { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
