using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) MODELO
    /// </summary>
    public class ModeloDomain
    {
        public int idModelo { get; set; }
        public string nomeModelo { get; set; }
        public int idMarca { get; set; }

    }
}
