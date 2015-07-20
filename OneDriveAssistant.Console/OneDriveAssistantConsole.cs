using System.IO;
using System.Linq;
using static System.Console;

namespace OneDriveAssistant
{
    class OneDriveAssistantConsole
    {
        static void Main(string[] args)
        {
            while (args.Length==0)
            {
                WriteLine("Please enter the directory of Encoding_error.txt");
                var path = ReadLine();
                if (path == null||!Directory.Exists(path))
                {
                    WriteLine("Wrong input string,please enter the directory of Encoding_error.txt");
                }
                else
                {
                    var files = Directory.GetFiles(path, "Encoding Errors.txt");
                    if (files.Length < 1) continue;
                    if (files.All(file => file != "Encoding Errors.txt")) continue;
                    var myWorkFlow = new WorkFlow(path);
                    var count = myWorkFlow.Rows.Length;
                    var myResult=new Result();
                    int once = 0;
                    foreach (var row in myWorkFlow.Rows)
                    {
                        myResult = myWorkFlow.RestoreFileName(row);
                        if (!myResult.Success) break;
                        ++once;
                        WriteLine("Process {0} %, total {1} files.", once / count * 100, once);
                    }
                    if(!myResult.Success)
                        WriteLine("Process {0} failed, exception message is {1},please try again!", myResult.FileName,myResult.Error.Message);
                    if(myResult.Success)
                        WriteLine("Congratulations! All files are generated successful, Enjoy your files!");
                }
            }

            while (args.Length > 0)
            {
                if (args.Length > 1) WriteLine("Wrong args,please try again!");
                if (args[0] == null || !Directory.Exists(args[0]))
                {
                    WriteLine("Wrong input string,please enter the directory of Encoding_error.txt");
                }
                else
                {
                    var files = Directory.GetFiles(args[0], "Encoding Errors.txt");
                    if (files.Length < 1) continue;
                    if (files.All(file => file != "Encoding Errors.txt")) continue;
                    var myWorkFlow = new WorkFlow(args[0]);
                    var count = myWorkFlow.Rows.Length;
                    var myResult = new Result();
                    int once = 0;
                    foreach (var row in myWorkFlow.Rows)
                    {
                        myResult = myWorkFlow.RestoreFileName(row);
                        if (!myResult.Success) break;
                        ++once;
                        WriteLine("Process {0} %, total {1} files.", once/count*100, once);
                    }
                    if (!myResult.Success)
                        WriteLine("Process {0} failed, exception message is {1},please try again!", myResult.FileName,
                            myResult.Error.Message);
                    if (myResult.Success)
                        WriteLine("Congratulations! All files are generated successful, Enjoy your files!");
                }
            }

        }
    }
}
