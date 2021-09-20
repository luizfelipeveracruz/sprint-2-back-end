using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) VEICULO
    /// </summary>
    public class VeiculoDomain
    {
        public int idVeiculo { get; set; }
        public int idEmpresa { get; set; }
        public int idModelo { get; set; }
        public string PLACA { get; set; }

        public EmpresaDomain Empresa { get; set; }
        public ModeloDomain Modelo { get; set; }

    }
}
