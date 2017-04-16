using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace FileRenamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadOptions();
        }

        //var
        public bool optionsIsOpened = false;
        public string optionsFilename = "FileRenamerOptions.xml";

        public List<string> ignoreExt = new List<string>();
        public List<string> ignoreF = new List<string>();

        private List<string> files;        
        private int allFilesCount_global;
        private int currentFilesCount_global;
        private int allFilesCount_local;
        //private int currentFilesCount_local;
        //var

        public void reloadOptions()
        {
            ignoreExt.Clear();
            ignoreF.Clear();
            LoadOptions();
        }

        private void button_rename_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox_folderPath.Text))
            {
                if (!optionsIsOpened)
                {
                    allFilesCount_global = 0;
                    currentFilesCount_global = 0;

                    progressBarEnable();
                    controlsDisable();

                    backgroundWorker.RunWorkerAsync();
                }
            }
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            selectFolder();
        }

        private void button_options_Click(object sender, EventArgs e)
        {
            if (!optionsIsOpened)
            {
                optionsIsOpened = true;

                Form_options options = new Form_options();
                options.Owner = this;
                options.Show();
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarDisable();
            controlsEnable();
            label.Text = currentFilesCount_global + " files renamed!";
            MessageBox.Show("Done");
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar_local.Value = e.ProgressPercentage;
            progressBar_global.Value = (currentFilesCount_global * 100) / allFilesCount_global;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (checkBox_subfolders.Checked)
            {
                recursionFindAll(textBox_folderPath.Text);
            }
            else
            {
                if (checkFilesExist(textBox_folderPath.Text))
                {
                    cleanTempFolder(textBox_folderPath.Text);
                    getSortedFiles(textBox_folderPath.Text);
                    renameFiles(textBox_folderPath.Text);
                }
            }
        }

        private void controlsEnable()
        {
            button_browse.Enabled = true;
            button_options.Enabled = true;

            textBox_folderPath.ReadOnly = false;

            button_rename.Visible = true;
            button_cancel.Visible = false;
        }

        private void controlsDisable()
        {
            button_browse.Enabled = false;
            button_options.Enabled = false;

            textBox_folderPath.ReadOnly = true;

            button_rename.Visible = false;
            button_cancel.Visible = true;
        }

        private void progressBarEnable()
        {
            progressBar_global.Visible = true;
            progressBar_local.Visible = true;
            label.Visible = false;
        }

        private void progressBarDisable()
        {
            progressBar_global.Visible = false;
            progressBar_local.Visible = false;
            label.Visible = true;
        }

        private void LoadOptions()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + '\\' + optionsFilename))
            {
                XmlDocument xmlFile = new XmlDocument();
                xmlFile.Load(Directory.GetCurrentDirectory() + '\\' + optionsFilename);
                foreach (XmlElement node in xmlFile.DocumentElement)
                {
                    if (node.Name == "Path")
                    {
                        if (node.InnerText != string.Empty)
                            textBox_folderPath.Text = node.InnerText;
                    }
                    if (node.Name == "Extensions")
                    {
                        foreach (XmlNode childnode in node.ChildNodes)
                        {
                            if (childnode.InnerText != string.Empty)
                                ignoreExt.Add( normExtension(childnode.InnerText) );
                        }
                    }
                    if (node.Name == "Folders")
                    {
                        foreach (XmlNode childnode in node.ChildNodes)
                        {
                            if (childnode.InnerText != string.Empty)
                                ignoreF.Add(childnode.InnerText);
                        }
                    }
                }
            }
        }

        private string normExtension(string ext)
        {
            string out_ext = string.Empty;
            foreach (char c in ext.ToLower())
            {
                if ((c >= 'a' && c <= 'z') ||
                    (c >= '0' && c <= '9'))
                {
                    out_ext += c;
                }
            }
            return out_ext;
        }

        private void recursionFindAll(string path)
        {
            if (backgroundWorker.CancellationPending)
                return;

            if (checkFilesExist(path))
            {
                cleanTempFolder(path);
                getSortedFiles(path);
                renameFiles(path);
            }


            List<string> subfolders = Directory.GetDirectories(path).ToList();

            if (subfolders.Count > 0)
            {
                foreach (string folder in subfolders) //folder - full path
                {
                    foreach (string fold in ignoreF)
                    {
                        if (folder == fold)
                        {
                            goto skip_folder;
                        }
                    }

                    recursionFindAll(folder);

                    skip_folder:;
                }
            }
            else
            {
                return;
            }
        }

        private void renameFiles(string path)
        {
            int counter = 0;
            List<string> temp_files = new List<string>();
            List<string> files_name = new List<string>();          

            foreach (string s in files)
            {
                string extension = Path.GetExtension(s).ToLower();
                foreach (string ext in ignoreExt)
                {
                    if ('.' + ext == extension)
                    {
                        allFilesCount_global--;
                        allFilesCount_local--;
                        goto skip_file;
                    }
                }
                string filename = counter + extension;
                File.Move(s, path + "\\_temp\\" + filename);
                temp_files.Add(path + "\\_temp\\" + filename);
                files_name.Add(filename);
                counter++;

            skip_file:;
            }

            if (counter > 0)
            {                
                counter = 0;
                foreach (string s in temp_files)
                {
                    File.Move(s, path + '\\' + files_name[counter]);
                    
                    currentFilesCount_global++;
                    counter++;

                    backgroundWorker.ReportProgress( (counter * 100)/allFilesCount_local );
                }
            }

            Directory.Delete(path + "\\_temp", true);
        }

        private void cleanTempFolder(string path)
        {
            if (Directory.Exists(path + "\\_temp"))
            {
                Directory.Delete(path + "\\_temp", true);
            }

            Directory.CreateDirectory(path + "\\_temp");
        }

        private void getSortedFiles(string path)
        {           
            files = Directory.GetFiles(path).OrderBy(f => new FileInfo(f).Length).ToList();
            //магическая строка, якобы сортирующая файлы по размеру   
            allFilesCount_global += files.Count;
            allFilesCount_local = files.Count;
        }

        private bool checkFilesExist(string path)
        {
            bool filesExist = 
                Directory.GetFiles(path).Length > 0 
                ? true : false;

            return filesExist;
        }

        private void selectFolder()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (textBox_folderPath.Text != string.Empty)
                {
                    folderDialog.SelectedPath = textBox_folderPath.Text;
                }
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox_folderPath.Text = folderDialog.SelectedPath;
                }
            }
        }        
    }
}
