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

namespace FileRenamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //var
        IOrderedEnumerable<string> files;
        //var

        private void button_rename_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox_folderPath.Text))
            {
                foreach (string s in files)
                    MessageBox.Show(s);
            }
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            selectFolder();
        }

        private void sortFiles()
        {           
            files = Directory.GetFiles(textBox_folderPath.Text).OrderBy(f => new FileInfo(f).Length); //магическая строка, якобы сортирующая файлы по размеру
        }

        private bool getFileList()
        {
            bool filesExist = 
                Directory.GetFiles(textBox_folderPath.Text).Length > 0 
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

                    if (getFileList())
                    {
                        sortFiles();
                    }
                    else
                    {
                        MessageBox.Show("Folder does not contain files");
                    }
                }
            }
        }

    }
}
