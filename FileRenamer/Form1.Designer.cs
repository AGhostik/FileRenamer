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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_browse = new System.Windows.Forms.Button();
            this.button_rename = new System.Windows.Forms.Button();
            this.textBox_folderPath = new System.Windows.Forms.TextBox();
            this.checkBox_subfolders = new System.Windows.Forms.CheckBox();
            this.label = new System.Windows.Forms.Label();
            this.button_options = new System.Windows.Forms.Button();
            this.progressBar_global = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar_local = new System.Windows.Forms.ProgressBar();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(380, 10);
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
            this.textBox_folderPath.Size = new System.Drawing.Size(362, 22);
            this.textBox_folderPath.TabIndex = 2;
            // 
            // checkBox_subfolders
            // 
            this.checkBox_subfolders.AutoSize = true;
            this.checkBox_subfolders.Checked = true;
            this.checkBox_subfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_subfolders.Location = new System.Drawing.Point(218, 44);
            this.checkBox_subfolders.Name = "checkBox_subfolders";
            this.checkBox_subfolders.Size = new System.Drawing.Size(156, 21);
            this.checkBox_subfolders.TabIndex = 3;
            this.checkBox_subfolders.Text = "including subfolders";
            this.checkBox_subfolders.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 73);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(76, 17);
            this.label.TabIndex = 4;
            this.label.Text = "                 ";
            // 
            // button_options
            // 
            this.button_options.Location = new System.Drawing.Point(380, 40);
            this.button_options.Name = "button_options";
            this.button_options.Size = new System.Drawing.Size(86, 26);
            this.button_options.TabIndex = 5;
            this.button_options.Text = "Options";
            this.button_options.UseVisualStyleBackColor = true;
            this.button_options.Click += new System.EventHandler(this.button_options_Click);
            // 
            // progressBar_global
            // 
            this.progressBar_global.Location = new System.Drawing.Point(242, 72);
            this.progressBar_global.Name = "progressBar_global";
            this.progressBar_global.Size = new System.Drawing.Size(224, 15);
            this.progressBar_global.TabIndex = 6;
            this.progressBar_global.Visible = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // progressBar_local
            // 
            this.progressBar_local.Location = new System.Drawing.Point(12, 72);
            this.progressBar_local.Name = "progressBar_local";
            this.progressBar_local.Size = new System.Drawing.Size(224, 15);
            this.progressBar_local.TabIndex = 7;
            this.progressBar_local.Visible = false;
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(12, 40);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 26);
            this.button_cancel.TabIndex = 8;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Visible = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 99);
            this.Controls.Add(this.progressBar_local);
            this.Controls.Add(this.progressBar_global);
            this.Controls.Add(this.button_options);
            this.Controls.Add(this.label);
            this.Controls.Add(this.checkBox_subfolders);
            this.Controls.Add(this.textBox_folderPath);
            this.Controls.Add(this.button_rename);
            this.Controls.Add(this.button_browse);
            this.Controls.Add(this.button_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Rename.file";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.Button button_rename;
        private System.Windows.Forms.CheckBox checkBox_subfolders;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button button_options;
        public System.Windows.Forms.TextBox textBox_folderPath;
        private System.Windows.Forms.ProgressBar progressBar_global;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar_local;
        private System.Windows.Forms.Button button_cancel;
    }
}

