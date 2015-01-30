using System;
using System.IO;
using System.Linq;
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
        public int GetRows(string filePath)
        {
                using (StreamReader read = new StreamReader(filePath, Encoding.UTF8))
                {
                    return read.ReadToEnd().Split('\n').Length;
                } 
        }

        /// <summary>
        /// Get a line of the encoding errors.txt
        /// </summary>
        /// <param name="filepath">filepath of the encoding errors.txt</param>
        /// <param name="index">the index of line</param>
        /// <returns>One line in encoding errors.txt</returns>
        public string GetOneLine(string filepath, int index)
        {
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    if (sr.EndOfStream) return null;
                    string sLine = null;
                    for (int i = 0; i <= index; ++i)
                    {
                        sLine = sr.ReadLine();
                    }
                    return string.IsNullOrEmpty(sLine) ? null : sLine;
                }
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
