//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prestamos.Lite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tipo_moneda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_moneda()
        {
            this.Prestamoes = new HashSet<Prestamo>();
        }
    
        public int id { get; set; }
        public string nombre_divisa { get; set; }
        public string abreviatura { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prestamo> Prestamoes { get; set; }
    }
}
