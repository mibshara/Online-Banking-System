<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     <%--Modified the header to say welcome to bank of bit--%>
    <h2>
       Welcome to Bank of BIT
    </h2>
    <%--Modified this content to show what the bank of bit offers--%>
    <p>
        Bank of BIT offers online banking features such as bill payments and money transfers.
    </p>
    <%--Removed the following content--%>
    <%--<p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>--%>
</asp:Content>
