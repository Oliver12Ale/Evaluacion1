using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEC.MVC.Models
{
    public class TecnologiasModel
    {
        public TecnologiasModel()
        {
        }
        [Key]
        public int IdTecnologia { get; set; }

        [Required]
        public string NombreTec { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        public bool TecActiva { get; set; }
    }
}