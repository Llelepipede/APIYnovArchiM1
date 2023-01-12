using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIYnovArchiM1.Models
{
    public class Quizz
    {
        public int ID { get; set; }

        public string Title { get; set; } = "";
        public string Question { get; set; } = "";

        [ForeignKey("choix")]
        public int IDChoice { get; set; } 

        [ForeignKey("text")]
        public int IDText { get; set; } 

    }
}
