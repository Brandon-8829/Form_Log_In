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
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fucntion to get User information from the database and display it on the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetInfo_Click(object sender, EventArgs e)
        {
            string get = "Select Name,Email,Password,Country from Users";
            SqlConnection cnn;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bharris\source\repos\DatabaseProject\DatabaseProject\Database1.mdf;Integrated Security=True";
            cnn = new SqlConnection(connectionString);


            cnn.Open();
            SqlCommand selectCommand = new SqlCommand(get, cnn);
            SqlDataReader dataReader;

            string output = "";
            dataReader = selectCommand.ExecuteReader();
      
            while (dataReader.Read())
            {
                output += dataReader.GetValue(0).ToString() + " - " + dataReader.GetValue(1).ToString() + " - " + dataReader.GetValue(2).ToString() + " - " + dataReader.GetValue(3).ToString() + '\n';
                
            }

            DBtxt.Text = output;

            dataReader.Close();
            selectCommand.Dispose();
            cnn.Close();
        }


        /// <summary>
        /// Fucntion to Delete the user from the database. Uses CheckName() and CheckEmail() supporter functions to verify
        /// that the name and email exists as a user in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void DeleteUserBtn_Click(object sender, EventArgs e)
        {
          
            string UserName = txtDeleteName.Text;
            string UserEmail = txtDeleteEmail.Text;

            if (UserEmail.Equals(""))
            {
                MessageBox.Show("Please enter user email");
                return;
            }
            else if (UserName.Equals(""))
            {
                MessageBox.Show("Please enter user name");
                return;
            }

                /*
                 *  We need to check if the user is in the DB, if they are then we can delete. If they are not in the DB
                 *  Then we must throw an error message and quit the function.
                 */
            if (CheckName(UserName) == true && CheckEmail(UserEmail) == true)
            {
                string get = "DELETE FROM Users WHERE Name='" + UserName + "' AND Email='" + UserEmail + "'";
                SqlConnection cnn;

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bharris\source\repos\DatabaseProject\DatabaseProject\Database1.mdf;Integrated Security=True";
                cnn = new SqlConnection(connectionString);

                try
                {
                    cnn.Open();
                    SqlCommand deleteCommand = new SqlCommand(get, cnn);
                    deleteCommand.ExecuteNonQuery();

                    MessageBox.Show("User: " + UserName + " has been removed!");
                    deleteCommand.Dispose();
                    cnn.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("" + err);
                    cnn.Close();
                }
            }
            else
            {
                MessageBox.Show("User does not exist");
            }
        }


        //IGNORE
        private void label2_Click(object sender, EventArgs e)
        {


        }


        /// <summary>
        /// A supporter function that checks if the name entered is in the DB. Will return true if the Name exists, False otherwise.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckName(string name)
        {
            string get = "Select Name from Users Where Name='" + name + "'";
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bharris\source\repos\DatabaseProject\DatabaseProject\Database1.mdf;Integrated Security=True";
            string NameCheck = "";
            SqlConnection cnn = new SqlConnection(connectionString);

            cnn.Open();

            SqlCommand selectCommand = new SqlCommand(get, cnn);
            SqlDataReader dataReader;

            dataReader = selectCommand.ExecuteReader();

            //Using a while loop to read the required data from the local database.
            while (dataReader.Read())
            {
                // Put the read data into local variables to be compared
                NameCheck = dataReader.GetValue(0).ToString();
            }

            dataReader.Close();
            selectCommand.Dispose();
            cnn.Close();

            // Checks to see if the email and pass match a pair in the database.
            if (NameCheck.Equals(name))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Unsuccessful login :");
                return false;
            }
        }

        /// <summary>
        /// A supporter function that checks if the email entered exists in the DB and will 
        /// return true if the email exists, Otherwise it will return false.
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public bool CheckEmail(string Email)
        {
            string get = "Select Email from Users Where Email='" + Email + "'";
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bharris\source\repos\DatabaseProject\DatabaseProject\Database1.mdf;Integrated Security=True";
            string EmailCheck = "";
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
            }

            dataReader.Close();
            selectCommand.Dispose();
            cnn.Close();

            // Checks to see if the email and pass match a pair in the database.
            if (EmailCheck.Equals(Email))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Unsuccessful login :");
                return false;
            }
        }


        /// <summary>
        /// A function that properly closes the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }    
}
