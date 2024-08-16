using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lstMarks.Items.Add(txtMark.Text);
            lstStudents.Items.Add(txtNames.Text);
            txtMark.Clear();
            txtNames.Clear();
            txtNames.Focus();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            dlgSaveFile.InitialDirectory = Application.StartupPath;
            dlgSaveFile.FileName = "Students.txt";
            dlgSaveFile.OverwritePrompt = false;

            if (dlgSaveFile.ShowDialog()==DialogResult.OK)
            {
                using (StreamWriter f = new StreamWriter(dlgSaveFile.FileName))
                {
                    for (int i = 0; i < lstStudents.Items.Count; i++)
                    {
                        f.Write(lstStudents.Items[i] +"\t");

                        if (i<lstMarks.Items.Count)
                        {
                            f.Write(lstMarks.Items[i] + "\n");
                        }
                    }
                }
            }
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            dlgOpenFile.InitialDirectory = Application.StartupPath;
            dlgOpenFile.FileName = "Students.txt";

            using(StreamReader f = new StreamReader(dlgOpenFile.FileName))
            {
                string sLine = "";
                string[] sFields;
                while (!f.EndOfStream)
                {
                    sLine = f.ReadLine();
                    sFields = sLine.Split('\t');
                    lstStudents.Items.Add(sFields[0]);
                    lstMarks.Items.Add(sFields[1]);
           
                }
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            string sResults="";

            for (int i = 0; i < lstStudents.Items.Count; i++)
            {
                sResults += lstStudents.Items[i] +"\t" + lstMarks.Items[i] +"\n";
            }
            MessageBox.Show(sResults, "Results", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
