using System.Collections.Generic;

namespace TesteCadastro.Models
{

    public class Documents
    {

        public int codigo { get; set; }

        public string titulo { get; set; }

        public string categoria { get; set; }

        public string processo { get; set; }

        public List<Processo> processos { get; set; }
    }
}