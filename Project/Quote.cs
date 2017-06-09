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
    //public static double estimatedWorth;
    public partial class Quote : Form
    {
        public static double estimatedWorth;
        public static double engineSize;
        public static string licenceType;
        public static int yearOfBirth;
        public static bool noClaimsBonus;
        public static bool namedDriver;
        double temp;
        double temp2;

        public Quote()
        {
            
            InitializeComponent();
        }

        private void Quote_Load(object sender, EventArgs e)
        {
            yearOfBirth = dpDateOfBirth.Value.Year;
            cbLicenceType.Items.Add("Full");
            cbLicenceType.Items.Add("Provisional");
            
            
            //string s = tbEstimatedWorth.Text;
            
            //estimatedWorth = temp;
        }

        private void btnAppend_Click(object sender, EventArgs e)
        {
            QuoteGen i = new QuoteGen();
            i.InitialQuote();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            PolicyInformation frm = new PolicyInformation();
            frm.Show();
        }

    }
}
