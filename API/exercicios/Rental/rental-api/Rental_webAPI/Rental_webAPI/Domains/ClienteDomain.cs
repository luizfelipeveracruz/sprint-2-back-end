using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_webAPI.Domains
{ 
    /// <summary>
    /// Classe que representa a entidade (tabela) CLIENTE
    /// </summary>
    public class ClienteDomain
    {
        public int idCliente { get; set; }
        public string primeiroNome { get; set; }
        public string sobreNome { get; set; }

    }
}
