<%--Set Site.master to be the master page file--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfClient.aspx.cs" Inherits="wfClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Client:"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblClientFullName" runat="server"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="gvClient" runat="server" AutoGenerateColumns="False" 
        AutoGenerateSelectButton="True" 
        onselectedindexchanged="gvClient_SelectedIndexChanged" Width="356px">
        <Columns>
            <asp:BoundField HeaderText="Account Number" DataField="AccountNumber" />
            <asp:BoundField HeaderText="Account Notes" DataField="Notes" />
            <asp:BoundField DataFormatString="{0:c}" HeaderText="Balance" 
                DataField="Balance">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblRate" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
</asp:Content>

