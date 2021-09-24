using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace TesteCadastro.Models
{

    public class Documents
    {

        public int Id { get; set; }

        public int codigo { get; set; }

        public string titulo { get; set; }

        public string categoria { get; set; }

        public int processo { get; set; }

        public List<Processo> processos { get; set; }

        public IFormFile postedFiles { get; set; }

        public string file { get; set; }
    }
}