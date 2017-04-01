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
            parent.optionsIsOpened = false;
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            parent.optionsIsOpened = false;
            Close();
        }

        private void Form_options_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.optionsIsOpened = false;
        }

        private void Form_options_Load(object sender, EventArgs e)
        {
            parent = this.Owner as Form1;
        }

        private void saveToFile()
        {
            string filename = "FileRenamerOptions.xml";

            XmlDocument xmlFile = new XmlDocument();
            XmlNode rootNode = xmlFile.CreateElement("Options");
            xmlFile.AppendChild(rootNode);

            XmlNode extNode, fNode;

            extNode = xmlFile.CreateElement("Extensions");
            extNode.InnerText = "";
            rootNode.AppendChild(extNode);

            fNode = xmlFile.CreateElement("Folders");
            fNode.InnerText = "";
            rootNode.AppendChild(fNode);

            xmlForeachData(xmlFile, extNode, 0);

            xmlForeachData(xmlFile, fNode, 1);

            xmlFile.Save(System.IO.Directory.GetCurrentDirectory() + '\\' + filename);
        }

        private void xmlForeachData(XmlDocument xmlFile, XmlNode parent, int column)
        {
            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[column].Value != null)
                    {
                        XmlNode temp = xmlFile.CreateElement(i.ToString());
                        temp.InnerText = dataGridView1.Rows[i].Cells[column].Value.ToString();
                        parent.AppendChild(temp);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}
