using System.ComponentModel.DataAnnotations;

namespace VendingMachine.DAL.Models.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; }
    }
}