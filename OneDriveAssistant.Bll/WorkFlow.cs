using System;
using System.IO;

namespace OneDriveAssistant
{
    public class WorkFlow
    {
        private readonly string _path;
        public readonly string[] Rows;
        private static readonly ProcessEncodingErrors MyEncodingErrors = new ProcessEncodingErrors();
        public WorkFlow(string path)
        {
            _path = path;
            var encodingErrors = path + "\\Encoding Errors.txt"; 
            Rows= MyEncodingErrors.GetRows(encodingErrors);
        }
        /// <summary>
        /// Rename files
        /// </summary>
        /// <returns>successful or failed</returns>
        public Result RestoreFileName(string row)
        {
            if (string.IsNullOrEmpty(row)) return null;
            var filenamearray = MyEncodingErrors.GetFileName(row);
            //Get an array contains two elements:Original File Name & New File Name
            if (filenamearray == null) return null;
            var result = new Result();
            try
            {
                var destFilePath = _path + "\\" + filenamearray[0];
                var sourceFilePath = _path + "\\" + filenamearray[1];
                var destDirectory = _path + MyEncodingErrors.FormatDirectory(filenamearray[0]);
                var sourceDirectory = _path + MyEncodingErrors.FormatDirectory(filenamearray[1]);
                var sourceFile = MyEncodingErrors.FormatFile(filenamearray[1]);
                if (!Directory.Exists(destDirectory))
                {
                    Directory.CreateDirectory(destDirectory);
                }
                if (Directory.GetFiles(sourceDirectory, sourceFile).Length >= 1)
                {
                    File.Move(sourceFilePath, destFilePath);
                }
                if (Directory.GetFiles(sourceDirectory).Length < 1)
                {
                    Directory.Delete(sourceDirectory);
                }
                result.Success = true;
                result.FileName = row;
                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Error = e;
                result.FileName = e.InnerException.Message;
                return result;
            }
        }
    }

}
