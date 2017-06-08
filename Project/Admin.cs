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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnPolicyInformation_Click(object sender, EventArgs e)
        {
            this.Close();
            PolicyInformation frm = new PolicyInformation();
            frm.Show();
        }

        private void btnUserInformation_Click(object sender, EventArgs e)
        {
            Admin.ActiveForm.Close();
           UserInformation frm = new UserInformation();
            frm.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Admin.ActiveForm.Close();
            Login frm = new Login();
            frm.Show();
        }

        private void userInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUserInformation.PerformClick();
        }

        private void policyInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPolicyInformation.PerformClick();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLogOut.PerformClick();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is your help");
        }
    }
}
