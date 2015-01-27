using System.Windows;
using FolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;
using DialogResult = System.Windows.Forms.DialogResult;
using Button = System.Windows.Controls.Button;
using Control = System.Windows.Controls.Control;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace SelectFile
{
    public enum SelectModeType
    {

        SelectFile,

        SelectFolder,

        SaveFile
    }

    [TemplatePart(Name = "SelectBtn", Type = typeof(Button))]
    public class SelectPathControl : Control
    {
        #region

        public static readonly DependencyProperty PathProperty =
        DependencyProperty.Register(Properties.Resources.Path, typeof(string), typeof(SelectPathControl), new PropertyMetadata(string.Empty));

        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }


        public static readonly DependencyProperty FilterProperty =
        DependencyProperty.Register(Properties.Resources.Filter, typeof(string), typeof(SelectPathControl), new PropertyMetadata("All|*.*"));

        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        public static readonly DependencyProperty SelectModeProperty =
            DependencyProperty.Register(Properties.Resources.SelectMode, typeof(SelectModeType), typeof(SelectPathControl), new PropertyMetadata(SelectModeType.SelectFile));

        public SelectModeType SelectMode
        {
            get { return (SelectModeType)GetValue(SelectModeProperty); }
            set { SetValue(SelectModeProperty, value); }
        }

        #endregion

        static SelectPathControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectPathControl), new FrameworkPropertyMetadata(typeof(SelectPathControl)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var btn = GetTemplateChild("SelectBtn") as Button;
            if (btn != null)
            {
                btn.Click += (s, e) =>
                {
                    switch (SelectMode)
                    {
                        case SelectModeType.SelectFile: OpenSelectFileDialog(); break;
                        case SelectModeType.SelectFolder: OpenSelectFolderDialog(); break;
                        case SelectModeType.SaveFile: OpenSaveFileDialog(); break;
                    }
                };
            }
        }

        #region 按钮相应

        private void OpenSaveFileDialog()
        {
            var dlg = new SaveFileDialog { Filter = Filter, FileName = Path };
            var res = dlg.ShowDialog();
            if (res != true) return;
            Path = dlg.FileName;
        }


        private void OpenSelectFileDialog()
        {
            var dlg = new OpenFileDialog { Filter = Filter, FileName = Path };
            var res = dlg.ShowDialog();
            if (res != true) return;
            Path = dlg.FileName;
        }

        private void OpenSelectFolderDialog()
        {
            var dlg = new FolderBrowserDialog { SelectedPath = Path };
            var res = dlg.ShowDialog() == DialogResult.OK;
            if (!res) return;
            Path = dlg.SelectedPath;
        }

        #endregion
    }
}
