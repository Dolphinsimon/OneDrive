using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.Devices;

namespace OneDriveAssistant
{
    public class File
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
                    for (int i = 0; i <= index; i++)
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
            if (!text.Contains("->")) return null;
            string[] nameSeparator = { "->" };
            string[] textStrings = text.Split(Convert.ToChar(nameSeparator));
            return textStrings;
        }
        /// <summary>
        /// Get file path
        /// </summary>
        /// <param name="text">file name array</param>
        /// <returns>Original File Name</returns>
        public string GetFileName(IReadOnlyList<string> text)
        {
            if (text == null || text.Count < 2) return null;
            char[] nameSeparator = { '/' };
            string[] originalFilePath = text[0].Split(nameSeparator);
            string originalFileName = null;
            foreach (string t in originalFilePath)
            {
                originalFileName = t;
            }
            return originalFileName;
        }
        /// <summary>
        /// Reanme the file
        /// </summary>
        /// <param name="filepath">filepath</param>
        /// <param name="newFileName">original name</param>
        /// <returns>successed or failed</returns>
        public bool Rename(string filepath, string newFileName)
        {
            try
            {
                Computer myComputer = new Computer();
                myComputer.FileSystem.RenameFile(filepath, newFileName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
