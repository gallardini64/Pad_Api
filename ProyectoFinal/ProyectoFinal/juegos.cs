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
    
    public partial class juegos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public juegos()
        {
            this.copias = new HashSet<copias>();
            this.existencias = new HashSet<existencias>();
            this.juego_etiqueta = new HashSet<juego_etiqueta>();
        }
    
        public int juego_id { get; set; }
        public string titulo { get; set; }
        public string imagen { get; set; }
        public System.DateTime fecha_lanzamiento { get; set; }
        public int genero_id { get; set; }
        public int desarrollador_id { get; set; }
        public int distribuidor_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<copias> copias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<existencias> existencias { get; set; }
        public virtual desarrolladores desarrolladores { get; set; }
        public virtual distribudores distribudores { get; set; }
        public virtual generos generos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<juego_etiqueta> juego_etiqueta { get; set; }
    }
}
