using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIYnovArchiM1.Models
{
    public class Event
    {
        public int ID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int IDUser { get; set; }

        [Required]
        [ForeignKey("Race")]
        public int IDRace { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsLudique { get; set; }

    }
}
