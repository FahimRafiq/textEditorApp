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
using System.Collections; 

namespace textEditorApp
{   

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void newUserBtn_Click(object sender, EventArgs e)
        {
            this.Hide();

            addUser addNewUserForm = new addUser();

            // Show the settings form
            addNewUserForm.Show();
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            UserInfo user = new UserInfo(userNameBox.Text,passwordBox.Text);
            user.ReadFromText();
            bool validCredential = user.MatchUser();
            if (validCredential)
            {
                MessageBox.Show("Valid Credentials.");
                this.Hide();
                textEditorForm textEditorWindow = new textEditorForm();
                textEditorWindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid Credentials.");
                Application.Restart();
                Environment.Exit(0);
            }
            
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void userNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void trialDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trialTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class UserInfo
    {
        
        static string userName;
        static string password;
        static string userType;

        List<string> users;
        bool validCred = false;

        public UserInfo()
        {
        }
        public UserInfo(string enteredUserName,string enteredPassword )
        {
            userName = enteredUserName;
            password = enteredPassword;
            
        }

        public UserInfo(string newUserName, string newPassword, string newRePassword, string newFirstName, string newLastName, string newDatePicker,string newUserType)
        {
            ReadFromText();
            if(validateDuplicateUserName(newUserName))
            {
                if(checkPasswordMatch(newPassword, newRePassword))
                {
                    addNewUsertoLoginFile(newUserName,newPassword,newFirstName,newLastName,newDatePicker,newUserType);
                    MessageBox.Show("Successfully created new account!");
                    Application.Restart();
                    Environment.Exit(0);
                }
            }
        }

        //Read all users from the Login Text
        public void ReadFromText()
        {
            try
            {
               
                StreamReader userFile = new StreamReader("login.txt");
                users = new List<string>();
                string line = userFile.ReadLine();

                //Iterate through all the lines and add it to the list users
                while (line != null)
                {
                    users.Add(line);
                    line = userFile.ReadLine();
                }
       
                userFile.Close();
                

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                
            }
           
        }
        //function to see if user creditials are valid
        public bool MatchUser()
        {
            List<string>.Enumerator userList = users.GetEnumerator();

            while (userList.MoveNext())
            {
                string user = userList.Current;
                string[] userInfo = user.Split(',');

                if(userInfo[0] == userName && userInfo[1] == password)
                {
                    validCred = true;
                    userType = userInfo[2];
                    break;
                }
            }

            return validCred;
        }

         public bool validateDuplicateUserName(string newUserName)
        {

            List<string>.Enumerator userList = users.GetEnumerator();

            while (userList.MoveNext())
            {
                string user = userList.Current;
                string[] userInfo = user.Split(',');

                if (userInfo[0] == newUserName)
                {
                    MessageBox.Show("User name already exists. Please enter new user name.");
                    return false;
                                 
                }
            }

            return true;

        } 

        public bool checkPasswordMatch(string pass, string rePass)
        {
            if(pass != rePass)
            {
                MessageBox.Show("Password Doesn't match!");
                return false;
            }

            return true;
        }

        public void addNewUsertoLoginFile(string newUserName, string newPassword, string newFirstName, string newLastName, string newDatePicker, string newUserType)
        {
            string[] newUserInfoArray = { newUserName, newPassword, newUserType, newFirstName, newLastName, newDatePicker };
            string newUserInfo = string.Join(",", newUserInfoArray);
            try
            {
                using (StreamWriter sw = File.AppendText("login.txt"))
                {
                    //sw.WriteLine();
                    sw.WriteLine(newUserInfo);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
 
        }

        //Setter and getters for name, password and user-type
        public static string UserName{ get { return userName; }}
        public static string Password{ get { return password; }}
        public static string UserType{ get { return userType; }}

    }
}
