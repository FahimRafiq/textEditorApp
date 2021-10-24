using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using textEditorApp;

namespace textEditorApp
{
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
        }

        private void buttonewUserSubmitBtnn1_Click(object sender, EventArgs e)
        {
            try
            {
                newDatePicker.CustomFormat = "dd-MM-yyyy";
                newDatePicker.Format = DateTimePickerFormat.Custom;
                string dateOfBirth = newDatePicker.Text;

                UserInfo newUser = new UserInfo(newUserNameBox.Text, newPasswordBox.Text, newRePasswordBox.Text, newFirstNameBox.Text, newLastNameBox.Text, dateOfBirth, newUserTypeComboBox.SelectedItem.ToString());
            }catch (Exception) { MessageBox.Show("Please enter valid inputs!"); }
           
            //newUser.ReadFromText();
        }

        private void addUser_Load(object sender, EventArgs e)
        {

        }

        private void newUserCancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 logInForm = new Form1();

            // Show the settings form
            logInForm.Show();
        }
    }
}
