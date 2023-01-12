using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIYnovArchiM1.Models
{
    public class QuizzChoice
    {
        public int ID { get; set; }

        public string? choice1 { get; set; }
        public string? choice2 { get; set; }
        public string? choice3 { get; set; }
        public string? choice4 { get; set; }

        [Required]
        public int GoodOne { get; set; }
    
     }
}
