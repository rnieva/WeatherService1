<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebWeatherCompare.aspx.cs" Inherits="WeatherService1.WebWeatherCompare"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 552px">
    <form id="form1" runat="server">
    <div style="height: 535px">
        <asp:Table ID="Table1" 
            runat="server" 
            Font-Size="X-Large" 
            Width="786px" 
            Font-Names="Times New Roman"
            BackColor=""
            BorderColor="black"
            BorderWidth="2"
            ForeColor=""
            CellPadding="5"
            CellSpacing="2"
            >
            <asp:TableRow 
                ID="TableRow1" 
                runat="server" 
                BackColor=""
                >
                <asp:TableCell> Select Country 1: 
                        <asp:DropDownList ID="DropDownList1Countries" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CityDropList1">
                        </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>Select Country 2: 
                        <asp:DropDownList ID="DropDownList2Countries" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CityDropList2">
                        </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow 
                ID="TableRow2" 
                runat="server" 
                BackColor=""
                >
                <asp:TableCell>Select City 1: 
                        <asp:DropDownList ID="DropDownList1Cities" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CleanLabels">
                        </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>Select City 2: 
                        <asp:DropDownList ID="DropDownList2Cities" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CleanLabels">
                        </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow 
                ID="TableRow3" 
                runat="server" 
                BackColor=""
                align="center"
                >
                <asp:TableCell></asp:TableCell>
                <asp:TableCell> 
                        <asp:Button ID="Button1Compare" runat="server" OnClick="Button1Compare_Click" Text="Compare" />
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow 
                ID="TableRow4" 
                runat="server" 
                BackColor=""
                align="center"
                >
                <asp:TableCell>
                     <asp:Label ID="LabelTemperature1" runat="server" Text="Temperature 1: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell> 
                    <asp:Label ID="LabelTemperature2" runat="server" Text="Temperature 2:"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow 
                ID="TableRow5" 
                runat="server" 
                BackColor=""
                align="center"
                >
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelResultComp" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow 
                ID="TableRow6" 
                runat="server" 
                BackColor=""
                align="center"
                >
                <asp:TableCell>
                     <asp:Button ID="Button2Info1" runat="server" OnClick="Button2Info1_Click" Text="More Info Selected 1" />
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                      <asp:Button ID="Button3Info2" runat="server" OnClick="Button3Info2_Click" Text="More Info Selected 2" />
                </asp:TableCell>
            </asp:TableRow>
               <asp:TableRow 
                ID="TableRow7" 
                runat="server" 
                BackColor=""
                >
                <asp:TableCell>
                    <asp:Label ID="LabelInfo1" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelInfo2" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableFooterRow 
                runat="server" 
                BackColor=""
                >
                <asp:TableCell 
                    ColumnSpan="15" 
                    HorizontalAlign="Right"
                    Font-Italic="true"
                    Font-Size="small" 
                    >
                    Weather Compare v1.0
                </asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>

    </div>
    </form>
</body>
</html>
