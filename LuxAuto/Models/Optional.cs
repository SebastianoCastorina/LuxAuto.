namespace LuxAuto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Optional")]
    public partial class Optional
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Optional()
        {
            OptionalAuto = new HashSet<OptionalAuto>();
        }

        [Key]
        public int idOptional { get; set; }
        [Display(Name = "Nome Optional")]
        public string NomeOptional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OptionalAuto> OptionalAuto { get; set; }
    }
}
