using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{

    public partial class UserDetails : Form
    {
        Generator myGen = new Generator();
        int thisint = 0;
        int saveOrEdit = 0;
        string selected = "";
        Connection connect = new Connection();
        DataSet ds;
        DataRow dr;
        public UserDetails()
        {
            thisint = UserInformation.myInt;
            saveOrEdit = UserInformation.saveOrEdit;
            InitializeComponent();
            cboAccessLevel.Items.Clear();
            cboAccessLevel.Items.Insert(0, "Admin");
            cboAccessLevel.Items.Insert(1, "Sales Rep");
            cboAccessLevel.Items.Insert(2, "Clerical");

            if (saveOrEdit == 0)
            {
                selected = UserInformation.selected;
                connect.sql_string = "SELECT * FROM UserLogin WHERE UserID = " + selected;
                ds = connect.GetConnection;
                dr = ds.Tables[0].Rows[0];

                string firstName = EncypherDecypher.Decypher(dr.ItemArray.GetValue(5).ToString());
                tbFirstName.Text = firstName;
                string surname = EncypherDecypher.Decypher(dr.ItemArray.GetValue(6).ToString());
                tbSurname.Text = surname;
                string email = EncypherDecypher.Decypher(dr.ItemArray.GetValue(7).ToString());
                tbEmail.Text = email;
                string accessLevel = dr.ItemArray.GetValue(3).ToString();
                if (accessLevel == "1")
                {
                    cboAccessLevel.SelectedIndex = 0;
                }
                else if (accessLevel == "2")
                {
                    cboAccessLevel.SelectedIndex = 1;
                }
                else
                {
                    cboAccessLevel.SelectedIndex = 2;
                }
                string isRestricted = dr.ItemArray.GetValue(4).ToString();
                if (isRestricted == "True")
                {
                    chbRestricted.Checked = true;
                }
                else
                {
                    chbRestricted.Checked = false;
                }
            }
        }

        private void UserDetails_Load(object sender, EventArgs e)
        {

            if (saveOrEdit == 1)
            {
                lblRestricted.Hide();
                chbRestricted.Hide();
                btnNewPassGen.Hide();
                tsiGenPass.Visible = false;
            }
            else
            {
                lblRestricted.Show();
                chbRestricted.Show();
                btnNewPassGen.Show();
                tsiGenPass.Visible = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveOrEdit == 1)
            {
                if (tbFirstName.Text != null && !string.IsNullOrWhiteSpace(tbFirstName.Text) && tbSurname.Text != null && !string.IsNullOrWhiteSpace(tbSurname.Text) && tbEmail.Text != null && !string.IsNullOrWhiteSpace(tbEmail.Text) && cboAccessLevel.Text != null && !string.IsNullOrWhiteSpace(cboAccessLevel.Text))
                {
                    string newFirstName = tbFirstName.Text;
                    newFirstName = EncypherDecypher.Encypher(newFirstName);
                    string newSurname = tbSurname.Text;
                    newSurname = EncypherDecypher.Encypher(newSurname);
                    string newEmail = tbEmail.Text;
                    newEmail = EncypherDecypher.Encypher(newEmail);
                    string newAccessLevel;
                    if (cboAccessLevel.SelectedIndex == 0)
                    {
                        newAccessLevel = "1";
                    }
                    else if (cboAccessLevel.SelectedIndex == 1)
                    {
                        newAccessLevel = "2";
                    }
                    else
                    {
                        newAccessLevel = "3";
                    }
                    string newUserName = myGen.genUserName();
                    string newPassword = Generator.Generate(8);
                    string encPassword = EncypherDecypher.Encypher(newPassword);
                    MessageBox.Show("Username: " + newUserName + "/nPassword: " + newPassword);

                    connect.AddToLoginDB(newUserName, encPassword, newAccessLevel, newFirstName, newSurname, newEmail);
                    this.Close();
                    UserInformation frm = new UserInformation();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Please fill out all fields before clicking save");
                }
            }
            else
            {
                if (tbFirstName.Text != null && !string.IsNullOrWhiteSpace(tbFirstName.Text) && tbSurname.Text != null && !string.IsNullOrWhiteSpace(tbSurname.Text) && tbEmail.Text != null && !string.IsNullOrWhiteSpace(tbEmail.Text) && cboAccessLevel.Text != null && !string.IsNullOrWhiteSpace(cboAccessLevel.Text))
                {
                    string updateFirstName = tbFirstName.Text;
                    updateFirstName = EncypherDecypher.Encypher(updateFirstName);
                    string updateSurname = tbSurname.Text;
                    updateSurname = EncypherDecypher.Encypher(updateSurname);
                    string updateEmail = tbEmail.Text;
                    updateEmail = EncypherDecypher.Encypher(updateEmail);
                    string updateAccessLevel;
                    if (cboAccessLevel.SelectedIndex == 0)
                    {
                        updateAccessLevel = "1";
                    }
                    else if (cboAccessLevel.SelectedIndex == 1)
                    {
                        updateAccessLevel = "2";
                    }
                    else
                    {
                        updateAccessLevel = "3";
                    }
                    string updateIsRestricted;
                    if (chbRestricted.Checked == true)
                    {
                        updateIsRestricted = "True";
                    }
                    else
                    {
                        updateIsRestricted = "False";
                    }
                    connect.UpdateLoginDB(selected, updateAccessLevel, updateIsRestricted, updateFirstName, updateSurname, updateEmail);
                    this.Close();
                    UserInformation frm = new UserInformation();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Please fill out all fields before clicking save");
                }
            }
        }

        private void btnNewPassGen_Click(object sender, EventArgs e)
        {

            string updatePassword = Generator.Generate(8);
            string updateEncPassword = EncypherDecypher.Encypher(updatePassword);
            string username = dr.ItemArray.GetValue(1).ToString();
            MessageBox.Show("Username: " + username + "\nPassword: " + updatePassword);
            connect.UpdatePassword(updateEncPassword, selected);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            UserInformation frm = new UserInformation();
            frm.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBack.PerformClick();
        }

        private void generatePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNewPassGen.PerformClick();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ETB Software Testing Team Project\nPremier Insurance App\nTeam Lead: Sunny Negi\nSenior Developer: Derek Callaghan\nJunior Developer: Adam Bonner\nSenior Tester: Martin Scanlon\nTester: Piaras Buchanan");
        }


    }
}
