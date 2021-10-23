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
    }

    public class UserInfo
    {
        
        string userName;
        string password;
        string userType;

        List<string> users;
        bool validCred = false; 

        public UserInfo(string enteredUserName,string enteredPassword )
        {
            this.userName = enteredUserName;
            this.password = enteredPassword;
            
        }
        //Read all users from the Login Text
        public void ReadFromText()
        {
            try
            {
                Console.WriteLine("Hi1");
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

        //Setter and getters for name, password and user-type
        public string UserName{ get { return this.userName; }}
        public string Password{ get { return this.password; }}
        public string UserType{ get { return this.userType; }}

    }
}
