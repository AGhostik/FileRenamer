namespace FileRenamer
{
    partial class Form_options
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
            this.button_pickF = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Extension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_mask = new System.Windows.Forms.TextBox();
            this.comboBox_ext = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_maskHelp = new System.Windows.Forms.Button();
            this.label_extPoint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_pickF
            // 
            this.button_pickF.Location = new System.Drawing.Point(454, 59);
            this.button_pickF.Name = "button_pickF";
            this.button_pickF.Size = new System.Drawing.Size(110, 28);
            this.button_pickF.TabIndex = 4;
            this.button_pickF.Text = "Pick folder";
            this.button_pickF.UseVisualStyleBackColor = true;
            this.button_pickF.Click += new System.EventHandler(this.button_pickF_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Extension,
            this.Folder});
            this.dataGridView1.Location = new System.Drawing.Point(12, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(552, 258);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // Extension
            // 
            this.Extension.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Extension.HeaderText = "Extension";
            this.Extension.MinimumWidth = 100;
            this.Extension.Name = "Extension";
            this.Extension.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Folder
            // 
            this.Folder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Folder.HeaderText = "Folder";
            this.Folder.MinimumWidth = 50;
            this.Folder.Name = "Folder";
            this.Folder.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Program will ignore this subfolders and extensions:";
            // 
            // textBox_mask
            // 
            this.textBox_mask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_mask.Location = new System.Drawing.Point(12, 29);
            this.textBox_mask.Name = "textBox_mask";
            this.textBox_mask.Size = new System.Drawing.Size(391, 24);
            this.textBox_mask.TabIndex = 1;
            this.textBox_mask.Text = "[C]";
            this.textBox_mask.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBox_ext
            // 
            this.comboBox_ext.FormattingEnabled = true;
            this.comboBox_ext.Items.AddRange(new object[] {
            "to lower",
            "TO UPPER"});
            this.comboBox_ext.Location = new System.Drawing.Point(421, 29);
            this.comboBox_ext.Name = "comboBox_ext";
            this.comboBox_ext.Size = new System.Drawing.Size(109, 24);
            this.comboBox_ext.TabIndex = 2;
            this.comboBox_ext.Text = "to lower";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "File name mask:";
            // 
            // button_maskHelp
            // 
            this.button_maskHelp.Location = new System.Drawing.Point(536, 25);
            this.button_maskHelp.Name = "button_maskHelp";
            this.button_maskHelp.Size = new System.Drawing.Size(28, 28);
            this.button_maskHelp.TabIndex = 3;
            this.button_maskHelp.Text = "?";
            this.button_maskHelp.UseVisualStyleBackColor = true;
            // 
            // label_extPoint
            // 
            this.label_extPoint.AutoSize = true;
            this.label_extPoint.Location = new System.Drawing.Point(406, 36);
            this.label_extPoint.Margin = new System.Windows.Forms.Padding(0);
            this.label_extPoint.Name = "label_extPoint";
            this.label_extPoint.Size = new System.Drawing.Size(12, 17);
            this.label_extPoint.TabIndex = 8;
            this.label_extPoint.Text = ".";
            // 
            // Form_options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 363);
            this.Controls.Add(this.label_extPoint);
            this.Controls.Add(this.button_maskHelp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_ext);
            this.Controls.Add(this.textBox_mask);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_pickF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Rename.file - Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_options_FormClosing);
            this.Load += new System.EventHandler(this.Form_options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_pickF;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Extension;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_mask;
        private System.Windows.Forms.ComboBox comboBox_ext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_maskHelp;
        private System.Windows.Forms.Label label_extPoint;
    }
}