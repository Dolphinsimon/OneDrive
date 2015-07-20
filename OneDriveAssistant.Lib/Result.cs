using System;

namespace OneDriveAssistant
{
    public class Result
    {
        public bool Success { get; set; }
        public string FileName { get; set; }
        public Exception Error { get; set; }
    }
}
