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
            var result=new Result();
            string[] rows;
            try
            {
                rows = MyEncodingErrors.GetRows(_encodingErrors);
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Error = e;
                result.FileName = e.Message;
                return result;
            }
            foreach (var oneline in rows)
                {
                    if (string.IsNullOrEmpty(oneline)) continue;
                    var filenamearray = MyEncodingErrors.GetFileName(oneline);
                    //Get an array contains two elements:Original File Name & New File Name
                    if (filenamearray == null) continue;
                    try
                    {
                        var destFilePath = _path + "\\" + filenamearray[0];
                        var sourceFilePath = _path + "\\" + filenamearray[1];
                        var destDirectory = _path+MyEncodingErrors.FormatDirectory(filenamearray[0]);
                        var sourceDirectory =_path+ MyEncodingErrors.FormatDirectory(filenamearray[1]);
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
