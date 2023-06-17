﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendingMachine.DAL.Entities.Base;

namespace VendingMachine.DAL.Entities
{
    [Table("Drinks")]
    public class DrinkEntity : CountedEntity
    {
        [MaxLength(25)]
        [Required]
        public string Name { get; set; }


        [Required]
        public decimal Cost { get; set; }
    }
}