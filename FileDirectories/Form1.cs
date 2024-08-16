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

namespace FileDirectories
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowseFiles_Click(object sender, EventArgs e)
        {
            if (dlgOpenFile.ShowDialog() ==DialogResult.OK )
            {
                txtFileName.Text = dlgOpenFile.FileName;
            }
        }

        private void btnAttributes_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFileName.Text))
            {
                string s = "Attributres : " + File.GetAttributes(txtFileName.Text).ToString();
                MessageBox.Show(s,"File");
            }
            else
            {
                MessageBox.Show("File Does not exist ", "File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLastAccessed_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFileName.Text))
            {
                string sLast = "Last Accessed: " + File.GetLastAccessTime(txtFileName.Text);
                MessageBox.Show(sLast, "File");
            }
            else
            {
                MessageBox.Show("File does not exist", "file", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFileName.Text))
            {
                if (MessageBox.Show("Are you sure you want to delete this file ? ","Confirm" ,  MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                        File.Delete(txtFileName.Text);
                        txtFileName.Clear();
                }
            }
            else
            {
                MessageBox.Show("File does not exist", "File", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFileName.Text))
            {
                FileInfo f = new FileInfo(txtFileName.Text);
                string sCopy = f.DirectoryName + "\\" + f.Name.Remove(f.Name.IndexOf(".")) + "_Copy" + f.Extension;
                File.Copy(txtFileName.Text, sCopy, true);
                MessageBox.Show("File Copied ","File",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("File does not exist", "File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreated_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFileName.Text))
            {
               string s= File.GetCreationTime(txtFileName.Text).ToString();
                MessageBox.Show("Creation Time " + s, "File");
            }
            else
            {
                MessageBox.Show("File Does not exist", "file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDirectories_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            if (dlgOpenFolder.ShowDialog() == DialogResult.OK)
            {
                txtDirectories.Text = dlgOpenFolder.SelectedPath;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnListFiles_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDirectories.Text))
            {
                string s = " ";
                foreach (string sFile in Directory.GetFiles(txtDirectories.Text))
                    s += sFile + "\n";
                MessageBox.Show(s, "File Listing");

            }
            else
            {
                MessageBox.Show("Directory does not exist", "Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
