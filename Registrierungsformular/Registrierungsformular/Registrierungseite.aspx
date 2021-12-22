<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrierungseite.aspx.cs" Inherits="Registrierungsformular.Registrierungseite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 171px;
        }
        .auto-style4 {
            table-layout: auto;
            width: 180px;
        }
        .auto-style5 {
            width: 171px;
            table-layout: auto;
        }
        .auto-style6 {
            width: 171px;
            height: 3px;
        }
        .auto-style7 {
            height: 3px;
            table-layout: auto;
            width: 180px;
        }
        .auto-style8 {
            width: 180px;
        }
        .auto-style9 {
            width: 171px;
            height: 29px;
            table-layout: auto;
        }
        .auto-style10 {
            height: 29px;
            table-layout: auto;
            width: 180px;
        }
        .auto-style11 {
            width: 171px;
            table-layout: auto;
            height: 30px;
        }
        .auto-style12 {
            table-layout: auto;
            width: 180px;
            height: 30px;
        }
        .auto-style13 {
            width: 171px;
            height: 30px;
        }
    </style>
    </head>

<body>
    <form id="form1" runat="server">
        <table style="border-collapse: collapse">
            <tr>
                <td colspan="2" style="border: thin solid #CCCCCC; table-layout: auto; border-collapse: collapse; font-size: 20px; font-weight: normal; background-color: #BE1E28; color: #FFFFFF;">Registrierungsformular für die Mensa</td>
            </tr>
            <tr>
                <td class="auto-style11" style="border: thin solid #CCCCCC; ">
                    Name des Schülers:
                </td>
                <td class="auto-style12" style="border: thin solid #CCCCCC; ">
                    <asp:TextBox ID="txtStudentName" runat="server" BackColor="White" BorderStyle="None" Height="30px" ReadOnly="True" Width="180px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style11" style="border: thin solid #CCCCCC; background-color: #F9ECD7;">
                    Klasse:
                </td>
                <td class="auto-style12" style="border: thin solid #CCCCCC; background-color: #F9ECD7;">
                    <asp:TextBox ID="txtStudentClass" runat="server" BackColor="#F9ECD7" BorderStyle="None" Height="30px" ReadOnly="True" Width="180px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style11" style="border: thin solid #CCCCCC; ">
                    Schülerausweisnummer:
                </td>
                <td class="auto-style12" style="border: thin solid #CCCCCC; ">
                    <asp:TextBox ID="txtStudentID" runat="server" BackColor="White" BorderStyle="None" Height="30px" ReadOnly="True" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style13" style="border: thin solid #CCCCCC; background-color: #F9ECD7;">
                    E-Mail:
                </td>
                <td class="auto-style12" style="border: thin solid #CCCCCC; background-color: #F9ECD7;">
                    <asp:Label ID="lblEmail" runat="server" Text="Label" Height="30px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style11" style="border: thin solid #CCCCCC; ">
                    Vorname Kontoinhaber:
                </td>
                <td class="auto-style12" style="border: thin solid #CCCCCC; ">
                    <asp:TextBox ID="txtDepFirstName" placeholder ="Vorname" runat="server" BackColor="White" BorderStyle="None" Width="180px" Height="30px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" style="border: thin solid #CCCCCC; background-color: #F9ECD7;">
                    Nachname Kontoinhaber:
                </td>
                <td class="auto-style4" style="border: thin solid #CCCCCC; background-color: #F9ECD7;">
                    <asp:TextBox ID="txtDepLastname" placeholder ="Nachname" runat="server" BackColor="#F9ECD7" BorderStyle="None" Width="180px" Height="30px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style11" style="border: thin solid #CCCCCC; font-weight: bold; font-size: 24px;" colspan="2">
                    Adresse
                </td>
            </tr>
            <tr>
                <td class="auto-style1" style="border: thin solid #CCCCCC; background-color: #F9ECD7;">
                        PLZ:
                </td>
                <td class="auto-style4" style="border: thin solid #CCCCCC; background-color: #F9ECD7;">
                        <asp:TextBox ID="txtZipCode" placeholder ="Postleitzahl" runat="server" BackColor="#F9ECD7" BorderStyle="None" Width="180px" Height="30px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="border: thin solid #CCCCCC; ">
                    Ort:
                </td>
                <td class="auto-style4" style="border: thin solid #CCCCCC; ">
                    <asp:TextBox ID="txtCity" placeholder ="Ort" runat="server" BackColor="White" BorderStyle="None" Width="180px" Height="30px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" style="border: thin solid #CCCCCC; background-color: #F9ECD7;">
                    Straße:
                </td>
                <td class="auto-style4" style="border: thin solid #CCCCCC; background-color: #F9ECD7;">
                    <asp:TextBox ID="txtStreet" placeholder ="Straße" runat="server" BackColor="#F9ECD7" BorderStyle="None" Height="30px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" style="border: thin solid #CCCCCC;">
                    Hausnummer:
                </td>
                <td class="auto-style8" style="border: thin solid #CCCCCC">
                    <asp:TextBox ID="txtHouseNumber" placeholder ="Hausnummer" runat="server" BackColor="White" BorderStyle="None" Height="30px" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style11" style="border: thin solid #CCCCCC; background-color: #F9ECD7; font-size: 24px; font-weight: bold;" colspan="2">
                    Kontodaten
                </td>
            </tr>
            <tr style="background-color: #FFFFFF; border: thin solid #CCCCCC">
                <td class="auto-style6" style="border: thin solid #CCCCCC;">
                    IBAN:
                </td>
                <td class="auto-style7" style="border: thin solid #CCCCCC; ">
                    <asp:TextBox ID="txtIban" placeholder ="IBAN" runat="server" Height="30px" BackColor="White" BorderStyle="None" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9" style="border: thin solid #CCCCCC; background-color: #F9ECD7;">
                    BIC:
                </td>
                <td class="auto-style10" style="border: thin solid #CCCCCC; background-color: #F9ECD7;">
                    <asp:TextBox ID="txtBic" placeholder ="BIC" runat="server" BackColor="#F9ECD7" BorderStyle="None" Width="180px" Height="30px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div>
            <br />
            <asp:Button ID="btnPrintAndSave" runat="server" Text="Formular Drucken" OnClick="btnPrintAndSave_Click" />
        </div>
    </form>
</body>
</html>
