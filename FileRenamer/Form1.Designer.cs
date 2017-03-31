namespace FileRenamer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_browse = new System.Windows.Forms.Button();
            this.button_rename = new System.Windows.Forms.Button();
            this.textBox_folderPath = new System.Windows.Forms.TextBox();
            this.checkBox_subfolders = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(379, 10);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(86, 26);
            this.button_browse.TabIndex = 0;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // button_rename
            // 
            this.button_rename.Location = new System.Drawing.Point(12, 40);
            this.button_rename.Name = "button_rename";
            this.button_rename.Size = new System.Drawing.Size(75, 26);
            this.button_rename.TabIndex = 1;
            this.button_rename.Text = "Rename";
            this.button_rename.UseVisualStyleBackColor = true;
            this.button_rename.Click += new System.EventHandler(this.button_rename_Click);
            // 
            // textBox_folderPath
            // 
            this.textBox_folderPath.Location = new System.Drawing.Point(12, 12);
            this.textBox_folderPath.Name = "textBox_folderPath";
            this.textBox_folderPath.Size = new System.Drawing.Size(361, 22);
            this.textBox_folderPath.TabIndex = 2;
            this.textBox_folderPath.Text = "C:\\Users\\Undead\\Downloads\\Test";
            // 
            // checkBox_subfolders
            // 
            this.checkBox_subfolders.AutoSize = true;
            this.checkBox_subfolders.Checked = true;
            this.checkBox_subfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_subfolders.Location = new System.Drawing.Point(309, 45);
            this.checkBox_subfolders.Name = "checkBox_subfolders";
            this.checkBox_subfolders.Size = new System.Drawing.Size(156, 21);
            this.checkBox_subfolders.TabIndex = 3;
            this.checkBox_subfolders.Text = "including subfolders";
            this.checkBox_subfolders.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 78);
            this.Controls.Add(this.checkBox_subfolders);
            this.Controls.Add(this.textBox_folderPath);
            this.Controls.Add(this.button_rename);
            this.Controls.Add(this.button_browse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "RenameFiles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.Button button_rename;
        private System.Windows.Forms.TextBox textBox_folderPath;
        private System.Windows.Forms.CheckBox checkBox_subfolders;
    }
}

