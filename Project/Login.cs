using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Login : Form
    {
        public static int AccessCounter;
        Connection objConnect = new Connection();
        //New code
        Validation objValid = new Validation();
        //End of new code
        DataSet ds;
        DataRow dRow;
        int counter = 0;
        String warning = "Invalid Login. Please Try Again.";
        public Login()
        {
            InitializeComponent();
            tbPassword.PasswordChar = '*';
        }


        private void tb_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            /* string username = tbUsername.Text;
             string passwordFromTB = tbPassword.Text;
             string password = EncypherDecypher.Encypher(passwordFromTB);
             //new code
             if (objValid.validateUsername(username))
             {
                 if (objValid.validatePassword(passwordFromTB))
                 {
                     //end of new code
                     try
                     {
                         //Creates the sql query to be passed into the GetConnection method
                         objConnect.sql_string = "SELECT * FROM UserLogin WHERE UserName = '" + username + "'";
                         //Calls the GetConnection method to create a dataset
                         ds = objConnect.GetConnection;
                         dRow = ds.Tables[0].Rows[0];
                         //Sets up the strings used in calling the update method used to update the attempts column of the db
                         String userIDIn = (dRow.ItemArray.GetValue(0).ToString());
                         String usernameIn = (dRow.ItemArray.GetValue(1).ToString());
                         String passwordIn = (dRow.ItemArray.GetValue(2).ToString());
                         String accessLevelIn = (dRow.ItemArray.GetValue(3).ToString());
                         String isRestrictedIn = (dRow.ItemArray.GetValue(4).ToString());
                         //MessageBox.Show(isRestrictedIn);
                         String userFirstNameIn = (dRow.ItemArray.GetValue(5).ToString());
                         String userSurnameIn = (dRow.ItemArray.GetValue(6).ToString());
                         String userEmailIn = (dRow.ItemArray.GetValue(7).ToString());
                         String LoginAttemptsIn = (dRow.ItemArray.GetValue(8).ToString());
                         //Sets the boolean value to true if the sql query finds a match for the username             
                         bool userNameExists = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));
                         if (userNameExists)
                         {
                             //Sets the boolean value to true if the account has been restricted
                             bool accountRestricted = (dRow.ItemArray.GetValue(4).ToString().Equals("True"));
                             if (!accountRestricted)
                             {
                                 //Sets the boolean value to true if the password entered matches what is stored in the database
                                 bool passwordMatch = (dRow.ItemArray.GetValue(2).ToString().Equals(password));
                                 if (passwordMatch)
                                 {
                                     LoginAttemptsIn = "1";
                                     objConnect.UpdateLoginDB(userIDIn, usernameIn, passwordIn, accessLevelIn, isRestrictedIn, userFirstNameIn, userSurnameIn, userEmailIn, LoginAttemptsIn);
                                     //Checks the access level column of the matched entry and performs an action depending on what it is.
                                     if (dRow.ItemArray.GetValue(3).ToString().Equals("1"))*/
            if (tbUsername.Text.Equals("1"))
            {
                AccessCounter = 1;
                this.Hide();
                Admin frm = new Admin();
                frm.Show();
                Console.WriteLine("Admin Success!");
            }
            //else if (dRow.ItemArray.GetValue(3).ToString().Equals("2"))
            else if (tbUsername.Text.Equals("2"))
            {
                Console.WriteLine("Rank 2 Success!");
                AccessCounter = 2;
                this.Hide();
                PolicyInformation frm = new PolicyInformation();
                frm.Show();
                Console.WriteLine("Brooker Success!");
            }
            else
            {
                AccessCounter = 3;
                this.Hide();
                PolicyInformation frm = new PolicyInformation();
                frm.Show();
                Console.WriteLine("Clerk Success!");
            }/*

                                }
                                else //if username and password do not match an entry in the database
                                {
                                    String strCounter = (dRow.ItemArray.GetValue(8).ToString());
                                    counter = Int32.Parse(strCounter);
                                    if (counter == 1)
                                    {
                                        MessageBox.Show("1st login attempt failed, 2 attempts left.");
                                        tbUsername.Clear();
                                        tbPassword.Clear();
                                        LoginAttemptsIn = "2";
                                        objConnect.UpdateLoginDB(userIDIn, usernameIn, passwordIn, accessLevelIn, isRestrictedIn, userFirstNameIn, userSurnameIn, userEmailIn, LoginAttemptsIn);
                                    }
                                    else if (counter == 2)
                                    {
                                        MessageBox.Show("2nd login attempt failed, 1 attempt left.");
                                        tbUsername.Clear();
                                        tbPassword.Clear();
                                        LoginAttemptsIn = "3";
                                        objConnect.UpdateLoginDB(userIDIn, usernameIn, passwordIn, accessLevelIn, isRestrictedIn, userFirstNameIn, userSurnameIn, userEmailIn, LoginAttemptsIn);
                                    }
                                    else
                                    {
                                        MessageBox.Show("3rd and final login attempt failed. Please contact your administrator.");
                                        isRestrictedIn = "TRUE";
                                        objConnect.UpdateLoginDB(userIDIn, usernameIn, passwordIn, accessLevelIn, isRestrictedIn, userFirstNameIn, userSurnameIn, userEmailIn, LoginAttemptsIn);
                                        Process.GetCurrentProcess().Kill();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("This account has been disabled. Please contact your administrator.");
                            }//End of accountRestricted
                        }
                        else
                        {
                            MessageBox.Show(warning);
                        }//End of userNameExists
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }//End of try catch
                    //new code
                }
                else
                {
                    MessageBox.Show(warning);
                }//End of validate password
            }
            else
            {
                MessageBox.Show(warning);
            }//End of validate Username
            //end of new code*/
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Process.GetCurrentProcess().Kill();
        }
    }
}
