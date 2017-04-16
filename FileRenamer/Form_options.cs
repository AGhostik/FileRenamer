using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace FileRenamer
{
    public partial class Form_options : Form
    {
        public Form_options()
        {
            InitializeComponent();            
        }

        Form1 parent;

        private void button_save_Click(object sender, EventArgs e)
        {
            saveToFile();
            parent.reloadOptions();
            parent.optionsIsOpened = false;
            Close();
        }

        private void button_pickF_Click(object sender, EventArgs e)
        {
            pickFolderDialog();
        }

        private void Form_options_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.optionsIsOpened = false;
        }

        private void Form_options_Load(object sender, EventArgs e)
        {
            parent = this.Owner as Form1;            
            setLoadedOptions();
        }        

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteCell();
            }
        }               

        private void deleteCell()
        {
            if (dataGridView1.SelectedCells != null)
            {
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    cell.Value = null;
                }
            }
        }

        private void pickFolderDialog()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = parent.textBox_folderPath.Text;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value == null)
                        {
                            if (i + 1 == dataGridView1.Rows.Count)
                            {
                                dataGridView1.Rows.Add();
                            }

                            dataGridView1.Rows[i].Cells[1].Value = folderDialog.SelectedPath;
                            
                            return;
                        }
                    }
                }
            }
        }

        private void saveToFile()
        {
            string filename = parent.optionsFilename;

            XmlDocument xmlFile = new XmlDocument();
            XmlNode rootNode = xmlFile.CreateElement("Options");
            xmlFile.AppendChild(rootNode);

            XmlNode pathNode, extNode, fNode;

            pathNode = xmlFile.CreateElement("Path");
            pathNode.InnerText = parent.textBox_folderPath.Text;
            rootNode.AppendChild(pathNode);

            extNode = xmlFile.CreateElement("Extensions");
            extNode.InnerText = "";
            rootNode.AppendChild(extNode);

            fNode = xmlFile.CreateElement("Folders");
            fNode.InnerText = "";
            rootNode.AppendChild(fNode);

            foreachDataSave(xmlFile, extNode, "ext_", 0, true);

            foreachDataSave(xmlFile, fNode, "f_", 1);

            xmlFile.Save(Directory.GetCurrentDirectory() + '\\' + filename);
        }

        private void foreachDataSave(XmlDocument xmlFile, XmlNode parent, string namePrefix, int column, bool isExtension = false)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[column].Value != null)
                {
                    XmlNode temp = xmlFile.CreateElement(namePrefix + i.ToString());
                    string text = dataGridView1.Rows[i].Cells[column].Value.ToString();
                    if (isExtension)
                    {
                        text = normExtension(text);
                    }
                    temp.InnerText = text;
                    parent.AppendChild(temp);
                }
            }
        }

        private string normExtension(string ext)
        {
            string out_ext = string.Empty;
            foreach (char c in ext.ToLower())
            {
                if ((c >= 'a' && c <= 'z') ||
                    (c >= '0' && c <= '9') )
                {
                    out_ext += c;
                }
            }
            return out_ext;
        }

        private void setLoadedOptions()
        {
            dataGridView1.Rows.Clear();

            if (File.Exists(Directory.GetCurrentDirectory() + '\\' + parent.optionsFilename))
            {
                int count = 0;
                foreach (string s in parent.ignoreExt)
                {
                    if (dataGridView1.Rows.Count <= count + 1)
                    {
                        dataGridView1.Rows.Add();
                    }
                    dataGridView1.Rows[count].Cells[0].Value = s;                    
                    count++;
                }

                count = 0;
                foreach (string s in parent.ignoreF)
                {
                    if (dataGridView1.Rows.Count <= count + 1)
                    {
                        dataGridView1.Rows.Add();
                    }
                    dataGridView1.Rows[count].Cells[1].Value = s;
                    count++;
                }
            }
        }
    }
}
