using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace RegisterDocuments.Models
{

    public class Documents
    {

        public int Id { get; set; }

        public int code { get; set; }

        public string title { get; set; }

        public string category { get; set; }

        public string process { get; set; }

        public List<Process> processList { get; set; }

        public IFormFile postedFiles { get; set; }

        public string file { get; set; }
    }
}