﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
            loadOptions();
        }

        //var
        //public:        
        public bool optionsIsOpened = false;        
        public List<string> ignoreExt = new List<string>();
        public List<string> ignoreF = new List<string>();

        //private:
        private const string logFilename = "FileRenamer_Log.txt";
        private const string optionsFilename = "FileRenamerOptions.xml";

        private List<string> files;
        private List<string> folders;
        private int filesCountAll;
        private int filesCountCurrent;
        private bool maskExt_toLower;
        private string mask;
        //var

        public void reloadOptions()
        {
            ignoreExt.Clear();
            ignoreF.Clear();
            loadOptions();
        }

        public string getOptionsFilename()
        {
            return optionsFilename;
        }

        private void button_rename_Click(object sender, EventArgs e)
        {
            logCreate();            

            if (Directory.Exists(textBox_folderPath.Text))
            {
                if (!optionsIsOpened)
                {
                    progressBarEnable();
                    controlsDisable();

                    backgroundWorker.RunWorkerAsync();
                }
            }
            else
            {
                logWriteLine(textBox_folderPath.Text + " directory not exists");
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

        private void button_cancel_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            logWriteLine("Work is stopped");
        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            logWriteLine("Work is started");

            filesCountAll = 0;
            filesCountCurrent = 0;

            folders = new List<string>();
            
            if (checkBox_subfolders.Checked)
            {
                recursionFindAll(textBox_folderPath.Text);
                renameFiles_allFolders();
            }
            else
            {
                logWriteLine("_Without subfolders");

                if (checkFilesExist(textBox_folderPath.Text))
                {
                    tempFolderClean(textBox_folderPath.Text);
                    getSortedFiles(textBox_folderPath.Text);
                    renameFiles(textBox_folderPath.Text);
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar_global.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarDisable();
            controlsEnable();
            label.Text = filesCountCurrent + " files renamed!";
            MessageBox.Show("Done", "Done");
            logWriteLine("Work is done");
        }
        
        private void logCreate()
        {
            using (StreamWriter logFile = new StreamWriter(logFilename))
            {
                logFile.WriteLine(DateTime.Today.ToUniversalTime().ToString());

                logFile.WriteLine("=path=");
                logFile.WriteLine(textBox_folderPath.Text);

                logWriteLine("=mask=");
                logFile.WriteLine(mask);

                logWriteLine("=mask_extension_toLower=");
                logFile.WriteLine(maskExt_toLower.ToString());

                logFile.WriteLine("=ignoreExt=");
                foreach (string line in ignoreExt)
                    logFile.WriteLine(line);

                logFile.WriteLine("=ignoreF=");
                foreach (string line in ignoreF)
                    logFile.WriteLine(line);

                logFile.WriteLine("===");
                logFile.WriteLine();

                logFile.Close();
            }
        }

        private void logWriteLine(string line = null)
        {
            try
            {
                using (StreamWriter logFile = new StreamWriter(logFilename, true))
                {
                    logFile.WriteLine(line);
                    logFile.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "LogFile writeLine");
            }
        }

        private void controlsEnable()
        {
            logWriteLine("Controls enabled");

            button_browse.Enabled = true;
            button_options.Enabled = true;

            textBox_folderPath.ReadOnly = false;

            button_rename.Visible = true;
            button_cancel.Visible = false;
        }

        private void controlsDisable()
        {
            logWriteLine("Controls disabled");

            button_browse.Enabled = false;
            button_options.Enabled = false;

            textBox_folderPath.ReadOnly = true;

            button_rename.Visible = false;
            button_cancel.Visible = true;
        }

        private void progressBarEnable()
        {
            logWriteLine("Progress bar enabled");

            progressBar_global.Visible = true;
            label.Visible = false;
        }

        private void progressBarDisable()
        {
            logWriteLine("Progress bar disabled");

            progressBar_global.Visible = false;
            label.Visible = true;
        }

        private void loadOptions()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + '\\' + optionsFilename))
            {
                XmlDocument xmlFile = new XmlDocument();
                xmlFile.Load(Directory.GetCurrentDirectory() + '\\' + optionsFilename);
                foreach (XmlElement node in xmlFile.DocumentElement)
                {
                    if (node.Name == "Path")
                    {
                        if (node.InnerText != null)
                            textBox_folderPath.Text = node.InnerText;
                    } else
                    if (node.Name == "Mask")
                    {
                        if (node.InnerText != null)
                            mask = node.InnerText;
                    } else
                    if (node.Name == "Mask_extension")
                    {
                        if (node.InnerText != null)
                           maskExt_toLower = (node.InnerText == "to lower") ? true : false;
                    } else
                    if (node.Name == "Extensions")
                    {
                        foreach (XmlNode childnode in node.ChildNodes)
                        {
                            if (childnode.InnerText != string.Empty)
                                ignoreExt.Add( optionsExtAllowed(childnode.InnerText) );
                        }
                    } else
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

        private string optionsExtAllowed(string ext)
        {
            string out_ext = string.Empty;
            foreach (char c in ext.ToLower())
            {
                if ((c >= 'a' && c <= 'z') ||
                    (c >= '0' && c <= '9'))
                {
                    out_ext += c;
                }
            }
            return out_ext;
        }

        private void recursionFindAll(string path)
        {
            if (backgroundWorker.CancellationPending)
                return;

            if (checkFilesExist(path))
            {
                folders.Add(path);
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
                            logWriteLine("Skip directory: " + folder);
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

        private void renameFiles_allFolders()
        {
            foreach (string folder in folders)
            {
                renameFiles(folder);
            }
        }

        private void renameFiles(string path)
        {
            if (backgroundWorker.CancellationPending)
                return;

            logWriteLine();
            logWriteLine("Processing in " + path);

            int counter = 0;
            int skip_byName = 0;
            int skip_byExt = 0;
            List<string> tempFolder_files = new List<string>();
            List<string> files_comeBack = new List<string>();

            tempFolderClean(path);
            getSortedFiles(path);            

            foreach (string file in files)
            {
                if (skipFile_name(file, counter.ToString()))
                {
                    counter++;
                    skip_byName++;
                    //logWriteLine("Skip file: " + file);
                    continue;                    
                }
                if (skipFile_ext(file))
                {
                    skip_byExt++;
                    //logWriteLine("Skip file: " + file);
                    continue;
                }

                string filename_full = counter + Path.GetExtension(file).ToLower();

                try
                {
                    File.Move(file, path + "\\_temp\\" + filename_full);
                }
                catch (Exception e)
                {
                    logWriteLine("Can not move file from: " + file + 
                        " to: " + path + "\\_temp\\" + filename_full + 
                        "; Exeption: " + e.Message);
                }

                tempFolder_files.Add(path + "\\_temp\\" + filename_full);
                files_comeBack.Add(path + '\\' + filename_full);
                counter++;                
            }

            if (counter > 0)
            {                
                counter = 0;
                foreach (string file in tempFolder_files)
                {
                    try
                    {
                        File.Move(file, files_comeBack[counter]);
                    }
                    catch (Exception e)
                    {
                        logWriteLine("Can not move file from: " + file + 
                            " to: " + files_comeBack[counter] + 
                            "; Exeption: " + e.Message);
                    }

                    filesCountCurrent++;
                    counter++;

                    backgroundWorker.ReportProgress( (filesCountCurrent * 100)/filesCountAll );
                }
            }

            logWriteLine(counter + " file\'s processed; Skiped by name: " + skip_byName + ", skip by extension: " + skip_byExt);
            tempFolderDelete(path);
        }

        private bool skipFile_name(string filePath, string correctName)
        {            
            if (Path.GetFileNameWithoutExtension(filePath) == correctName)
            {                
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool skipFile_ext(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            foreach (string ext in ignoreExt)
            {
                if ('.' + ext == extension)
                {
                    filesCountAll--;
                    return true;
                }
            }
            return false;
        }

        private void tempFolderClean(string path)
        {
            tempFolderDelete(path);

            try
            {
                Directory.CreateDirectory(path + "\\_temp");
            }
            catch(Exception e)
            {
                logWriteLine("Can not create _temp directory: " + path + "\\temp; Exeption:" + e.Message);
            }
        }

        private void tempFolderDelete(string path)
        {
            if (Directory.Exists(path + "\\_temp"))
            {
                try
                {
                    Directory.Delete(path + "\\_temp");
                    logWriteLine("Delete _temp directory: " + path + "\\_temp");
                }
                catch (Exception e)
                {
                    logWriteLine("Can not delete _temp directory: " + path + "\\temp; Exeption:" + e.Message);
                }
            }
        }

        private void getSortedFiles(string path)
        {
            if (files != null)
            {
                files.Clear();
            }
            files = Directory.GetFiles(path).OrderBy(f => new FileInfo(f).Length).ToList();
            //магическая строка, якобы сортирующая файлы по размеру
        }

        private bool checkFilesExist(string path)
        {
            List<string> f = Directory.GetFiles(path).ToList();
            filesCountAll += f.Count;
            return f.Count > 0 
                ? true: false;            
        }

        private void selectFolder()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (textBox_folderPath.Text != string.Empty)
                {
                    folderDialog.SelectedPath = textBox_folderPath.Text;
                }
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox_folderPath.Text = folderDialog.SelectedPath;
                }
            }
        }        
    }
}
