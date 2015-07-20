using System;
using System.IO;
using System.Text;

namespace OneDriveAssistant
{
    public class ProcessEncodingErrors
    {
        /// <summary>
        /// Get the total number of rows
        /// </summary>
        /// <param name="filePath">filepath</param>
        /// <returns>An array that contains every row.</returns>
        public string[] GetRows(string filePath)
        {
            using (var reader = new StreamReader(filePath, Encoding.UTF8))
            {
                return reader.ReadToEnd().Split('\n');
            } 
        }

        /// <summary>
        /// Split text to file names
        /// </summary>
        /// <param name="text">One line text in Encoding errors.txt</param>
        /// <returns>An array contains two elements:Original File Name & New File Name</returns>
        public string[] GetFileName(string text)
        {
            //text = "Original File Name  ->  New File Name";
            if (!text.Contains("->") || text.Contains("Original File Name  ->  New File Name")) return null;
            string[] nameSeparator = { " -> " };
            return text.Split(nameSeparator,StringSplitOptions.None);
        }
        /// <summary>
        /// Get the directory of Encoding errors.txt except itself.
        /// </summary>
        /// <param name="originalfilepath"></param>
        /// <returns></returns>
        public string FormatDirectory(string originalfilepath)
        {
            char[] directorySeparator = { '/' };
            var newDirectory = originalfilepath.Split(directorySeparator);
            var directory="";
            for (var i = 0; i < newDirectory.Length-1; ++i)
            {
                directory+="/"+ newDirectory[i];
            }
            return directory;
        }
        /// <summary>
        /// Get the file name of specified directory.
        /// </summary>
        /// <param name="sourcefilepath">The file path.</param>
        /// <returns>The file name.</returns>
        public string FormatFile(string sourcefilepath)
        {
            char[] directorySeparator = { '/' };
            var newDirectory = sourcefilepath.Split(directorySeparator);
            var directory=newDirectory[newDirectory.Length-1];
            return directory;
        }

        public string GetFullPath(string path, string relativePath)
        {
            return relativePath != null ? path + relativePath : null;
        }
    }
}
