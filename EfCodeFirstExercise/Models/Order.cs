﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCodeFirstExercise.Models
{
    public class Order
    {
        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "decimal (12,2)")]
        public decimal Total { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } // virtual is when it wont be in the database, only in the runtime

        //line 18-19 are for fk

        public Order()
        {

        }
    }
}
