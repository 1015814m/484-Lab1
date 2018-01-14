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
        //When the program runs initially it should delete all the info in the tables
        try
        {
            //Creates a new sql connection and links the application to the lab 1 database
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost; Database=Lab1;Trusted_Connection=Yes;";
            
        }
        catch (Exception)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "Error Clearing Database";
        }

    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        //Check that the name doesnt exist in the DB already


        //Create the new entry in the array
        employeeArray[count] = new Employee(int.Parse(txtEmployeeID.Value),txtFirstName.Value, txtLastName.Value, txtMI.Value, txtHouseNum.Value, txtStreet.Value, txtCounty.Value, txtState.Value, txtCountry.Value, txtZip.Value,
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

    }

    protected void btnExit_Click(object sender, EventArgs e)
    {

    }

    
    
}