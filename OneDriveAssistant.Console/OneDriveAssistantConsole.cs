using System;
using System.IO;

namespace OneDriveAssistant
{
    class OneDriveAssistantConsole
    {
        static void Main(string[] args)
        {
            while (args.Length==0)
            {
                Console.WriteLine("Please enter the directory of Encoding_error.txt");
                string path = Console.ReadLine();
                if (path == null)
                {
                    Console.WriteLine("Wrong input string,please enter the directory of Encoding_error.txt");
                }
                else
                {
                    string[] files = Directory.GetFiles(path);
                    if (files.Length < 1) continue;
                    foreach (string file in files)
                    {
                        if (file != "Encoding Errors.txt")
                        {
                            Console.WriteLine("Can't find the Enconding Errors.txt,please try again!");
                        }
                        else
                        {
                            WorkFlow myWorkFlow = new WorkFlow(path);
                            Result myResult = myWorkFlow.RestoreFileName();
                            if (myResult.Success)
                            {
                                Console.WriteLine("Process successful!");
                            }
                            else
                            {
                                Console.WriteLine("Process {0} failed,please try again!", myResult.FileName);
                            }
                            break;
                        }
                    }
                
                 }
            }

            while (args.Length>0)
            {
                if (args.Length>1) Console.WriteLine("Wrong args,please try again!");
                string[] files = Directory.GetFiles(args[0]);
                if (files.Length < 1) continue;
                foreach (string file in files)
                {
                    if (file != "Encoding Errors.txt")
                    {
                        Console.WriteLine("Can't find the Enconding Errors.txt,please try again!");
                    }
                    else
                    {
                        WorkFlow myWorkFlow = new WorkFlow(args[0]);
                        Result myResult = myWorkFlow.RestoreFileName();
                        if (myResult.Success)
                        {
                            Console.WriteLine("Process successful!");
                        }
                        else
                        {
                            Console.WriteLine("Process {0} failed,please try again!", myResult.FileName);
                        }
                        break;
                    }
                    
                }
            }
            
        }
    }
}
