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
    
    public partial class desarrolladores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public desarrolladores()
        {
            this.juegos = new HashSet<juegos>();
        }
    
        public int desarrollador_id { get; set; }
        public System.DateTime desarrollador_fecha_fundacion { get; set; }
        public string desarrollador_razonsocial { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<juegos> juegos { get; set; }
    }
}
