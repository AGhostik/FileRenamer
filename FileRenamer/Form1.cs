using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileRenamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_rename_Click(object sender, EventArgs e)
        {

        }

        private void button_browse_Click(object sender, EventArgs e)
        {

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
