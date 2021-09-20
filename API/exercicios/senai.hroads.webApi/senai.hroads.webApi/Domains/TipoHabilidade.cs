using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    [Table("TipoHabilidade")]
    public class TipoHabilidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTipoHabilidade { get; set; }

        [Column(TypeName ="varchar(50)")]
        [Required(ErrorMessage ="O Tipo de habilidade precisa de um nome")]
        public string nomeTipoHabilidade { get; set; }
    }
}
