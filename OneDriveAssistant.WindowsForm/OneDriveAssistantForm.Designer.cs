namespace OneDriveAssistant
{
    partial class OneDriveAssistantForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorFolderBrowser = new Syncfusion.Windows.Forms.FolderBrowser(this.components);
            this.buttonProcess = new System.Windows.Forms.Button();
            this.buttonAbort = new System.Windows.Forms.Button();
            this.processProgressBar = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
            ((System.ComponentModel.ISupportInitialize)(this.processProgressBar)).BeginInit();
            this.SuspendLayout();
            // 
            // errorFolderBrowser
            // 
            this.errorFolderBrowser.Style = ((Syncfusion.Windows.Forms.FolderBrowserStyles)((Syncfusion.Windows.Forms.FolderBrowserStyles.RestrictToFilesystem | Syncfusion.Windows.Forms.FolderBrowserStyles.NewDialogStyle)));
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(118, 226);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(101, 23);
            this.buttonProcess.TabIndex = 0;
            this.buttonProcess.Text = "StartProcess";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // buttonAbort
            // 
            this.buttonAbort.Location = new System.Drawing.Point(356, 226);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(101, 23);
            this.buttonAbort.TabIndex = 1;
            this.buttonAbort.Text = "Abort";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // processProgressBar
            // 
            this.processProgressBar.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.processProgressBar.BackGradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.processProgressBar.BackMultipleColors = new System.Drawing.Color[0];
            this.processProgressBar.BackSegments = false;
            this.processProgressBar.BackTubeEndColor = System.Drawing.Color.White;
            this.processProgressBar.BackTubeStartColor = System.Drawing.Color.LightGray;
            this.processProgressBar.CustomText = null;
            this.processProgressBar.CustomWaitingRender = false;
            this.processProgressBar.FontColor = System.Drawing.Color.White;
            this.processProgressBar.ForegroundImage = null;
            this.processProgressBar.GradientEndColor = System.Drawing.Color.Lime;
            this.processProgressBar.GradientStartColor = System.Drawing.Color.Red;
            this.processProgressBar.Location = new System.Drawing.Point(88, 143);
            this.processProgressBar.MultipleColors = new System.Drawing.Color[0];
            this.processProgressBar.Name = "processProgressBar";
            this.processProgressBar.SegmentWidth = 12;
            this.processProgressBar.Size = new System.Drawing.Size(400, 23);
            this.processProgressBar.TabIndex = 2;
            this.processProgressBar.Text = "progress";
            this.processProgressBar.ThemesEnabled = false;
            this.processProgressBar.TubeEndColor = System.Drawing.Color.Black;
            this.processProgressBar.TubeStartColor = System.Drawing.Color.Red;
            this.processProgressBar.WaitingGradientWidth = 400;
            // 
            // OneDriveAssistantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 351);
            this.Controls.Add(this.processProgressBar);
            this.Controls.Add(this.buttonAbort);
            this.Controls.Add(this.buttonProcess);
            this.Name = "OneDriveAssistantForm";
            this.Text = "OneDriveAssistant";
            this.Load += new System.EventHandler(this.OneDriveAssistantForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.processProgressBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.FolderBrowser errorFolderBrowser;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.Button buttonAbort;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv processProgressBar;

    }
}

