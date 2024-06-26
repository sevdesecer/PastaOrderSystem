﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int TotalPrice { get; set; }
        public DateTime DateTime { get; set; }
    }
}