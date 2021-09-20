﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTipoUsuario { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "Titulo Obrigatorio")]
        public string titulo { get; set; }


    }
}
