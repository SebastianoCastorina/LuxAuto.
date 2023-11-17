namespace LuxAuto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OptionalAuto")]
    public partial class OptionalAuto
    {
        [Key]
        public int idOptInAuto { get; set; }

        public int? idAuto { get; set; }

        public int? idOptional { get; set; }

        public virtual Autovettura Autovettura { get; set; }

        public virtual Optional Optional { get; set; }
    }
}
