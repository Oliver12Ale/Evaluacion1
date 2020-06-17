using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEC.MVC.Models
{
    public class NivelesModel
    {
        public NivelesModel()
        {
        }

        public int IdNivel { get; set; }
        [Required]
        public string Nivel { get; set; }
        [Required]
        public int CalificacionMin { get; set; }
        [Required]
        public int CalificacionMax { get; set; }
    }
}