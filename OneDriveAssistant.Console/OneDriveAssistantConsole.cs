using System;
using System.IO;

namespace OneDriveAssistant
{
    class OneDriveAssistantConsole
    {
        static void Main(string[] args)
        {
            // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
            while (args.Length==0)
            {
                Console.WriteLine("Please enter the directory of Encoding_error.txt");
                string path = Console.ReadLine();
                if (path == null) Console.WriteLine("Wrong input string,please enterthe directory of Encoding_error.txt");
                // ReSharper disable once AssignNullToNotNullAttribute
                DirectoryInfo folder=new DirectoryInfo(path);
                FileInfo[] files = folder.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Name != "Encoding Errors.txt")
                    {
                        Console.WriteLine("Can't find the Enconding Errors.txt,please try again!");
                    }
                    else
                    {
                        WorkFlow myWorkFlow=new WorkFlow(path);
                        Result myResult= myWorkFlow.RestoreFileName();
                        if(myResult.Success) {Console.WriteLine("Process successful!");}
                        Console.WriteLine("Process {0} failed,please try again!",myResult.FileName);
                        break;
                    }
                }
            }

            while (args.Length>0)
            {
                if (args.Length>1) Console.WriteLine("Wrong args,please try again!");
                // ReSharper disable once AssignNullToNotNullAttribute
                DirectoryInfo folder = new DirectoryInfo(args[0]);
                FileInfo[] files = folder.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Name != "Encoding Errors.txt")
                    {
                        Console.WriteLine("Can't find the Enconding Errors.txt,please try again!");
                    }
                    else
                    {
                        WorkFlow myWorkFlow = new WorkFlow(args[0]);
                        Result myResult = myWorkFlow.RestoreFileName();
                        if (myResult.Success) {Console.WriteLine("Process successful!");}
                        Console.WriteLine("Process {0} failed,please try again!",myResult.FileName);
                        break;
                    }
                    
                }
            }
            
        }
    }
}
