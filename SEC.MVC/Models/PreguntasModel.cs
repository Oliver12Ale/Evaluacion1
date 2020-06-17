using SEC.ENTITI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SEC.MVC.Models
{
    public class PreguntasModel
    {
        public PreguntasModel()
        {
        }

        public int IdPregunta { get; set; }
        [Required]

        public int IdTecnologia { get; set; }
        [Display(Name ="Pregunta")]
        [Required]
        public string NombrePregunta { get; set; }
        [Required]
        public bool Activo { get; set; }

        public virtual Tecnologias Tecnologias { get; set; }

        public List<Opciones> Opciones { get; set; }
    }
}