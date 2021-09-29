using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace RegisterDocuments.Models
{

    public class Documents
    {

        public int Id { get; set; }

        public int codigo { get; set; }

        public string titulo { get; set; }

        public string categoria { get; set; }

        public string processo { get; set; }

        public List<Processo> processos { get; set; }

        public IFormFile postedFiles { get; set; }

        public string file { get; set; }
    }
}