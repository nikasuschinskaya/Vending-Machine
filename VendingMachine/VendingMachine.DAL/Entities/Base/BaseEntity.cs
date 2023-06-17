using System.ComponentModel.DataAnnotations;

namespace VendingMachine.DAL.Models.Entities.Base
{
    public abstract class BaseEntity
    {
        [Required]
        public int Id { get; set; }
    }
}