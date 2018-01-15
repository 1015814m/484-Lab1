using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ApplicationDriver : System.Web.UI.Page
{
    public static Employee[] employeeArray = new Employee[3];
    public static int count = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        

    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        //Check that the name doesnt exist in the DB already


        //Create the new entry in the array
        employeeArray[count++] = new Employee(int.Parse(txtEmployeeID.Value),txtFirstName.Value, txtLastName.Value, txtMI.Value, txtHouseNum.Value, txtStreet.Value, txtCounty.Value, txtState.Value, txtCountry.Value, txtZip.Value,
            DateTime.Parse(txtDOB.Value), DateTime.Parse(txtHireDate.Value), DateTime.Parse(txtTerminationDate.Value), Double.Parse(txtSalary.Value), int.Parse(txtManagerID.Value),
            "John Morrissey", DateTime.Now);
        resultMessage.Text += " The constructor was called";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        //Clear the text fields
        txtFirstName.Value = "";
        txtLastName.Value = "";
        txtMI.Value = "";
        txtDOB.Value = "";
        txtHouseNum.Value = "";
        txtStreet.Value = "";
        txtState.Value = "";
        txtCounty.Value = "";
        txtCountry.Value = "";
        txtZip.Value = "";
        txtHireDate.Value = "";
        txtTerminationDate.Value = "";
        txtSalary.Value = "";
        txtManagerID.Value = "";
        txtEmployeeID.Value = "";



    }

    protected void btnCommit_Click(object sender, EventArgs e)
    {
        deleteFromDB();
        for (int i = 0; i < count; i++)
        {
            insertIntoDB(employeeArray[i]);
            resultMessage.Text += "Committed";
        }
    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        
    }

    private void deleteFromDB()
    {
        //When the program runs initially it should delete all the info in the tables
        try
        {

            //Creates a new sql connection and links the application to the lab 1 database
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost; Database=Lab1;Trusted_Connection=Yes;";

            //Opens the sql connection
            sc.Open();

            //Deletes all of the information in the Database table Employee
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sc;
            insert.CommandText = "delete from [dbo].[EMPLOYEE]";
            insert.ExecuteNonQuery();

            sc.Close();

        }
        catch (Exception c)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "Database Error";
            resultMessage.Text += c.Message;
        }
    }

    private void insertIntoDB(Employee a)
    {
        
        //When the program runs initially it should delete all the info in the tables
        try
        {
            
            //Creates a new sql connection and links the application to the lab 1 database
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost; Database=Lab1;Trusted_Connection=Yes;";
            
            //Opens the sql connection
            sc.Open();
            
            //Creates a new sql insert command to insert the data from the arrays into the Employee table
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sc;
            insert.CommandText = "insert into [dbo].[EMPLOYEE] values (" + a.EmployeeID + ", '" + a.FirstName + "','" + a.LastName + "','" + a.MiddleName + "','" + a.HouseNum + "','"
                    + a.Street + "','" + a.County + "','" + a.State + "','" + a.Country + "','" + a.Zip + "','" + a.DateOfBirth + "','" + a.HireDate + "','" + a.TerminationDate + "',"
                    + a.Salary + "," + a.ManagerID + ",'" + a.LastUpdatedBy + "','" + a.LastUpdated + "')";
            insert.ExecuteNonQuery();
            
            sc.Close();

        }
        catch (Exception c)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "Database Error";
            resultMessage.Text += c.Message;
        }
        
        
    }

    
    
}