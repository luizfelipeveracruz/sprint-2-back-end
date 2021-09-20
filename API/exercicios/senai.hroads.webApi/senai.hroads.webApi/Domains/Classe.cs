using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    [Table("Classes")]
    public class Classe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idClasse { get; set; }


        [Column(TypeName ="varchar(150)")]
        [Required(ErrorMessage = "O nome da classe é obrigatorio")]
        public string nomeClasse { get; set; }
    }
}
