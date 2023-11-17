namespace LuxAuto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Autovettura")]
    public partial class Autovettura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Autovettura()
        {
            Offerta = new HashSet<Offerta>();
            OptionalAuto = new HashSet<OptionalAuto>();
        }

        [Key]
        public int idAuto { get; set; }
        
        [Display(Name = "Modello")]
        public string NomeModello { get; set; }

        public string Foto { get; set; }
        
        [Display(Name = "Dati Di Base")]
        [Column(TypeName = "TEXT")]
        public string DatiBase { get; set; }

        public string Colore { get; set; }

        public string Chilometraggio { get; set; }
        [Display(Name = "Anno")]
        public string AnnoImmatricolazione { get; set; }

        public string Potenza { get; set; }

        public string Città { get; set; }

        public string Carburante { get; set; }

        [Column(TypeName = "money")]
        public decimal? Prezzo { get; set; }
        [Display(Name = "Specifiche Tecniche")]
        [Column(TypeName = "TEXT")]
        public string SpecificheTecniche { get; set; }
        [Display(Name = "Marchio")]
        public int? idMarchio { get; set; }
        
        public bool? HasAsta { get; set; }
        
        public bool? HasEpoca { get; set; }

        public string Foto1 { get; set; }

        public string Foto2 { get; set; }

        public string Foto3 { get; set; }

        public string Foto4 { get; set; }

        public string Foto5 { get; set; }

        public string Foto6 { get; set; }
        
        public bool? HasVenduta { get; set; }

        public List<string> CaroselloImages { get; set; }


        public virtual Marchio Marchio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Offerta> Offerta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OptionalAuto> OptionalAuto { get; set; }
    }
}
