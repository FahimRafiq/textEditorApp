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

        //Submit button is pressed
        private void buttonewUserSubmitBtnn1_Click(object sender, EventArgs e)
        {
            //Date is formattted as desired dd-mm-yyyy
            try
            {
                newDatePicker.CustomFormat = "dd-MM-yyyy";
                newDatePicker.Format = DateTimePickerFormat.Custom;
                string dateOfBirth = newDatePicker.Text;

                //UserInfo object newUser is initialized with all the necessary information
                UserInfo newUser = new UserInfo(newUserNameBox.Text, newPasswordBox.Text, newRePasswordBox.Text, newFirstNameBox.Text, newLastNameBox.Text, dateOfBirth, newUserTypeComboBox.SelectedItem.ToString());
            }catch (Exception) { MessageBox.Show("Please enter valid inputs!","Opps...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
           
            
        }


        //Function not needed
        private void addUser_Load(object sender, EventArgs e)
        {

        }

        //When Cancel Button is pressed
        private void newUserCancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 logInForm = new Form1(); //main log in form

            // Show the log in form
            logInForm.Show();
        }
    }
}
