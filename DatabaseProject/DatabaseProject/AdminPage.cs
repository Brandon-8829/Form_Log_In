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
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bharris\source\repos\DatabaseProject\DatabaseProject\Database1.mdf;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connectionString);


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
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bharris\source\repos\DatabaseProject\DatabaseProject\Database1.mdf;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connectionString);

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
           
            string NameCheck = "";
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bharris\source\repos\DatabaseProject\DatabaseProject\Database1.mdf;Integrated Security=True";
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
            
            string EmailCheck = "";
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bharris\source\repos\DatabaseProject\DatabaseProject\Database1.mdf;Integrated Security=True";
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

        private void AaddUserBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp page = new SignUp();
            page.Show();
        }


        /// <summary>
        /// Allows the Admin to chnage any infomraton related to the User.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditUserBtn_Click(object sender, EventArgs e)
        {
            string CurrentEmail = txtCurrentEmail.Text;
            string NewName = txtNewName.Text;
            string NewEmail = txtNewEmail.Text;
            string NewPassword = txtNewPassword.Text;
            string NewCountry = txtNewCountry.Text;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bharris\source\repos\DatabaseProject\DatabaseProject\Database1.mdf;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connectionString);

            // Check if the email entered exists as a User in the database.
            if (CurrentEmail.Equals(""))
            {
                MessageBox.Show("Please Enter A Valid User Email");
                return;
            }
            else if( CheckEmail(CurrentEmail) == false)
            {
                MessageBox.Show("The User does not exist");
                return;
            }

            // Change the name of the user to the new name entered by the admin
            if (!NewName.Equals(""))
            {
                try
                {
                    //MessageBox.Show("Updateing User...");
                    string sql = "Update Users Set Name='"+NewName+"' Where Email='"+CurrentEmail+"'";
                    cnn.Open();
                    SqlCommand NameChange = new SqlCommand(sql, cnn);

                    NameChange.ExecuteNonQuery();

                    NameChange.Dispose();
                    cnn.Close();
                }
                catch(Exception err)
                {
                    MessageBox.Show("" + err);
                }
            }

            // Change the password of the user to the new password entered by the admin
            if (!NewPassword.Equals(""))
            {
                try
                {
                    //MessageBox.Show("Updateing User...");
                    string sql = "Update Users Set Password='" + NewPassword + "' Where Email='" + CurrentEmail + "'";
                    cnn.Open();
                    SqlCommand PasswordChange = new SqlCommand(sql, cnn);

                    PasswordChange.ExecuteNonQuery();

                    PasswordChange.Dispose();
                    cnn.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("" + err);
                }
            }

            // Change the Country of the user to the new country entered by the admin
            if (!NewCountry.Equals(""))
            {
                try
                {
                    //MessageBox.Show("Updateing User...");
                    string sql = "Update Users Set Country='" + NewCountry + "' Where Email='" + CurrentEmail + "'";
                    cnn.Open();
                    SqlCommand CountryChange = new SqlCommand(sql, cnn);

                    CountryChange.ExecuteNonQuery();

                    CountryChange.Dispose();
                    cnn.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("" + err);
                }
            }

            // Change the email of the user to the new email entered by the admin.
            // The email needs to be changed last or the other changes would not occur since the email is would be different the the old email.
            if (!NewEmail.Equals(""))
            {
                try
                {
                    //MessageBox.Show("Updateing User...");
                    string sql = "Update Users Set Email='" + NewEmail + "' Where Email='" + CurrentEmail + "'";
                    cnn.Open();
                    SqlCommand EmailChange = new SqlCommand(sql, cnn);

                    EmailChange.ExecuteNonQuery();

                    EmailChange.Dispose();
                    cnn.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("" + err);
                }
            }

            // Confirm that the user information was changed.
            // We could add in another check here if we wanted to make sure the information was changed correctly.
            MessageBox.Show("User Information Updated!");
        }
    }    
}
