<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lab1.aspx.cs" Inherits="ApplicationDriver" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>John Morrissey Lab 1</title>

    <style>
        
        #Label1 {
            font-size: 200%;
        }

        .formLabel {

        }

        .longInput {
            width: 30%;
            
        }

        .mediumInput {
            width: 12%;
            
        }

        .shortInput {
            width: 5%;
            
        }

        input[type=text] {
            color: whitesmoke;
            background-color: midnightblue;
            border: none;
            border-radius: 4px;
        }

        .btn {
            margin: 5px;
            border-radius: 4px;
            background-color: midnightblue;
            color: whitesmoke;
        }

        
        .auto-style1 {
            width: 206px;
        }

        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p>
    
        <asp:Label ID="Label1" runat="server" Text="Label" >Employee Information</asp:Label>
    
    </p>
    
       
    
    <!-- This is the table that contains my user inputs 
        The user information will be seperated into 3 sections-->
    <table style="width:1000px;"  >
        <tr>
            <td class="auto-style1">First Name</td>
            <td><input id="txtFirstName" runat="server" class="longInput" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style1">Last Name</td>
            <td><input id="txtLastName" runat="server" class="longInput" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style1">MI*</td>
            <td> <input id="txtMI" runat="server" class="shortInput" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style1">DOB</td>
            <td> <input placeholder="YYYY-MM-DD" id="txtDOB" runat="server" class="mediumInput" type="text" /></td>
        </tr>
        <tr>
            <!-- Insert a line break between the first section of employee info -->
            <td class="auto-style1"><br /></td>
        </tr>

        <tr>
            <td class="auto-style1">House Number</td>
            <td> <input id="txtHouseNum" runat="server" class="mediumInput" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style1">Street</td>
            <td> <input id="txtStreet" runat="server" class="longInput" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style1">County/City</td>
            <td> <input id="txtCounty" runat="server" class="longInput" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style1">State Abb</td>
            <td> <input id="txtState" runat="server" class="shortInput" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style1">Country Abb</td>
            <td> <input id="txtCountry" runat="server" class="shortInput" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style1">Zip Code</td>
            <td> <input id="txtZip" runat="server" class="mediumInput" type="text" /></td>
        </tr>
        <tr>
            <!-- Insert a line break between the first and second section of employee info -->
            <td class="auto-style1"><br /></td>
        </tr>

        <tr>
            <td class="auto-style1">Hire Date</td>
            <td> <input id="txtHireDate" runat="server" placeholder="YYYY-MM-DD" class="mediumInput" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style1">Termination Date*</td>
            <td> <input id="txtTerminationDate" runat="server" placeholder="YYYY-MM-DD" class="mediumInput" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style1">Salary</td>
            <td> <input id="txtSalary" runat="server" placeholder="e.g. 50000" class="mediumInput" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style1">Employee ID</td>
            <td> <input id="txtEmployeeID" runat="server" class="shortInput" type="text" /> </td>
        </tr>
        <tr>
            <td class="auto-style1">Manager ID*</td>
            <td> <input id="txtManagerID" runat="server" class="shortInput" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style1">Skills</td>
            <td> <select>
                    <option value="1">This is a placeholder</option>
                    <option value="2">This is a second placeholder</option>
                    <option value="3">This is a third placeholder</option>
                 </select></td>
        </tr>
        
        
    </table>
    <p>*Fields are optional</p>
    <!-- These are the buttons that provide functionality -->
    <section>
        <asp:Button CssClass="btn" ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" />
        <asp:Button CssClass="btn" ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
        <asp:Button CssClass="btn" ID="btnCommit" runat="server" OnClick="btnCommit_Click" Text="Employee Commit" />
        <asp:Button CssClass="btn" ID="btnExit" runat="server" OnClick="btnExit_Click" Text="Exit" />


    </section>
    </form>
    <footer>
        <asp:Label ID="resultMessage" runat="server" ></asp:Label>
    </footer>
</body>

    
</html>
