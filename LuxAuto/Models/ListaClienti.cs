using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LuxAuto.Models
{
    [Table("ListaClienti")]
    public class ListaClienti
    {
        [Key]
        public int idCliente {  get; set; }
        public string Nome { get; set; }

        public string Cognome { get; set; }
        
        public string Email { get; set; }

        public string NumeroTelefono { get; set; }

        [DataType(DataType.MultilineText)] 
        [UIHint("MultilineText")]
        public string Descrizione { get; set; }



    }
}