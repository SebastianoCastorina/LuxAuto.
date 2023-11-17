namespace LuxAuto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Asta")]
    public partial class Asta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asta()
        {
            Offerta = new HashSet<Offerta>();
        }

        [Key]
        public int idAsta { get; set; }

        public int? idAuto { get; set; }
        [Display(Name = "Prezzo attuale")]
        public string UltimaOfferta { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "Data Chiusura Asta")]
        public DateTime? DataChiusuraAsta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Offerta> Offerta { get; set; }
        [Display(Name = "Prezzo di Partenza")]
        [Column(TypeName = "money")]
        public decimal? PrezzoBase { get; set; }

        public virtual Autovettura Autovettura { get; set; }

        public List<string> CaroselloImages { get; set; }
      
    }
}
