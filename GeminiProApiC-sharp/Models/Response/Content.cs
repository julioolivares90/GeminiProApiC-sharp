using GeminiProApiC_sharp.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiProApiC_sharp.Models.Response
{
    public class Content
    {
        public List<Part> parts { get; set; }
        public string role { get; set; }
    }
}
