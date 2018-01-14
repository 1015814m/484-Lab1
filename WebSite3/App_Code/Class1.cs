using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class2
/// </summary>
public class Employee
{
    public int employeeID;
    public string fName;
    public string lName;
    public string mName;
    public string houseNum;
    public string street;
    public string county;
    public string state;
    public string country;
    public string zip;
    public DateTime dateOfBirth;
    public DateTime hireDate;
    public DateTime terminationDate;
    public double salary;
    public int managerID;
    public string updatedBy;
    public DateTime updatedDate;
    public static int count = 0;

    public Employee(int employeeID, string fName, string lName, string mName, string houseNum, string street, string county, string state, string country, string zip,
        DateTime dateOfBirth, DateTime hireDate, DateTime terminationDate, double salary, int managerID, string updatedBy, DateTime updatedDate)
    {
        setEmployeeID(employeeID);
        setfName(fName);
        setlName(lName);
        setmName(mName);
        setHouseNum(houseNum);
        setStreet(street);
        setCounty(county);
        setState(state);
        setCountry(country);
        setZip(zip);
        setDateOfBirth(dateOfBirth);
        setHireDate(hireDate);
        setTerminationDate(terminationDate);
        setSalary(salary);
        setManagerID(managerID);
        setUpdatedBy(updatedBy);
        setUpdatedDate(updatedDate);
        count++;

    }
    public void setEmployeeID(int employeeID)
    {
        this.employeeID = employeeID;
    }
    public void setfName(string fName)
    {
        this.fName = fName;
    }
    public void setlName(string lName)
    {
        this.lName = lName;
    }
    public void setmName(string mName)
    {
        this.mName = mName;
    }
    public void setHouseNum(string houseNum)
    {
        this.houseNum = houseNum;
    }
    public void setStreet(string street)
    {
        this.street = street;
    }
    public void setCounty(string county)
    {
        this.county = county;
    }
    public void setState(string state)
    {
        this.state = state;
    }
    public void setCountry(string country)
    {
        this.country = country;
    }
    public void setZip(string zip)
    {
        this.zip = zip;
    }
    public void setDateOfBirth(DateTime dateOfBirth)
    {
        this.dateOfBirth = dateOfBirth;
    }
    public void setHireDate(DateTime hireDate)
    {
        this.hireDate = hireDate;
    }
    public void setTerminationDate(DateTime terminationDate)
    {
        this.terminationDate = terminationDate;
    }
    public void setSalary(double salary)
    {
        this.salary = salary;
    }
    public void setManagerID(int managerID)
    {
        this.managerID = managerID;
    }
    public void setUpdatedBy(string updatedBy)
    {
        this.updatedBy = updatedBy;
    }
    public void setUpdatedDate(DateTime updatedDate)
    {
        this.updatedDate = updatedDate;
    }
}