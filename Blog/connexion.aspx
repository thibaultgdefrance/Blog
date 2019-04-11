<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="connexion.aspx.cs" CodeFile="connexion.aspx.cs" Inherits="Blog.connexion" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


        
        <asp:Label ID="lbLogin" runat="server" Text="Login"></asp:Label>
        
            <p>
        <asp:TextBox ID="TxtbLogin" runat="server"  onblur="verifier('TxtbLogin','lbMessage','email','BtnConnexion')" style="margin-bottom: 22px"></asp:TextBox>
        </p>
        <p>
        
            <asp:Label ID="LbPassword" runat="server" Text="Password"></asp:Label>
            </p>
        <p>
        <asp:TextBox ID="TxtbPassword" runat="server" onblur="verifier('TxtbPassword','lbMessage','password','BtnConnexion')"></asp:TextBox>
        </p>
        <p>
        <asp:Button ID="BtnConnexion" runat="server" OnClick="BtnConnexion_Click" Text="se connecter" Enabled="false"/>
        </p>
        <asp:Label ID="lbcookie" runat="server" Text="se souvenir de moi"></asp:Label>
        <asp:CheckBox ID="cbCookie" runat="server" />
        <asp:Label ID="lbMessage" runat="server" Text="Label"></asp:Label>

    </asp:Content>

