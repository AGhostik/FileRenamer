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
    public partial class Form_options : Form
    {
        public Form_options()
        {
            InitializeComponent();            
        }

        Form1 parent;

        private void button_save_Click(object sender, EventArgs e)
        {
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
    }
}
