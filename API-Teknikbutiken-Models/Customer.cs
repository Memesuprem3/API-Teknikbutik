﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Teknikbutiken_Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(25)] 
        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }    
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        //One to Many Realation
        
        public ICollection<Order> Order { get; set; }
    }
}
