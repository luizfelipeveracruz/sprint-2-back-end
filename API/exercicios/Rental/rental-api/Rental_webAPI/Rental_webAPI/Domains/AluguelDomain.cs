using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_webAPI.Domains
{
    public class AluguelDomain
    {
        /// <summary>
        /// Classe que representa a entidade (tabela) ALUGUEL
        /// </summary>
        public int idAluguel { get; set; }
        public int idVeiculo { get; set; }
        public int idCliente { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
