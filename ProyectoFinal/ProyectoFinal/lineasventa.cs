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
    
    public partial class lineasventa
    {
        public int lineaventa_id { get; set; }
        public decimal subtotal { get; set; }
        public int copias_id { get; set; }
        public int ventas_id { get; set; }
        public int cantidad { get; set; }
    
        public virtual copias copias { get; set; }
        public virtual ventas ventas { get; set; }
    }
}
