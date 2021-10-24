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

namespace textEditorApp
{
    public partial class textEditorForm : Form
    {
        public textEditorForm()
        {
            InitializeComponent();
            if (UserInfo.UserType.Equals("View"))
            {
                richTextBox1.ReadOnly = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View"))
            {
                richTextBox1.ReadOnly = true; 
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if(dr == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Fahim Md Rafiq");
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void cutToolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Atomic Text Editor Version: 1.0 \nMade By Fahim Md Rafiq");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void boldToolStripButton_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View")) { }
            else { richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);}
            
        }

        private void italicToolStripButton_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View")) { }
            else { richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Italic); }
            
        }

        private void underlineToolStripButton_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View")) { }
            else { richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline); }
            
        }

        //SaveAs tool tip
        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        //Font Size selector
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View")) { } 
            else { richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, fontComboBox.SelectedIndex + 10, richTextBox1.SelectionFont.Style); }
            
        }
    }
}
