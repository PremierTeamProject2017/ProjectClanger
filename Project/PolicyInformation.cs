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
    public partial class PolicyInformation : Form
    {
        
        Connection connect = new Connection();
        DataSet ds;
        DataSet temp_ds;
        DataSet Cust_ds;
        DataSet Car_ds;
        DataSet Driver_ds;
        DataRow dRow;
        DataRow dRowCar;
        DataRow dRowCustomer;
        DataRow dRowDriver;
        int myInt = 0;
        int inc = 0;
        int AccessReceiver = 0;
        int MaxRows;
        string carReg;
        string chasisNo;
        string carMake;
        string carModel;
        string carEngineSize;
        string estimatedWorth;
        public PolicyInformation()
        {
            AccessReceiver = Login.AccessCounter;
            InitializeComponent();
            
        }
        public void NavigateRecords()
        {

        }
        private void btnAppend_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HELLO");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        public void Navigate()
        {
            
            Policy();
            Car();
            Customer();
            NewDriver();
            MaxRows = ds.Tables[0].Rows.Count;
            tbRecords.Text = (inc + 1).ToString() + " of " + MaxRows.ToString();
        }
        public void Add()
        {
            connect.AddToCar(carReg,chasisNo,carMake,carModel,carEngineSize,estimatedWorth);
        }
        public void Policy()
        {
            connect.sql_string = "SELECT * FROM Policy";
            ds = connect.GetConnection;
            dRow = ds.Tables[0].Rows[inc];
            tbPolicyId.Text = dRow.ItemArray.GetValue(0).ToString();
            dpPolicyStart.Text = dRow.ItemArray.GetValue(1).ToString();
            dpPolicyEnd.Text =  dRow.ItemArray.GetValue(2).ToString();
            if (dRow.ItemArray.GetValue(6).ToString() == "1")
            {
                cbLevelOfCover.SelectedIndex = 0;//Text = "Full Comp";
            }
            else
            {
                cbLevelOfCover.SelectedIndex = 1;
            }
            //cbLevelOfCover.Text = dRow.ItemArray.GetValue(6).ToString();
            tbAverageMilage.Text = dRow.ItemArray.GetValue(7).ToString();
            string NamedDriver = dRow.ItemArray.GetValue(4).ToString();
            if (NamedDriver != "0")
            {
                cbNamedDriver.Checked = true;
            }
            else
            {
                cbNamedDriver.Checked = false;
            }
        }
        public void Car()
        {
            string CarPol = dRow.ItemArray.GetValue(5).ToString();
            connect.sql_string = "SELECT * FROM Car WHERE CarID = " + CarPol;
            Car_ds = connect.GetConnection;
            dRowCar = Car_ds.Tables[0].Rows[0];
            String carReg = EncypherDecypher.Decypher(dRowCar.ItemArray.GetValue(1).ToString());
            tbCarRegistration.Text = carReg;
            String chasisNo = EncypherDecypher.Decypher(dRowCar.ItemArray.GetValue(2).ToString());
            tbChasisNumber.Text = chasisNo;
            String carMake = EncypherDecypher.Decypher(dRowCar.ItemArray.GetValue(3).ToString());
            tbCarMake.Text = carMake;
            String carModel = EncypherDecypher.Decypher(dRowCar.ItemArray.GetValue(4).ToString());
            tbCarModel.Text = carModel;
            String carEngineSize = EncypherDecypher.Decypher(dRowCar.ItemArray.GetValue(5).ToString());
            tbCarEngineSize.Text = carEngineSize;
            String estimatedWorth = EncypherDecypher.Decypher(dRowCar.ItemArray.GetValue(6).ToString());
            tbEstimatedWorth.Text = estimatedWorth;

            
        }
        public void Customer()
        {
            string CustPol = dRow.ItemArray.GetValue(3).ToString();
            connect.sql_string = "SELECT * FROM Customer WHERE CustomerID = " + CustPol;
            Cust_ds = connect.GetConnection;
            dRowCustomer = Cust_ds.Tables[0].Rows[0];
            String firstName = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(1).ToString());
            tbFirstName.Text = firstName;
            String Surname = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(2).ToString());
            tbSurname.Text = Surname;
            String Title = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(3).ToString());
            cbTitle.Text = Title;
            String Street = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(4).ToString());
            tbStreet.Text = Street;
            String Town = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(5).ToString());
            tbTown.Text = Town;
            String County = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(6).ToString());
            cbCounty.Text = County;
            String Eircode = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(7).ToString());
            tbEircode.Text = Eircode;
            String dateOfBirth = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(8).ToString());
            dpDateOfBirth.Text = dateOfBirth;
            String contactNumber = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(9).ToString());
            tbContactNumber.Text = contactNumber;
            String licenceType = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(10).ToString());
            cbLicenceType.Text = licenceType;
            String licenceNo = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(11).ToString());
            tbLicenceNo.Text = licenceNo;
            String licenceIssued = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(12).ToString());
            dpLicenceIssued.Text = licenceIssued;
            String penaltyPoints = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(13).ToString());
            tbPenaltyPoints.Text = penaltyPoints;
            String noClaims = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(14).ToString());
            if (noClaims.Equals("TRUE"))
            {
                cbNoClaims.Checked = true;
            }
            else
            {
                cbNoClaims.Checked = false;
            }
            
        }
        public void NewDriver()
        {
            
                string DrivePol = dRow.ItemArray.GetValue(4).ToString();
                connect.sql_string = "SELECT * FROM Customer WHERE CustomerID = " + DrivePol;
                Driver_ds = connect.GetConnection;
                var temp = dRow.ItemArray.GetValue(4);
                if (!dRow.ItemArray.GetValue(4).Equals((object)0))
                {
                    dRowDriver = Driver_ds.Tables[0].Rows[0];
                
                    
                    String firstName = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(1).ToString());
                    tbnFirstName.Text = firstName;
                    String Surname = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(2).ToString());
                    tbnSurname.Text = Surname;
                    String Title = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(3).ToString());
                    cbnTitle.Text = Title;
                    String Street = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(4).ToString());
                    tbnStreet.Text = Street;
                    String Town = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(5).ToString());
                    tbnTown.Text = Town;
                    String County = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(6).ToString());
                    cbnCounty.Text = County;
                    String Eircode = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(7).ToString());
                    tbnEircode.Text = Eircode;
                    dpnDateOfBirth.Format = DateTimePickerFormat.Custom;
                    dpnDateOfBirth.CustomFormat = "dd MMMM yyyy";
                    String dateOfBirth = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(8).ToString());
                    dpnDateOfBirth.Text = dateOfBirth;
                    String contactNumber = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(9).ToString());
                    tbnContactNumber.Text = contactNumber;
                    String licenceType = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(10).ToString());
                    cbnLicenceType.Text = licenceType;
                    String licenceNo = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(11).ToString());
                    tbnLicenceNumber.Text = licenceNo;
                    dpnLicenceIssued.Format = DateTimePickerFormat.Custom;
                    dpnLicenceIssued.CustomFormat = "dd MMMM yyyy";
                    String licenceIssued = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(12).ToString());
                    dpnLicenceIssued.Text = licenceIssued;
                    String penaltyPoints = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(13).ToString());
                    tbnPenaltyPoints.Text = penaltyPoints;
                    String noClaims = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(14).ToString());
                    if (noClaims.Equals("TRUE"))
                    {
                        cbnNoClaims.Checked = true;
                    }
                    else
                    {
                        cbnNoClaims.Checked = false;
                    }
                }
                else
                {
                    tbnFirstName.Clear();
                    tbnSurname.Clear();
                    cbnTitle.Text = (" "); 
                    tbnStreet.Clear();
                    tbnTown.Clear();
                    cbnCounty.Text = (" "); 
                    tbnEircode.Clear();
                    dpnDateOfBirth.Format = DateTimePickerFormat.Custom;
                    dpnDateOfBirth.CustomFormat = " ";
                    tbnContactNumber.Clear();
                    cbnLicenceType.Text=(" ");
                    tbnLicenceNumber.Clear();
                    dpnLicenceIssued.Format = DateTimePickerFormat.Custom;
                    dpnLicenceIssued.CustomFormat = " ";
                    tbnPenaltyPoints.Clear();
                    cbnNoClaims.Checked = false;
                }
                
        }
        private void PolicyInformation_Load(object sender, EventArgs e)
        {
            connect = new Connection();
            Navigate();
            if (AccessReceiver == 1)
            {
                btnLogOffBack.Text = "Back";
            }
            else if (AccessReceiver == 2 || AccessReceiver == 3)
            {
                btnLogOffBack.Text = "LogOff";
            }
            //ds = connect.GetConnection;

            
            //NavigateRecords();
            if(AccessReceiver == 3)
            {
                tbPolicyId.ReadOnly = true;
                cbLevelOfCover.Enabled = false;
                tbAverageMilage.ReadOnly = true;
                tbCarRegistration.ReadOnly = true;
                tbChasisNumber.ReadOnly = true;
                tbCarMake.ReadOnly = true;
                tbCarModel.ReadOnly = true;
                tbCarEngineSize.ReadOnly = true;
                tbFirstName.ReadOnly = true;
                tbSurname.ReadOnly = true;
                tbStreet.ReadOnly = true;
                tbTown.ReadOnly = true;
                tbEircode.ReadOnly = true;
                tbContactNumber.ReadOnly = true;
                tbLicenceNo.ReadOnly = true;
                tbPenaltyPoints.ReadOnly = true;
                dpPolicyEnd.Enabled = false;
                dpPolicyStart.Enabled = false;
                tbEstimatedWorth.Enabled = false;
                cbTitle.Enabled = false;
                cbCounty.Enabled = false;
                dpDateOfBirth.Enabled = false;
                cbLicenceType.Enabled = false;
                dpLicenceIssued.Enabled = false;
                cbNamedDriver.Enabled = false;
                cbNoClaims.Enabled = false;

            }
        }



        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbNamedDriver_CheckedChanged(object sender, EventArgs e)
        {
            if(cbNamedDriver.Checked==false)
            {
                tbnFirstName.ReadOnly = true;
                tbnSurname.ReadOnly = true;
                cbnTitle.Enabled = false;
                tbnStreet.ReadOnly = true;
                tbnTown.ReadOnly = true;
                tbnEircode.ReadOnly = true;
                tbnContactNumber.ReadOnly = true;
                tbnLicenceNumber.ReadOnly = true;
                tbnPenaltyPoints.ReadOnly = true;
                cbnCounty.Enabled = false;
                cbnLicenceType.Enabled = false;
                cbnNoClaims.Enabled = false;
                dpnDateOfBirth.Enabled = false;
                dpnLicenceIssued.Enabled = false;
            }
            if (cbNamedDriver.Checked == true)
            {
                tbnFirstName.ReadOnly = false;
                tbnSurname.ReadOnly = false;
                cbnTitle.Enabled = true;
                tbnStreet.ReadOnly = false;
                tbnTown.ReadOnly = false;
                tbnEircode.ReadOnly = false;
                tbnContactNumber.ReadOnly = false;
                tbnLicenceNumber.ReadOnly = false;
                tbnPenaltyPoints.ReadOnly = false;
                cbnCounty.Enabled = true;
                cbnLicenceType.Enabled = true;
                cbnNoClaims.Enabled = true;
                dpnDateOfBirth.Enabled = true;
                dpnLicenceIssued.Enabled = true;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(AccessReceiver == 1)
            {
                logOffToolStripMenuItem.Text = "Back";
            }
            else
            {
                logOffToolStripMenuItem.Text = "LogOff";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Close();
            Search_Policy frm = new Search_Policy();
            frm.Show();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (inc != 0)
            {
                inc = 0;
                Navigate();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (inc > 0)
            {
                inc--;
                Navigate();
            }
            else
            {
                MessageBox.Show("First Record");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (inc != MaxRows - 1)
            {
                inc++;
                Navigate();
            }
            else
            {
                MessageBox.Show("No More Records");
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (inc != MaxRows - 1)
            {
                inc = MaxRows - 1;
                Navigate();
            }
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOffBack_Click(object sender, EventArgs e)
        {
            if (AccessReceiver == 1)
            {
                this.Close();
                Admin frm = new Admin();
                frm.Show();
            }
            else if (AccessReceiver == 2 || AccessReceiver == 3)
            {
                this.Close();
                Login frm = new Login();
                frm.Show();
            }
        }

        private void tbnGenerateQuote_Click(object sender, EventArgs e)
        {
            Close();
            Quote frm = new Quote();
            frm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Login frm = new Login();
            frm.Show();
        }

        private void btn_AD_Click(object sender, EventArgs e)
        { 
            if (btn_AD.Text == "Add")
            {
                btn_AD.Text = "Save";
                tbPolicyId.ReadOnly = true;
                tbFirstName.Clear();
                tbSurname.Clear();
                cbTitle.Text=(" ");
                tbStreet.Clear();
                 tbTown.Clear();
                 cbCounty.Text=("");
                 tbEircode.Clear();
                 dpDateOfBirth.Format = DateTimePickerFormat.Custom;
                 dpDateOfBirth.CustomFormat = " ";
                 dpDateOfBirth.Format = DateTimePickerFormat.Custom;
                 dpDateOfBirth.CustomFormat = "dd MMMM yyyy";
                 tbContactNumber.Clear();
                 cbLicenceType.Text = (" ");
                 tbLicenceNo.Clear();
                 dpLicenceIssued.Format = DateTimePickerFormat.Custom;
                 dpLicenceIssued.CustomFormat = " ";
                 dpLicenceIssued.Format = DateTimePickerFormat.Custom;
                 dpLicenceIssued.CustomFormat = "dd MMMM yyyy";
                 tbPenaltyPoints.Clear();
                 cbNoClaims.Checked = false;

                 tbnFirstName.Clear();
                 tbnSurname.Clear();
                 cbnTitle.Text = (" ");
                 tbnStreet.Clear();
                 tbnTown.Clear();
                 cbnCounty.Text = ("");
                 tbnEircode.Clear();
                 dpnDateOfBirth.Format = DateTimePickerFormat.Custom;
                 dpnDateOfBirth.CustomFormat = " ";
                 dpnDateOfBirth.Format = DateTimePickerFormat.Custom;
                 dpnDateOfBirth.CustomFormat = "dd MMMM yyyy";
                 tbnContactNumber.Clear();
                 cbnLicenceType.Text = (" ");
                 tbnLicenceNumber.Clear();
                 dpnLicenceIssued.Format = DateTimePickerFormat.Custom;
                 dpnLicenceIssued.CustomFormat = " ";
                 dpnLicenceIssued.Format = DateTimePickerFormat.Custom;
                 dpnLicenceIssued.CustomFormat = "dd MMMM yyyy";
                 tbnPenaltyPoints.Clear();
                 cbnNoClaims.Checked = false;


                 tbPolicyId.Clear();
                 dpPolicyStart.Format = DateTimePickerFormat.Custom;
                dpPolicyStart.CustomFormat = " ";
                dpPolicyStart.Format = DateTimePickerFormat.Custom;
                dpPolicyStart.CustomFormat = "dd MMMM yyyy";
                dpPolicyEnd.Format = DateTimePickerFormat.Custom;
                dpPolicyEnd.CustomFormat = " " ;
                dpPolicyStart.Format = DateTimePickerFormat.Custom;
                dpPolicyStart.CustomFormat = "dd MMMM yyyy";
                
                cbLevelOfCover.Text = (" ");
                tbAverageMilage.Clear();
                tbQuote.Clear();

                tbCarRegistration.Clear();
                tbChasisNumber.Clear();
                tbCarMake.Clear();
                tbCarModel.Clear();
                tbCarEngineSize.Clear();
                tbEstimatedWorth.Clear(); 

            }
            else //if (btn_AD.Text == "Save")
            {
                //Add the formatting for dates
                string firstNameIn = EncypherDecypher.Encypher((tbFirstName.Text));
                string surnameIn = EncypherDecypher.Encypher(tbSurname.Text);
                string titleIn = EncypherDecypher.Encypher(cbTitle.Text);
                string streetIn = EncypherDecypher.Encypher(tbStreet.Text);
                string townIn = EncypherDecypher.Encypher(tbTown.Text);
                string countyIn = EncypherDecypher.Encypher(cbCounty.Text);
                string eircodeIn = EncypherDecypher.Encypher(tbEircode.Text);
                string dateOfBirthIn = EncypherDecypher.Encypher(dpDateOfBirth.Value.ToString("dd/MM/yyyy"));
                string contactNoIn = EncypherDecypher.Encypher(tbContactNumber.Text);
                string licenceType = EncypherDecypher.Encypher(cbLicenceType.Text);
                string licenceNoIn = EncypherDecypher.Encypher(tbLicenceNo.Text);
                string licenceIssuedIn = EncypherDecypher.Encypher(dpLicenceIssued.Value.ToString("dd/MM/yyyy"));
                string PenaltyPointsIn = EncypherDecypher.Encypher(tbPenaltyPoints.Text);
                string NoClaimsBonusIn;
                if (cbnNoClaims.Checked == true)
                {
                    NoClaimsBonusIn = "True";
                }
                else
                {
                    NoClaimsBonusIn = "False";
                }
                NoClaimsBonusIn = EncypherDecypher.Encypher(NoClaimsBonusIn);
                //Policy
                string PolicyIdIn = tbPolicyId.Text;
                string PolicyStartDateIn =  dpPolicyStart.Value.ToString("yyyy-MM-dd");
                string PolicyEndDateIn = dpPolicyStart.Value.Date.AddYears(1).ToString("yyyy-MM-dd");
                Convert.ToDateTime(PolicyStartDateIn);
                Convert.ToDateTime(PolicyEndDateIn);
                string levelOfCoverIn;
                if(cbLevelOfCover.Text == "Full Comp")
                {
                    levelOfCoverIn = "1";
                }
                else
                {
                    levelOfCoverIn = "2";
                }
                string averageMilageIn = tbAverageMilage.Text;
                string quoteIn = tbQuote.Text;
                string CustomerIDIn;
                string NamedDriverIn;
                string CarIDIn;
                //Car
                string carRegIn = EncypherDecypher.Encypher(tbCarRegistration.Text);
                string chasisNo = EncypherDecypher.Encypher(tbChasisNumber.Text);
                string carMake = EncypherDecypher.Encypher(tbCarMake.Text);
                string carModel = EncypherDecypher.Encypher(tbCarModel.Text);
                string carEngineSize = EncypherDecypher.Encypher(tbCarEngineSize.Text);
                string estimatedWorth = EncypherDecypher.Encypher(tbEstimatedWorth.Text);
                //Connection plain = new Connection();
                
                //Search if car exists       
                connect.sql_string = "SELECT * FROM Car WHERE CarReg = '" + carRegIn + "';";
                Car_ds = connect.GetConnection;
                if (Car_ds.Tables[0].Rows.Count == 0)
                {
                    connect.AddToCar(carRegIn, chasisNo, carMake, carModel, carEngineSize, estimatedWorth);
                    connect.sql_string = "SELECT * FROM Car WHERE CarReg = '" + carRegIn + "';";
                    Car_ds = connect.GetConnection;
                    DataRow dr1 = (DataRow)Car_ds.Tables[0].Rows[0];
                    CarIDIn = dr1[0].ToString();
                    Console.WriteLine("Car" + CarIDIn);
                }
                else
                {
                    DataRow dr1 = (DataRow)Driver_ds.Tables[0].Rows[0];
                    CarIDIn = dr1[0].ToString();
                }
                
                //Search if customer exists
                connect.sql_string = "SELECT * FROM Customer WHERE CustomerFirstName = '" + firstNameIn + "' and CustomerSurname = '" + surnameIn + "' and CustomerDOB = '" + dateOfBirthIn + "';";
                //MessageBox.Show("SELECT * FROM Customer WHERE CustomerFirstName = '" + firstNameIn + "', CustomerSurname = '" + surnameIn + "', CustomerDOB = '" + dateOfBirthIn + "';");
                Cust_ds = connect.GetConnection;
                if (Cust_ds.Tables[0].Rows.Count == 0)//If customer doesn't exist
                {
                    
                    connect.AddToCustomer(firstNameIn, surnameIn, titleIn, streetIn, townIn, countyIn, eircodeIn, dateOfBirthIn, contactNoIn, licenceType, licenceNoIn, licenceIssuedIn, PenaltyPointsIn, NoClaimsBonusIn);
                    connect.sql_string = "SELECT * FROM Customer WHERE CustomerFirstName = '" + firstNameIn + "' and CustomerSurname = '" + surnameIn + "' and  CustomerDOB = '" + dateOfBirthIn + "';";
                    Cust_ds = connect.GetConnection;
                    DataRow dr2 = (DataRow)Cust_ds.Tables[0].Rows[0];
                    CustomerIDIn = dr2[0].ToString();
                    Console.WriteLine("Cust" + CustomerIDIn);
                }
                else
                {
                    DataRow dr2 = (DataRow)Cust_ds.Tables[0].Rows[0];
                    CustomerIDIn = dr2[0].ToString();
                    Console.WriteLine("Customer" + CustomerIDIn);
                }
                

                //if(cbNamedDriver.Checked == false)
                //{
                string nfirstNameIn = EncypherDecypher.Encypher(tbnFirstName.Text);
                    string nsurnameIn = EncypherDecypher.Encypher(tbnSurname.Text);
                    string ntitleIn = EncypherDecypher.Encypher(cbnTitle.Text);
                    string nstreetIn = EncypherDecypher.Encypher(tbnStreet.Text);
                    string ntownIn = EncypherDecypher.Encypher(tbnTown.Text);
                    string ncountyIn = EncypherDecypher.Encypher(cbnCounty.Text);
                    string neircodeIn = EncypherDecypher.Encypher(tbnEircode.Text);
                    string ndateOfBirthIn = EncypherDecypher.Encypher(dpnDateOfBirth.Text);
                    string ncontactNoIn = EncypherDecypher.Encypher(tbnContactNumber.Text);
                    string nlicenceType = EncypherDecypher.Encypher(cbnLicenceType.Text);
                    string nlicenceNoIn = EncypherDecypher.Encypher(tbnLicenceNumber.Text);
                    string nlicenceIssuedIn = EncypherDecypher.Encypher(dpnLicenceIssued.Text);
                    string nPenaltyPointsIn = EncypherDecypher.Encypher(tbnPenaltyPoints.Text);
                    string nNoClaimsBonusIn;
                    if (cbnNoClaims.Checked == true)
                    {
                        nNoClaimsBonusIn = "True";
                    }
                    else
                    {
                        nNoClaimsBonusIn = "False";
                    }
                    nNoClaimsBonusIn = EncypherDecypher.Encypher(nNoClaimsBonusIn);
                    if (cbNamedDriver.Checked == true)
                    {
                        connect.sql_string = "SELECT * FROM Customer WHERE CustomerFirstName = '" + nfirstNameIn + "' and CustomerSurname = '" + nsurnameIn + "' and CustomerDOB = '" + ndateOfBirthIn + "';";
                        Driver_ds = connect.GetConnection;
                        if (Driver_ds.Tables[0].Rows.Count == 0)
                        {
                            connect.AddToCustomer(nfirstNameIn, nsurnameIn, ntitleIn, nstreetIn, ntownIn, ncountyIn, neircodeIn, ndateOfBirthIn, ncontactNoIn, nlicenceType, nlicenceNoIn, nlicenceIssuedIn, nPenaltyPointsIn, nNoClaimsBonusIn);
                            connect.sql_string = "SELECT * FROM Customer WHERE CustomerFirstName = '" + nfirstNameIn + "' and CustomerSurname = '" + nsurnameIn + "' and CustomerDOB = '" + ndateOfBirthIn + "';";
                            Driver_ds = connect.GetConnection;
                            DataRow dr3 = (DataRow)Driver_ds.Tables[0].Rows[0];
                            NamedDriverIn = dr3[0].ToString();
                            Console.WriteLine("NamedDriver" + NamedDriverIn);
                        }
                        else
                        {
                            DataRow dr3 = (DataRow)Driver_ds.Tables[0].Rows[0];
                            NamedDriverIn = dr3[0].ToString();
                        }
                }
                    else
                    {
                        //cbNamedDriver.Checked = false;
                        NamedDriverIn = "0";
                    }
                     connect.AddToPolicy(PolicyStartDateIn, PolicyEndDateIn, CustomerIDIn, NamedDriverIn, CarIDIn, levelOfCoverIn, averageMilageIn, quoteIn);
                     
               // }
                

            btn_AD.Text = "Add";
            MessageBox.Show("Save Successful");
            //MaxRows += 1;
            //inc = MaxRows - 1;
            Navigate();
            }
        }

        public void searchCust()
        {
            string firstName = EncypherDecypher.Encypher(tbFirstName.Text);
            string surname = EncypherDecypher.Encypher(tbSurname.Text);
            string dateOfBirth = EncypherDecypher.Encypher(dpDateOfBirth.Text);
            

            connect.sql_string = "SELECT * FROM Customer WHERE CustomerFirstName = '" + firstName + "', CustomerSurname = '" + surname + "', CustomerDOB = '" + dateOfBirth + "';";
            temp_ds = connect.GetConnection;
            

            if(temp_ds.Equals(null))
            {
                
            }
            else
            {
                DataRow dr = (DataRow)temp_ds.Tables[0].Rows[temp_ds.Tables[0].Rows.Count - 1];
                string CustomerID = dr[0].ToString();
                Console.WriteLine(CustomerID);
            }
        }
        public void searchCar()
        {
            string carReg = EncypherDecypher.Encypher(tbCarRegistration.Text);
            connect.sql_string = "SELECT CarReg FROM Car WHERE CarReg = '" + carReg + "';";
        }
        private void firstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFirst.PerformClick();
        }

        private void previousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPrevious.PerformClick();
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNext.PerformClick();
        }

        private void lastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLast.PerformClick();
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLogOffBack.PerformClick();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }
    }
}
