using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    [Table("Habilidades")]
    public class Habilidade
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idHabilidade { get; set; }

        [Column(TypeName ="varchar(40)")]
        [Required(ErrorMessage ="Nome da Habilidade é Obrigatorio")]
        public string nomeHabilidade { get; set; }

        public int idTipoHabilidade { get; set; }

        [ForeignKey("idTipoHabilidade")]
        public TipoHabilidade tipoHabilidade { get; set; }


    }
}
