//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinal
{
    using System;
    using System.Collections.Generic;
    
    public partial class existencias
    {
        public int existencia_id { get; set; }
        public decimal existencia_cantidad { get; set; }
        public decimal existencia_precio { get; set; }
        public int juego_id { get; set; }
    
        public virtual juegos juegos { get; set; }
    }
}
