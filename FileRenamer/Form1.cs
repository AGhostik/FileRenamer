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
            foreachDataLoad();
        }

        //var
        public bool optionsIsOpened = false;
        public string optionsFilename = "FileRenamerOptions.xml";

        public List<string> ignoreExt = new List<string>();
        public List<string> ignoreF = new List<string>();

        private List<string> files;        
        private uint filesCount;
        //var

        public void reloadOptions()
        {
            ignoreExt.Clear();
            ignoreF.Clear();
            foreachDataLoad();
        }

        private void button_rename_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox_folderPath.Text))
            {
                filesCount = 0;

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
                label.Text = filesCount + " files renamed!";
                MessageBox.Show("Done");              
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

        private void foreachDataLoad()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + '\\' + optionsFilename))
            {
                XmlDocument xmlFile = new XmlDocument();
                xmlFile.Load(Directory.GetCurrentDirectory() + '\\' + optionsFilename);
                foreach (XmlElement node in xmlFile.DocumentElement)
                {
                    if (node.Name == "Extensions")
                    {
                        foreach (XmlNode childnode in node.ChildNodes)
                        {
                            if (childnode.InnerText != string.Empty)
                                ignoreExt.Add(childnode.InnerText);
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

        private void recursionFindAll(string path)
        {
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

            counter = 0;
            foreach (string s in temp_files)
            {
                File.Move(s, path + '\\' + files_name[counter]);
                counter++;
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
            files = Directory.GetFiles(path).OrderBy(f => new FileInfo(f).Length).ToList(); //магическая строка, якобы сортирующая файлы по размеру
            filesCount += (uint)files.Count;
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
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox_folderPath.Text = folderDialog.SelectedPath;
                }
            }
        }
    }
}
