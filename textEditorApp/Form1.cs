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
        public Form1() //Main form Initialized
        {
            InitializeComponent();
        }

        //Function not needed
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //New user button clicked
        private void newUserBtn_Click(object sender, EventArgs e)
        {
            this.Hide(); //Main form hidden

            addUser addNewUserForm = new addUser(); // addUser form initialized and shown

            // Show the settings form
            addNewUserForm.Show();
        }

        //Log in button clicked
        private void logInBtn_Click(object sender, EventArgs e)
        {
            UserInfo user = new UserInfo(userNameBox.Text,passwordBox.Text); //UserInfo class object initialized with input userName and Password
            user.ReadFromText(); //load all the users from login.txt
            bool validCredential = user.MatchUser(); //Check if entered credentials are valid
            if (validCredential)
            {
                MessageBox.Show("Valid Credentials.", "Enjoy the Text Editor!");
                this.Hide();
                textEditorForm textEditorWindow = new textEditorForm();
                textEditorWindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid Credentials.","Opps...", MessageBoxButtons.OK , MessageBoxIcon.Error);
                Application.Restart();
                Environment.Exit(0);
            }
            
        }

        //Exit Button clicked
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Application Closed
        }

        //Function not needed
        private void userNameBox_TextChanged(object sender, EventArgs e)
        {

        }
        //Function not needed
        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }
        //Function not needed
        private void button1_Click(object sender, EventArgs e)
        {

        }
        //Function not needed
        private void trialDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
        //Function not needed
        private void trialTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
    //UserInfo class to load and save user information and to handle login functionalities
    public class UserInfo
    {
        
        static string userName;
        static string password;
        static string userType; // Edit or View

        List<string> users; // Generic List used to save all the users from login.txt
        bool validCred = false; 

        //Constructors
        public UserInfo()
        {
        }

        //Constructer called when loggin in
        public UserInfo(string enteredUserName,string enteredPassword )
        {
            userName = enteredUserName;
            password = enteredPassword;
            
        }

        //Constructer called when adding a new user
        public UserInfo(string newUserName, string newPassword, string newRePassword, string newFirstName, string newLastName, string newDatePicker,string newUserType)
        {
            ReadFromText(); //Load all the users from login.txt

            //Check if userName already exists.
            if(validateDuplicateUserName(newUserName)) 
            {
                //Check if password matches with re-entered password
                if(checkPasswordMatch(newPassword, newRePassword))
                {
                    addNewUsertoLoginFile(newUserName,newPassword,newFirstName,newLastName,newDatePicker,newUserType); //Method called to append new user information
                    MessageBox.Show("Successfully created new account!","Congrats!");
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
                users = new List<string>(); //list to store all users
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
            List<string>.Enumerator userList = users.GetEnumerator(); //List is using Enumerator to iterate through the users

            while (userList.MoveNext())
            {
                string user = userList.Current;
                string[] userInfo = user.Split(','); //input is broken down usin the ',' deliminator 

                if(userInfo[0] == userName && userInfo[1] == password)
                {
                    validCred = true;
                    userType = userInfo[2];
                    break;
                }
            }

            return validCred;
        }

        //Check if user name already exists when creating a new user
         public bool validateDuplicateUserName(string newUserName)
        {

            List<string>.Enumerator userList = users.GetEnumerator(); //Enumerator is used to iterate through the users

            while (userList.MoveNext())
            {
                string user = userList.Current;
                string[] userInfo = user.Split(',');

                if (userInfo[0] == newUserName)
                {
                    MessageBox.Show("User name already exists. Please enter new user name.","Duplicate User Name",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                                 
                }
            }

            return true;

        } 


        //see if password matches with re-entered password
        public bool checkPasswordMatch(string pass, string rePass)
        {
            if(pass != rePass)
            {
                MessageBox.Show("Password Doesn't match!","Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        //New user informations is added to login.txt
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
                MessageBox.Show("Error!","Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }

        //Setter and getters for name, password and user-type
        public static string UserName{ get { return userName; }}
        public static string Password{ get { return password; }}
        public static string UserType{ get { return userType; }}

    }
}
