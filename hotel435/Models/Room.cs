using System.ComponentModel.DataAnnotations;

namespace hotel435.Models
{
    public class Room
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Beds { get; set; }
        [Required]
        public int GuestsAllowed { get; set; }

        //NOTE: Possible property to house Reservation info?
    }
}