using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel435.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Beds { get; set; }
        [Required]
        public int GuestsAllowed { get; set; }

    }
}