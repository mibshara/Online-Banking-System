<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfTransaction.aspx.cs" Inherits="wfTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Account Number:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblAccountNumber" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Balance:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblBalance" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Transaction Type:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlTransactionType" runat="server" AutoPostBack="True" 
            Height="16px" onselectedindexchanged="ddlTransactionType_SelectedIndexChanged">
            <asp:ListItem Value="3">Bill Payment</asp:ListItem>
            <asp:ListItem Value="4">Transfer</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Amount:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" 
            ControlToValidate="txtAmount" ErrorMessage="Please enter an amount between 0.01 and 10,000" 
            MaximumValue="10000" MinimumValue="0.01" ForeColor="Red" Type="Currency"></asp:RangeValidator>
    </p>
    <p>
        <asp:Label ID="Label5" runat="server" Text="To:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlTo" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="btnCompleteTransaction" runat="server" 
            onclick="btnCompleteTransaction_Click" Text="Complete Transaction" />
    </p>
    <p>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </p>
</asp:Content>

