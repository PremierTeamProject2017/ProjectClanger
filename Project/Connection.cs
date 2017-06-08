using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    class Connection
    {
        //The get and set methods for the sql_string
        public string sql_string { get; set; }
        //Sets the connection string to connect to the database
        private string strCon = "Server=COB09PC;Database=PremierInsurance;Trusted_Connection=Yes;";
        //Creates an SQL data adapter
        SqlDataAdapter da_1 = new SqlDataAdapter();
        public DataSet GetConnection
        {
            get { return MyDataSet(); }
        }

        //public string StrCon { get => strCon; set => strCon = value; }

        public DataSet MyDataSet()
        {
            try
            {
                //Creates a connection using the connection string
                SqlConnection con = new SqlConnection(strCon);
                //Opens the connection
                con.Open();
                //creates a new SQL data adapter
                da_1 = new SqlDataAdapter(sql_string, con);
                //Creates a data set
                DataSet dat_set = new DataSet();
                //Fills the dataset
                da_1.Fill(dat_set);
                //Closes the connection
                con.Close();
                //Returns the dataset
                return dat_set;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public void UpdatePassword(string passwordIn, string userIDIn)
        {
            //Creates the SQL query string
            sql_string = "UPDATE UserLogin SET Password = '" + passwordIn + "' WHERE userID = '" + userIDIn + "';";
            //Calls the Run_Query method passing in the sql_string
            Run_Query(sql_string);
        }
        public void AddToPolicy(string PolicyStartDateIn, string PolicyEndDateIn,string CustomerIDIn,string NamedDriverIn,string CarIDIn,string levelOfCoverIn, string AverageMilageIn, string QuoteIn)
        {
            sql_string = "INSERT INTO Policy (PolicyStartDate,PolicyEndDate,CustomerID,NamedDriver,CarID,LevelOfCover,AverageMileage, Quote) VALUES ( '" + PolicyStartDateIn + "', '" + PolicyEndDateIn + "', '" + CustomerIDIn + "', '" + NamedDriverIn + "', '" + CarIDIn + "', '" + levelOfCoverIn +"', '" + AverageMilageIn + "' , '" + QuoteIn + "')";
            Run_Query(sql_string);
        }
        public void AddToCar(string CarRegIn, string CarChasisNumberIn, string CarMakeIn, string CarModelIn, string CarEngineSizeIn, string EstimatedWorthIn)
        {       
            sql_string = "INSERT INTO Car (CarReg,CarChasisNo,CarMake,CarModel,CarEngineSize,CarEstWorth) VALUES ('" + CarRegIn + "', '" + CarChasisNumberIn + "', '" + CarMakeIn + "','" + CarModelIn + "','" + CarEngineSizeIn + "','"+ EstimatedWorthIn + "')";
            Run_Query(sql_string);
        }
        public void AddToCustomer(string FirstNameIn, string SurnameIn, string TitleIn, string street, string TownIn, string CountyIn, string EircodeIn, string DateOfBirthIn, string ContactNumberIn, string LicenceTye, string LicenceNoIn, string LicenceIssuedIn, string PenaltyPointsIn, string NoClaimsBonusIn)
        {
            sql_string = "INSERT INTO Customer (CustomerFirstName,CustomerSurname,CustomerTitle,CustomerStreet,CustomerTown,CustomerCounty,CustomerEirCode,CustomerDOB,CustomerContactNo,CustomerLicenceType,CustomerLicenceNo,CustomerLicenceIssued,CustomerPenaltyPoints,CustomerNoClaims) VALUES ('" + FirstNameIn + "','" + SurnameIn + "','" + TitleIn + "','" + street + "','" + TownIn + "','" + CountyIn + "','" + EircodeIn + "','" + DateOfBirthIn + "','" + ContactNumberIn + "','" + LicenceTye + "','" + LicenceNoIn + "','" + LicenceIssuedIn + "','" + PenaltyPointsIn + "','" + NoClaimsBonusIn + "')";
            Run_Query(sql_string);
        }
        public void UpdateLoginDB(string userIDIn, string accessLevelIn, string isRestrictedIn, string userFirstNameIn, string userSurnameIn, string userEmailIn)
        {
            //Creates the SQL query string
            sql_string = "UPDATE UserLogin SET AccessLevel = '" + accessLevelIn + "', isRestricted = '" + isRestrictedIn + "', userFirstName = '" + userFirstNameIn + "', userSurname = '" + userSurnameIn + "', userEmail = '" + userEmailIn + "' WHERE userID = '" + userIDIn + "';";
            //Calls the Run_Query method passing in the sql_string
            Run_Query(sql_string);
        }
        public void AddToLoginDB(string userNameIn, string passwordIn, string accessLevelIn, string userFirstNameIn, string userSurnameIn, string userEmailIn)
        {
            //Creates the SQL query string
            sql_string = "INSERT INTO UserLogin (UserName, Password, AccessLevel, IsRestricted, UserFirstName, UserSurname, UserEmail, LoginAttempts) VALUES ('" + userNameIn + "', '" + passwordIn + "', '" + accessLevelIn + "', 'True' , '" + userFirstNameIn + "', '" + userSurnameIn + "', '" + userEmailIn + "', '1')";
            //Calls the Run_Query method passing in the sql_string
            Run_Query(sql_string);
        }

        public void DeleteFromLoginDB(string userIDIn)
        {
            //Creates the SQL query string
            sql_string = "DELETE FROM UserLogin WHERE userID = '" + userIDIn + "';";
            //Calls the Run_Query method passing in the sql_string
            Run_Query(sql_string);
        }
        public void AddToDB(string holidayNoIn, string destinationIn, string costIn, string departureDateIn, string noOfDaysIn, string availableIn)
        {
            //Splits the date string into day, month and year to pass into the SQL suery
            string[] dates = departureDateIn.Split('/');
            string dayIn = dates[0];
            string monthIn = dates[1];
            string yearIn = dates[2];
            //Creates the SQL query string
            sql_string = "INSERT INTO tblHoliday (HolidayNo, Destination, Cost, DepartureDate, NoOfDays, Available) VALUES ('" + holidayNoIn + "', '" + destinationIn + "', '" + costIn + "', CAST('" + yearIn + "-" + monthIn + "-" + dayIn + "' AS DATE), '" + noOfDaysIn + "', '" + availableIn + "')";
            //Calls the Run_Query method passing in the sql_string
            Run_Query(sql_string);
        }

        public void UpdateDB(string originalHolidayNumber, string newHolidayNumberIn, string destinationIn, string costIn, string departureDateIn, string noOfDaysIn, string availableIn)
        {
            //Splits the date string into day, month and year to pass into the SQL suery
            string[] dates = departureDateIn.Split('/');
            string dayIn = dates[0];
            string monthIn = dates[1];
            string yearIn = dates[2];
            //Creates the SQL query string
            sql_string = "UPDATE tblHoliday SET HolidayNo = '" + newHolidayNumberIn + "', Destination = '" + destinationIn + "', Cost = '" + costIn + "', DepartureDate = CAST('" + yearIn + "-" + monthIn + "-" + dayIn + "' AS DATE), NoOfDays = '" + noOfDaysIn + "', Available = '" + availableIn + "' WHERE HolidayNo = '" + originalHolidayNumber + "';";
            //Calls the Run_Query method passing in the sql_string
            Run_Query(sql_string);
        }

        public void DeleteFromDB(string holidayNoIn)
        {
            //Creates the SQL query string
            sql_string = "DELETE FROM tblHoliday WHERE HolidayNo = '" + holidayNoIn + "';";
            //Calls the Run_Query method passing in the sql_string
            Run_Query(sql_string);
        }

        void Run_Query(string sQuery)
        {
            //Sets the sql_string
            sql_string = sQuery;
            //Creates an SQL command passing in the sql_string
            SqlCommand cmd = new SqlCommand(sql_string);
            //Creates an sql connection
            SqlConnection con = new SqlConnection(strCon);
            //opens the connection, runs the query and closes the connection again.
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}