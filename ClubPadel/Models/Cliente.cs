using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubPadel.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string user { get; set; }
        [Required]
        public string password { get; set; }
    }
}
