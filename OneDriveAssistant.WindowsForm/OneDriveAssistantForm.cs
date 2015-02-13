using System;
using System.IO;
using System.Windows.Forms;
using OneDriveAssistant.Properties;

namespace OneDriveAssistant
{
    public partial class OneDriveAssistantForm : Form
    {
        public OneDriveAssistantForm()
        {
            InitializeComponent();
        }

        private void OneDriveAssistantForm_Load(object sender, EventArgs e)
        {
            errorFolderBrowser.Description = "Please select the folder that contains Ecoding Errors.txt!";
            errorFolderBrowser.ShowDialog();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            string path = errorFolderBrowser.DirectoryPath;
            DirectoryInfo folder = new DirectoryInfo(path);
            FileInfo[] files = folder.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Name != "Encoding Errors.txt")
                {
                    MessageBox.Show(Resources.FILE_NOT_FIND_ERROR);
                }
                else
                {
                    WorkFlow myWorkFlow = new WorkFlow(path);
                    Result myResult = myWorkFlow.RestoreFileName();
                    if (myResult.Success)
                    {
                        MessageBox.Show(Resources.PROCESS_SUCESS);
                    }
                    else
                    {
                        MessageBox.Show(Resources.Process+myResult.FileName+Resources.failed_please_try_again_);
                    }
                    break;
                }
            }
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            Close();
        }




    }
}
