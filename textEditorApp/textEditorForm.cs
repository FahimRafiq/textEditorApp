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
    //Form to make the Text Editor
    public partial class textEditorForm : Form
    {
        public static string fileName; //static variable to save Filename
        public static bool fileNameExists = false; //static bool to see if filename already exists
        public textEditorForm()
        {
            InitializeComponent();
            if (UserInfo.UserType.Equals("View")) //if user type is view then richtextbox is read only
            {
                richTextBox1.ReadOnly = true;
            }

            userNameLabel.Text = UserInfo.UserName; //set userNameLabel to display username
        }

        //Log out menu button Item pressed
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 logInWindow = new Form1(); //Log in window initiazlied
            this.Hide();
            logInWindow.Show(); //Log in window shown
        }

        //rich text box set to ReadOnly mode if userType is View
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View"))
            {
                richTextBox1.ReadOnly = true; 
            }
        }

        // If new button is clicked the richTextBox1 is cleared up 
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View"))
            {

            }
            else {richTextBox1.Clear(); }

                
        }

        //Save-as button clicked in menu 
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View")) { } // View only user cannot save
            else
            {
                DialogResult dr = saveFileDialog1.ShowDialog(); //Opening saveFile Dialog
                if (dr == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text); //saving the text to the filename mentioned
                    fileName = saveFileDialog1.FileName; //Saving FileName to a static variable
                    fileNameExists = true;
                }
            }

        }

        //Open menu button pressed to create open dialog
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr =  openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName); //Open selected file
                fileName = openFileDialog1.FileName;
                fileNameExists = true;
            }
        }


        //Cut menu item 
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        //Copy menu item
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        //Paste Menu Item
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        //Help toolstrip button clicked to show About form
        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            AboutForm aboutFormWindow = new AboutForm(); //About form initiazlied
            aboutFormWindow.Show();
        }

        // New tool strip button clicked
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear(); // Existing text cleared
        }

        //Open tool strip button clicked
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }


        //Cut Tool strip Button
        private void cutToolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        //Copy Tool strip Button
        private void copyToolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        //Paste Tool strip Button
        private void pasteToolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        //About Tool strip Button
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutFormWindow = new AboutForm(); // About form initialized
            aboutFormWindow.Show();
        }

        //Save Menu button click
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View")) { } //View user-type cannot save
            else if (fileNameExists) //if FileName already in the system then just save it without dialog
            {
                File.WriteAllText(fileName, richTextBox1.Text);
            }
            else //if Filename doesn't exists
            {
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                    fileName = saveFileDialog1.FileName;
                    fileNameExists = true;
                }
            }

        }

        //Save tool strip button clicked
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

            saveToolStripMenuItem_Click(sender, e);
        }

        //Make selected text Bold
        private void boldToolStripButton_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View")) { }
            else { richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);}
            
        }
        //Make selected text Italic
        private void italicToolStripButton_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View")) { }
            else { richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Italic); }
            
        }

        //Resest selected Text
        private void underlineToolStripButton_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View")) { }
            else { richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular); }
            
        }

        //SaveAs tool tip
        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem_Click(sender, e);
        }

        //Font Size selector
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View")) { } 
            else { richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, fontComboBox.SelectedIndex + 10, richTextBox1.SelectionFont.Style); }
            
        }

        //UnderLine button pressed
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserType.Equals("View")) { }
            else { richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline); }
        }
    }
}
