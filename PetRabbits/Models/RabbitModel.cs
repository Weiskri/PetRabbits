using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetRabbits.Models
{
    public class RabbitModel
    {
        [Key]
        public int RabbitID { get; set; }
        public string RabbitName { get; set; }
        public int RabbitAge { get; set; }
        public string RabbitBreed { get; set; }
        public bool IsNeutered { get; set; }
    }
}