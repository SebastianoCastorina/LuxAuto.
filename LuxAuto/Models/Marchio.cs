namespace LuxAuto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Marchio")]
    public partial class Marchio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Marchio()
        {
            Autovettura = new HashSet<Autovettura>();
        }

        [Key]
        public int idMarchio { get; set; }

        



        [Display(Name = "Nome Casa Costruttrice")]
        [StringLength(50)]
        public string NomeMarchio { get; set; }

        public string Logo { get; set; }

        [Display(Name = "Breve Storia")]
        [Column(TypeName = "TEXT")]
        
        public string BreveStoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autovettura> Autovettura { get; set; }
    }
}
