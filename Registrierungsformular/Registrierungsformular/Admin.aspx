<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Registrierungsformular.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Bitte wählen Sie die gescannte Datei aus.<br />
            <br />
        </div>
        <p>
            <asp:FileUpload ID="fplPDF" runat="server" />
        </p>
        <p>
            <asp:Button ID="btnSavePDF" runat="server" OnClick="btnSavePDF_Click" Text="Button" />
        </p>
        <p>
            <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
        </p>
    </form>
</body>
</html>