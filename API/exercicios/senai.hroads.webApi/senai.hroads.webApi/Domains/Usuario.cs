using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuarios { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        public string email { get; set; }


        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "A senha é obrigatório")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A senha do usuario deve contem de 5 a 30 carecteres")]
        public string senha { get; set; }

        public int idTipoUsuario { get; set; }

        [ForeignKey("idTipoUsuario")]
        public TipoUsuario tipoUsuario { get; set; }

    }
}
