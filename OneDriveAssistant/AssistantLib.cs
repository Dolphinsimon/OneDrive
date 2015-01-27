using System;
using System.IO;
using Microsoft.VisualBasic.Devices;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneDriveAssistant
{
    class AssistantLib
    {
        /// <summary>
        /// Get a line of the encoding errors.txt
        /// </summary>
        /// <param name="filepath">filepath of the encoding errors.txt</param>
        /// <param name="index">the index of line</param>
        /// <returns>One line in encoding errors.txt</returns>
        private string GetOneline(string filepath,int index)
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
        private string[] GetFileName(string text)
        {
            //text = "Original File Name  ->  New File Name";
            if (!text.Contains("->")) return null;
            string[] nameSeparator = {"->"};
            string[] textStrings=text.Split(Convert.ToChar(nameSeparator));
            return textStrings;
        }
        /// <summary>
        /// Get file path
        /// </summary>
        /// <param name="text">file name array</param>
        /// <returns>Original File Name</returns>
        private string GetFileName(IReadOnlyList<string> text)
        {
            if (text==null||text.Count<2) return null;
            char[] nameSeparator = {'/'};
            string[] originalFilePath = text[0].Split(nameSeparator);
            string originalFileName = null;
            foreach (string t in originalFilePath)
            {
                originalFileName = t;
            }
            return originalFileName;
        }

        private bool Rename(string filepath,string newFileName)
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
