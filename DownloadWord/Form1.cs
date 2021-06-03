using DownloadWord.CreateWordDocument;
using System;
using System.Windows.Forms;

namespace DownloadWord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WordDocument wordDocument = new WordDocument();
            wordDocument.CreateWordDocument();
        }

    }
}
