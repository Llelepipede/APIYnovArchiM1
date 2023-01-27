using System.ComponentModel.DataAnnotations.Schema;

namespace APIYnovArchiM1.Models
{
    public class Tag
    {
        public int ID { get; set; }

        [ForeignKey("IDRace")]
        public int IDRace { get; set; }

        public string? QrcodeName { get; set; }

    }
}