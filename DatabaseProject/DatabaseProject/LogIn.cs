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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Brings the user to the sign up page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            this.Hide();
            signUp.Show();
        }


        /// <summary>
        /// Allows the user to login to the application. It will check to see if the information eneterd is an existing user in the database.
        /// If accepeted, the user will be allowed to login using their credentials.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogInBtn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (email.Equals(""))
            {
                MessageBox.Show("Please Enter Email");
            }
            else if (password.Equals(""))
            {
                MessageBox.Show("Please Enter Password");
            }
            else
            {
                string get = "Select Email,Password from Users Where Email='" + email + "' AND Password= '" + password + "'";
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bharris\source\repos\DatabaseProject\DatabaseProject\Database1.mdf;Integrated Security=True";
                string EmailCheck = "";
                string PasswordCheck = "";
                SqlConnection cnn = new SqlConnection(connectionString);

                cnn.Open();

                SqlCommand selectCommand = new SqlCommand(get, cnn);
                SqlDataReader dataReader;

                dataReader = selectCommand.ExecuteReader();

                //Using a while loop to read the required data from the local database.
                while (dataReader.Read())
                {
                    // Put the read data into local variables to be compared
                    EmailCheck = dataReader.GetValue(0).ToString();
                    PasswordCheck = dataReader.GetValue(1).ToString();
                }

                // Checks to see if the email and pass match a pair in the database.
                if (EmailCheck.Equals(email) && PasswordCheck.Equals(password))
                {
                    MessageBox.Show("Successful Login!");

                    dataReader.Close();
                    selectCommand.Dispose();
                    cnn.Close();

                    //go to home page
                    this.Hide();
                    HomePage home = new HomePage();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("Unsuccessful login :(");
                    MessageBox.Show(EmailCheck);
                    MessageBox.Show(PasswordCheck);

                    dataReader.Close();
                    selectCommand.Dispose();
                    cnn.Close();
                }
            }
        }

        /// <summary>
        /// A function to allow admins to log in. It will check the name and password entered agaisnt the admin table. If the admin credentials exist
        /// it will allow the admin to login and bring them to the admin page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // Admin Login button, Name is not changin for some reason...
        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (email.Equals(""))
            {
                MessageBox.Show("Please Enter Email");
            }
            else if (password.Equals(""))
            {
                MessageBox.Show("Please Enter Password");
            }
            else
            {
                string get = "Select UserName,Password from Admin Where UserName='" + email + "' AND Password= '" + password + "'";
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bharris\source\repos\DatabaseProject\DatabaseProject\Database1.mdf;Integrated Security=True";
                string UserNameCheck = "";
                string PasswordCheck = "";
                SqlConnection cnn = new SqlConnection(connectionString);

                cnn.Open();

                SqlCommand selectCommand = new SqlCommand(get, cnn);
                SqlDataReader dataReader;

                dataReader = selectCommand.ExecuteReader();

                //Using a while loop to read the required data from the local database.
                while (dataReader.Read())
                {
                    // Put the read data into local variables to be compared
                    UserNameCheck = dataReader.GetValue(0).ToString();
                    PasswordCheck = dataReader.GetValue(1).ToString();
                }

                selectCommand.Dispose();
                cnn.Close();

                // Checks to see if the email and pass match a pair in the database.
                if (UserNameCheck.Equals(email) && PasswordCheck.Equals(password))
                {
                    MessageBox.Show("Successful Login!");

                    dataReader.Close();

                    //go to Admin page
                    this.Hide();
                    AdminPage admin = new AdminPage();
                    admin.Show();
                }
                else
                {
                    MessageBox.Show("Unsuccessful login :(");
                    MessageBox.Show(UserNameCheck);
                    MessageBox.Show(PasswordCheck);
                    dataReader.Close();
                }
            }
        }


        /// <summary>
        /// A funciton to properly close the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
