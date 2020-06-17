using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEC.MVC.Models
{
    public class UsuariosModel
    {
        public UsuariosModel()
        {
        }

        public int IdUsuario { get; set; }
        [Display(Name = "Login")]
        [Required]
        public string Usuario { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string Nombre { get; set; }
        [Display(Name = "Apellido P.")]
        [Required]
        public string ApPaterno { get; set; }
        [Display(Name = "Apellido M.")]
        [Required]
        public string ApMaterno { get; set; }
        [Required(ErrorMessage ="El campo email es obligatorio")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email no valido")]
        public string Email { get; set; }
        [Display(Name ="Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Display(Name = "Confirmar Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }



    }
}