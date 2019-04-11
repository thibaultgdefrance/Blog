<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Blog.admin" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div>

            <asp:Label ID="lbAdmin" runat="server" Text="Bonjour Admin"></asp:Label>

            <asp:Button ID="btnDeconnexion" runat="server" OnClick="btnDeconnexion_Click" Text="Deconnexion" />

        </div>

</asp:Content>