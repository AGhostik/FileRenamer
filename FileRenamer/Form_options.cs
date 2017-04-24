using System;
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

        private void Form_options_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save options?",
                "Rename.file",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                saveToFile();
                parent.reloadOptions();
                parent.optionsIsOpened = false;
            }
        }

        private void button_pickF_Click(object sender, EventArgs e)
        {
            pickFolderDialog();
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
            string filename = parent.getOptionsFilename();

            XmlDocument xmlFile = new XmlDocument();
            XmlNode rootNode = xmlFile.CreateElement("Options");
            xmlFile.AppendChild(rootNode);

            XmlNode tempNode, extNode, fNode;

            tempNode = xmlFile.CreateElement("Path");
            tempNode.InnerText = parent.textBox_folderPath.Text;
            rootNode.AppendChild(tempNode);

            tempNode = xmlFile.CreateElement("Mask");
            tempNode.InnerText = textBox_mask.Text;
            rootNode.AppendChild(tempNode);

            tempNode = xmlFile.CreateElement("Mask_extension");
            tempNode.InnerText = comboBox_ext.Text;
            rootNode.AppendChild(tempNode);

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
                        text = optionsExtAllowed(text);
                    }
                    temp.InnerText = text;
                    parent.AppendChild(temp);
                }
            }
        }

        private string optionsExtAllowed(string ext)
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

            if (File.Exists(Directory.GetCurrentDirectory() + '\\' + parent.getOptionsFilename()))
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
