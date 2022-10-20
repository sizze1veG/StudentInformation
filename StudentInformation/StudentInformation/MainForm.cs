using System;
using System.Windows.Forms;

namespace StudentInformation
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButtonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text files (*.txt)|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFile.FileName;
                InfoForm form = new InfoForm(fileName);
                form.ShowDialog();
            }
        }

        private void metroButtonAddStudent_Click(object sender, EventArgs e)
        {
            InfoForm form = new InfoForm();
            form.ShowDialog();
        }

        private void metroButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
