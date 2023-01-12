using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIYnovArchiM1.Models
{
    public class Race
    {
        public int ID { get; set; }

        [Required]
        public string? Name { get; set; }


        [Required]
        [ForeignKey("User")]
        public int IDUser { get; set; } = 0;
    }
}
