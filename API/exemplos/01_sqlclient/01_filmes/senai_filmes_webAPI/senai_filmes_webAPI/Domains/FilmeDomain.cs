using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) FILMES
    /// </summary>
    public class FilmeDomain
    {
        public int idFilme { get; set; }
        public int idGenero { get; set; }
        public string tituloFilme { get; set; }


    }
}
