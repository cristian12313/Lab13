//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    
    public partial class empleo1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empleo1()
        {
            this.empleado_empleo = new HashSet<empleado_empleo>();
        }
    
        public int codigo { get; set; }
        public string nombre { get; set; }
        public decimal salario_minimo { get; set; }
        public decimal salario_maximo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleado_empleo> empleado_empleo { get; set; }
    }
}