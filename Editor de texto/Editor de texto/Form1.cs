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

namespace Editor_de_texto
{
    public partial class Form1 : Form
    {
        String Archivo;
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Texto |*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Archivo = openFile.FileName;
                using (StreamReader sr = new StreamReader(Archivo))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                }
            
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Texto |*.txt";
            if(Archivo != null)
            {
                using (StreamWriter sw = new StreamWriter(Archivo))
                {
                    sw.Write(richTextBox1.Text);

                }
            }
            else
            {
                if(saveFile.ShowDialog()== DialogResult.OK)
                {
                    Archivo = saveFile.FileName;
                    using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                    {
                        sw.Write(richTextBox1.Text);
                    }
                }
            }

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Archivo = null;

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
