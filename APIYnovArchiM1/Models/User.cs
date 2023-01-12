using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIYnovArchiM1.Models
{
    public class User
    {
        public int ID { get; set; }

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public string Email { get; set; } = "";

        public string UserName { get; set; } = "";
    }
}
