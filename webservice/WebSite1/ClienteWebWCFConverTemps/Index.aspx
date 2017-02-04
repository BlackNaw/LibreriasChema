<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="vertical-align: middle; font-family: Verdana, Geneva, Tahoma, sans-serif; text-align: center">
    
        Conversion entre grados Centigrados y Fahrenheit<br />
        <br />
        Grados:
        <asp:TextBox ID="ctGrados" runat="server" Width="322px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnConvertir" runat="server" Text="Convertir" Width="242px" OnClick="btConvertir_Click" />
        <br />
        <br />
        <asp:Button ID="btnDetalles" runat="server" Text="Detalles" Width="236px" OnClick="btnDetalles_Click" />
        <br />
        <br />
        <asp:RadioButtonList ID="rdButton" runat="server" Height="59px" Width="280px" TextAlign="Right" RepeatLayout="Flow">
            <asp:ListItem Selected="True" Value="0">Centigrados a Fahrenheit</asp:ListItem>
            <asp:ListItem Value="1">Fahrenheit a Centigrados</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        Error: <asp:TextBox ID="etError" runat="server" BorderStyle="None" Enabled="False" Width="199px"></asp:TextBox>
        <br />
    
    </div>
    </form>
</body>
</html>
