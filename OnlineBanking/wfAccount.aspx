<%--Set Site.master to be the master page file for the style--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfAccount.aspx.cs" Inherits="wfAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Client:"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblClient" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Account Number:"></asp:Label>
&nbsp;
    <asp:Label ID="lblAccountNumber" runat="server"></asp:Label>
&nbsp;
    <asp:Label ID="Label3" runat="server" Text="Balance:"></asp:Label>
&nbsp;
    <asp:Label ID="lblBalance" runat="server"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="gvAccount" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="DateCreated" DataFormatString="{0:d}" 
                HeaderText="Date" />
            <asp:BoundField DataField="Description" HeaderText="Transaction Type">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Deposit" DataFormatString="{0:c}" 
                HeaderText="Amount In">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Withdrawal" DataFormatString="{0:c}" 
                HeaderText="Amount Out">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Notes" HeaderText="Details" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:LinkButton ID="btnLinkButton" runat="server" onclick="btnLinkButton_Click">Pay Bills and Transfer Funds</asp:LinkButton>
    <br />
    <br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
</asp:Content>

