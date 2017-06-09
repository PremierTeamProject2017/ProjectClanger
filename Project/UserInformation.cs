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
    public partial class UserInformation : Form
    {
        Connection objConnect = new Connection();
        DataSet ds;
        public static int myInt = 0;
        public static int saveOrEdit = 0;
        public static string selected;
        public UserInformation()
        {
            
            InitializeComponent();
            fillData();

        }

        private void fillData()
        {
            try
            {
                cboRestricted.Items.Clear();
                cboRestricted.Items.Insert(0, "All");
                cboRestricted.Items.Insert(1, "Yes");
                cboRestricted.Items.Insert(2, "No");

                cboAccessLevel.Items.Clear();
                cboAccessLevel.Items.Insert(0, "All");
                cboAccessLevel.Items.Insert(1, "Admin");
                cboAccessLevel.Items.Insert(2, "Sales Rep");
                cboAccessLevel.Items.Insert(3, "Clerical");


                objConnect.sql_string = "SELECT * FROM UserLogin";
                ds = objConnect.GetConnection;

                dgvUsers.DataSource = ds;
                dgvUsers.VirtualMode = false;
                dgvUsers.Columns.Clear();
                dgvUsers.AutoGenerateColumns = true;
                dgvUsers.DataMember = ds.Tables[0].ToString();
                dgvUsers.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvUsers_CellFormatting);
                dgvUsers.AutoResizeColumns();
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUsers.MultiSelect = false;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Fill Data");
            }
        }

        void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 2 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 && e.RowIndex != this.dgvUsers.NewRowIndex)
                {
                    if (e != null && !String.IsNullOrEmpty(e.Value as string) && !e.ToString().Contains("="))
                    {
                        e.Value = EncypherDecypher.Decypher(e.Value.ToString());
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, e.Value.ToString());
            }
        }
       
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Close();
            //myInt = 1;
            saveOrEdit = 1;
            UserDetails frm = new UserDetails();
            frm.Show();
            
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            
            
            selected = dgvUsers.SelectedRows[0].Cells[0].Value.ToString();
            //MessageBox.Show("hh");
            this.Close();
            saveOrEdit = 0;
            //myInt = 0;
            UserDetails frm = new UserDetails();
            frm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin frm = new Admin();
            frm.Show();
        }


        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = string.Format("UserName LIKE '%{0}%'", tbUserName.Text);
            dgvUsers.DataSource = dv;
        }

        private void cboRestricted_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DataView dv = ds.Tables[0].DefaultView;
                if (cboRestricted.SelectedIndex == 1)
                {
                    dv.RowFilter = "IsRestricted = 1";
                }
                else if (cboRestricted.SelectedIndex == 2)
                {
                    dv.RowFilter = "IsRestricted = 0";
                }
                else
                {
                    dv.RowFilter = String.Empty;
                }
                dgvUsers.DataSource = dv;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void cboAccessLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DataView dv = ds.Tables[0].DefaultView;
                if (cboAccessLevel.SelectedIndex == 1)
                {
                    dv.RowFilter = "AccessLevel = 1";
                }
                else if (cboAccessLevel.SelectedIndex == 2)
                {
                    dv.RowFilter = "AccessLevel = 2";
                }
                else if (cboAccessLevel.SelectedIndex == 3)
                {
                    dv.RowFilter = "AccessLevel = 3";
                }
                else
                {
                    dv.RowFilter = String.Empty;
                }
                dgvUsers.DataSource = dv;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            selected = dgvUsers.SelectedRows[0].Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show("You have chosen to delete a users account,\nAre you sure?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                objConnect.DeleteFromLoginDB(selected);
                MessageBox.Show("Account Deleted");
                fillData();
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddUser.PerformClick();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEditUser.PerformClick();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDeleteUser.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBack.PerformClick();
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Login frm2 = new Login();
            frm2.Show();
        }

    }
}
