<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">

        <asp:Panel ID="Panel2" runat="server">
            <asp:Panel ID="Panel3" runat="server">
                <asp:RadioButton ID="rdoSearch" runat="server" Text="Search" />
                <asp:RadioButton ID="rdoAdd" runat="server" Text="Add" />
                <asp:RadioButton ID="rdoDelete" runat="server" Text="Delete" />
                <asp:RadioButton ID="rdoUpdate" runat="server" Text="Update" />
            </asp:Panel>
            <asp:TextBox ID="txtYear" runat="server" OnTextChanged="TextBox1_TextChanged">Year</asp:TextBox>
            <asp:TextBox ID="txtMake" runat="server" OnTextChanged="txtMake_TextChanged">Make</asp:TextBox>
            <asp:TextBox ID="txtModel" runat="server">Model</asp:TextBox>
            <asp:TextBox ID="txtColor" runat="server">Color</asp:TextBox>
            <asp:TextBox ID="txtInterior" runat="server">Interior</asp:TextBox>
            <asp:CheckBox ID="chkEngine" runat="server" Text="Engine" />
            <asp:CheckBox ID="chkMPG" runat="server" Text="MPG" />
            <asp:CheckBox ID="chkAudio" runat="server" Text="Audio" />
            <asp:CheckBox ID="chkConvenience" runat="server" Text="Convenience" />
            <asp:CheckBox ID="chkWarranty" runat="server" Text="Warranty" />
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" />
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" style="text-align: left">
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </asp:Panel>

    </div>
</asp:Content>
