using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseProject
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// When the sign up button is clicked, it will take user information that was entered in the fields and create a new user within
        /// the DB. If the user tires to sign up when one or more fields are empty, a message box prompts the user to fill out the required
        /// fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string UserName = txtName.Text;
            string UserEmail = txtEmail.Text;
            string UserPassword = txtPassword.Text;
            string UserCountry = txtCountry.Text;

            // Simple statements to grab the information from the text boxes... We  Can probably clean this up a bit more.
            // Need to add else statements to stop the program from trying to add the user with a null field. This will throw an error.
            if (UserName.Equals("")) MessageBox.Show("Please Enter Name");
            if (UserEmail.Equals("")) MessageBox.Show("Please Enter Email");
            if (UserPassword.Equals("")) MessageBox.Show("Please Enter Password");
            if (UserCountry.Equals("")) MessageBox.Show("Please Select a Country");

            string sql = "insert into Users(Name, Email, Password, Country) values (@UserName,@UserEmail,@UserPassword,@UserCountry)";
            


            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bharris\source\repos\DatabaseProject\DatabaseProject\Database1.mdf;Integrated Security=True";
            cnn = new SqlConnection(connectionString);

            try
            {
                cnn.Open();
                MessageBox.Show("Connection Successful!");


                SqlCommand insertCommand = new SqlCommand(sql, cnn);

                insertCommand.Parameters.AddWithValue("@UserName", UserName);
                insertCommand.Parameters.AddWithValue("@UserEmail", UserEmail);
                insertCommand.Parameters.AddWithValue("@UserPassword", UserPassword);
                insertCommand.Parameters.AddWithValue("@UserCountry", UserCountry);
                insertCommand.CommandType = CommandType.Text;


                if(insertCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("User successfully added to database");
                }

                insertCommand.Dispose();
            
                cnn.Close();

                // Reset all text fields to blank.
                txtName.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtCountry.Text = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(""+err);                
                cnn.Close();

            }          
        }

        /// <summary>
        /// A function to exit the program properly when the close button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetInfo_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        /// <summary>
        /// Opens the login form to allow users and admins to log in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogInBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
            
        }
    }
}
