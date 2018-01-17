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
        selectFromDB();
        
        
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        //Check that the name doesnt exist in the DB already
        string middleInitial = "";
        string state = "";
        DateTime terminationDate = DateTime.MinValue;
        int managerID = 0;

        //if the text fields are empty then set the values to NULL
        if (txtMI.Value == "")
        {
            middleInitial = "NULL";
        }
        else
        {
            middleInitial = txtMI.Value;
        }
        if (txtState.Value == "")
        {
            state = "NULL";
        }
        else
        {
            state = txtState.Value;
        }
        if (txtTerminationDate.Value == "")
        {
            terminationDate = DateTime.MinValue;
        }
        else
        {
            terminationDate = DateTime.Parse(txtTerminationDate.Value);
        }
        if (txtManagerID.Value == "")
        {
            managerID = -1;
        }
        else
        {
            managerID = int.Parse(txtManagerID.Value);
        }
        //Create the new entry in the array
        employeeArray[count++] = new Employee(int.Parse(txtEmployeeID.Value),txtFirstName.Value, txtLastName.Value, middleInitial, txtHouseNum.Value, txtStreet.Value, txtCounty.Value, state, txtCountry.Value, txtZip.Value,
            DateTime.Parse(txtDOB.Value), DateTime.Parse(txtHireDate.Value), terminationDate, Double.Parse(txtSalary.Value), managerID,
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
        //First delete the previous data from the database
        //Then commit the employee array to the database
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
            System.Data.SqlClient.SqlConnection sqlc = connectToDB();

            //Deletes all of the information in the Database table Employee
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sqlc;
            insert.CommandText = "delete from [dbo].[EMPLOYEE]";
            insert.ExecuteNonQuery();

            sqlc.Close();

        }
        catch (Exception c)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "Database Error 0";
            resultMessage.Text += c.Message;
            
        }
    }


    private System.Data.SqlClient.SqlConnection connectToDB()
    {
        try
        {
            //Connects to the database and returns the connection
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost; Database=Lab1;Trusted_Connection=Yes";
            sc.Open();
            return sc;
        }
        catch (Exception c)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "Database Error 1";
            resultMessage.Text += c.Message;
            return null;
        }
        
    }

    private void insertIntoDB(Employee a)
    {

        //When the program runs initially it should delete all the info in the tables
        try
        {

            System.Data.SqlClient.SqlConnection sqlc = connectToDB();

            //Creates a new sql insert command to insert the data from the arrays into the Employee table
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sqlc;
            /* Create the insert statement 
             * if the user doesn't input data for the non-required fields
             * then NULL values are input into the database */
            insert.CommandText += "insert into [dbo].[EMPLOYEE] values (" + a.EmployeeID + ", '" + a.FirstName + "','" + a.LastName;
            if (a.MiddleName == "NULL")
            {
                insert.CommandText += "',NULL,'";
            }
            else
            {
                insert.CommandText += "','" + a.MiddleName + "','";
            }
            
            insert.CommandText += a.HouseNum + "','" + a.Street + "','" + a.County;
            if (a.State == "NULL")
            {
                insert.CommandText += "',NULL,'";
            }
            else
            {
                insert.CommandText += "','" + a.State + "','";
            }
            
            insert.CommandText += a.Country + "','" + a.Zip + "','" + a.DateOfBirth + "','" + a.HireDate;
            if (a.TerminationDate == DateTime.MinValue)
            {
                insert.CommandText += "',NULL,";
            }
            else
            {
                insert.CommandText += "','" + a.TerminationDate + "','";
            }
            
            insert.CommandText += a.Salary;

            if (a.ManagerID == -1)
            {
                insert.CommandText += ",NULL,'";
            }
            else
            {
                insert.CommandText += "," + a.ManagerID + ",'";
            }
            insert.CommandText += a.LastUpdatedBy + "','" + a.LastUpdated + "')";

            
            insert.ExecuteNonQuery();

            sqlc.Close();

        }
        catch (Exception c)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "Database Error 2";
            resultMessage.Text += c.Message;
        }


    }

    private void selectFromDB()
    {
        try
        {
            //Connect to the DB
            System.Data.SqlClient.SqlConnection sqlc = connectToDB();

            //Creates a new sql select command to select the data from the skills table
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.Connection = sqlc;
            select.CommandText = "select SKILLNAME from [dbo].[SKILL]";
            System.Data.SqlClient.SqlDataReader reader;

            reader = select.ExecuteReader();
            
            
            while (reader.Read())
            {                
                dropDownSkills.Items.Add(reader.GetString(0));
                
            }
            sqlc.Close();
        }
        catch (Exception c)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "Database Error 3";
            resultMessage.Text += c.Message;
        }
    }


}