using System;

namespace OneDriveAssistant
{
    public class WorkFlow
    {
        private string _file;
        private static readonly File MyFile=new File();
        public string File
        {
            set { _file = value; }
        }

        public WorkFlow(string filepath)
        {
            File = filepath;
        }

        public bool RestoreFileName()
        {
            try
            {
                bool success = false;
                int rows = MyFile.GetRows(_file);
                for (int i = 0; i < rows; ++i)
                {
                    string oneline = MyFile.GetOneLine(_file, i);
                    if (oneline == null) continue;
                    string[] filenamearray = MyFile.GetFileName(oneline);
                    //Get an array contains two elements:Original File Name & New File Name
                    if (filenamearray == null) continue;
                    string originalfilename = MyFile.GetFileName(filenamearray);
                    success=MyFile.Rename(filenamearray[1], originalfilename);
                    if (success == false) break;
                }
                return success;
            }
            catch (Exception)
            {
                return false;
            }           
        }

        public bool RestoreFolderName()
        {

            return false;

        }
    }
}
