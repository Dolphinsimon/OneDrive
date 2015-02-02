using System;
using System.IO;

namespace OneDriveAssistant
{
    public class WorkFlow
    {
        private readonly string _encodingErrors;
        private readonly string _path;
        private static readonly ProcessEncodingErrors MyEncodingErrors = new ProcessEncodingErrors();
        public WorkFlow(string path)
        {
            _path = path;
            _encodingErrors = path + "\\Encoding Errors.txt";                
        }
        /// <summary>
        /// Rename files
        /// </summary>
        /// <returns>successful or failed</returns>
        public Result RestoreFileName()
        {
            Result result=new Result();
            try
            {
                string[] rows = MyEncodingErrors.GetRows(_encodingErrors);
                foreach (string oneline in rows)
                {
                    if (string.IsNullOrEmpty(oneline)) continue;
                    string[] filenamearray = MyEncodingErrors.GetFileName(oneline);
                    //Get an array contains two elements:Original File Name & New File Name
                    if (filenamearray == null) continue;
                    try
                    {
                        string sourceFilePath = _path + "\\" + filenamearray[1];
                        string destFilePath = _path + "\\" + filenamearray[0];
                        string directory = MyEncodingErrors.FormatDirectory(filenamearray[0]);
                        Directory.CreateDirectory(_path+directory);
                        File.Move(sourceFilePath, destFilePath);
                        result.Success = true;
                        result.FileName = oneline;
                    }
                    catch (Exception)
                    {
                        result.Success = false;
                    }
                    if (result.Success == false) break;
                }
                return result;
            }
            catch (Exception)
            {
                result.Success = false;
                result.FileName = "Failed!";
                return result;
            }    
        }

    }
}
