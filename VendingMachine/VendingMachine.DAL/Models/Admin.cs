using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendingMachine.DAL.Models.Entities.Base;

namespace VendingMachine.DAL.Models
{
    [Table("Admins")]
    public class Admin : BaseEntity
    {
        [MinLength(3), MaxLength(30)]
        [Required]
        public string Login { get; set; }


        [MinLength(5), MaxLength(40)]
        [Required]
        public string Password { get; set; }
    }
}
