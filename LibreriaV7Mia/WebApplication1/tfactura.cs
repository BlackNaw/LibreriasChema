//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Libreria_V6
{
    using System;
    using System.Collections.Generic;
    
    public partial class tfactura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tfactura()
        {
            this.tlineafactura = new HashSet<tlineafactura>();
        }
    
        public string CodFactura { get; set; }
        public string Cliente { get; set; }
        public string FechaFactura { get; set; }
        public string Borrado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tlineafactura> tlineafactura { get; set; }
    }
}
