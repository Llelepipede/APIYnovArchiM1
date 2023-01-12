using System.ComponentModel.DataAnnotations.Schema;

namespace APIYnovArchiM1.Models
{
    public class TagActive
    {

        public int ID { get; set; }

        [ForeignKey("IDRace")]
        public int IDRace { get; set; }
        [ForeignKey("IDTag")]
        public int IDTag { get; set; }
        [ForeignKey("ISQuizz")]
        public int IDQuizz { get; set; }

        public int Order { get; set; }
    }
}
