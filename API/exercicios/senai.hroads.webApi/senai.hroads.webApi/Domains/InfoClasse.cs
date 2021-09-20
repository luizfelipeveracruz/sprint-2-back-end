using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    [Table("InfoClasse")]
    public class InfoClasse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int infoClasse { get; set; }

        public int idClasse { get; set; }

        [ForeignKey("idClasse")]
        public Classe classe { get; set; }

        public int idHabilidade { get; set; }

        [ForeignKey("idHabilidade")]
        public Habilidade habilidade { get; set; }

    }
}
