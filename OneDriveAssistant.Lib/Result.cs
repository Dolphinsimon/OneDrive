using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDriveAssistant
{
    public class Result
    {
        public bool Success { get; set; }
        public string FileName { get; set; }
        public Exception Error { get; set; }
    }
}
