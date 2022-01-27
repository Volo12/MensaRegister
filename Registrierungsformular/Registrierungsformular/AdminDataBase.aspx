<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDataBase.aspx.cs" Inherits="Registrierungsformular.AdminDataBase" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="DataBaseStyle.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="topBar">
            <table>
                <tr>
                    <td>Status: </td>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server" Height="20px" Width="200px" BackColor="Transparent"></asp:DropDownList>
                    </td>
                    <td></td>
                    <td>Klasse: </td>
                    <td>
                        <asp:DropDownList ID="ddlClass" runat="server" Height="20px" Width="200px" BackColor="Transparent"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnRun" runat="server" Text="Ausführen" OnClick="btnRun_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="sideBar">
            <br />
            <asp:Button ID="btnReturn" runat="server" Text="Daten" OnClick="btnReturn_Click" />
        </div>

        <div id="content">
            <asp:GridView ID="grvData" runat="server" Height="124px" Width="254px" CellPadding="5" Font-Bold="False" Font-Size="Small"></asp:GridView>
        </div>



    </form>
</body>
</html>
