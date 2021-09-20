using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    [Table("Personagens")]
    public class Personagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPersonagem { get; set; }

        [Required(ErrorMessage ="O Nome do Personagem é Obrigatório")]
        public string nomePersonagem { get; set; }
    }
}
