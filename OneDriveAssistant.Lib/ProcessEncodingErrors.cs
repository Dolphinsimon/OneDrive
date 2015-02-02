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
        /// <returns></returns>
        public string[] GetRows(string filePath)
        {
                using (StreamReader read = new StreamReader(filePath, Encoding.UTF8))
                {
                    string[] error = read.ReadToEnd().Split('\n');
                    return error;
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
            string[] pathStrings = text.Split(nameSeparator,StringSplitOptions.None);
            return pathStrings;
        }
        /// <summary>
        /// Get the directory
        /// </summary>
        /// <param name="originalfilepath"></param>
        /// <returns></returns>
        public string FormatDirectory(string originalfilepath)
        {
            char[] directorySeparator = { '/' };
            string[] newDirectory = originalfilepath.Split(directorySeparator);
            string directory="";
            for (int i = 0; i < newDirectory.Length-1; ++i)
            {
                directory+="/"+ newDirectory[i];
            }
            return directory;
        }

    }
}
