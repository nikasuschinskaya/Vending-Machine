using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendingMachine.BLL.Models
{
    [Table("Admins")]
    public class Admin
    {
        [Key]
        [Required]
        public int AdminId { get; set; }


        [MinLength(3), MaxLength(30)]
        [Required]
        public string Login { get; set; }


        [MinLength(5), MaxLength(40)]
        [Required]
        public string Password { get; set; }
    }
}
