//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SEC.ENTITI
{
    using System;
    using System.Collections.Generic;
    
    public partial class Opciones
    {
        public int IdOpcion { get; set; }
        public int IdPregunta { get; set; }
        public string Opcion { get; set; }
        public bool EsCorrecta { get; set; }
        public bool Activo { get; set; }
    
        public virtual Preguntas Preguntas { get; set; }
    }
}
