namespace LuxAuto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Offerta")]
    public partial class Offerta
    {
        [Key]
        public int idOfferta { get; set; }

        [Column(TypeName = "money")]
        public decimal? OffertaFatta { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataOfferta { get; set; }

        public int? idUser { get; set; }

        public int? idAuto { get; set; }

        public int? idAsta { get; set; }

        public virtual Asta Asta { get; set; }

        public virtual Autovettura Autovettura { get; set; }

        public virtual User User { get; set; }
    }
}
