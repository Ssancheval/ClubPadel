using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubPadel.Models
{
    public class TablaPrueba
    {
        [Key]
        public int? Id { get; set; }
        public string Nombre { get;set; }
        public string Estado { get; set; }
    }
}
