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
    
    public partial class DetallePrueba
    {
        public int IdDetallePrueba { get; set; }
        public Nullable<int> IdPrueba { get; set; }
        public string Pregunta { get; set; }
        public Nullable<int> OpcionUsuario { get; set; }
        public Nullable<int> OpcionCorrecta { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFinal { get; set; }
        public Nullable<bool> Correcta { get; set; }
    
        public virtual Pruebas Pruebas { get; set; }
    }
}