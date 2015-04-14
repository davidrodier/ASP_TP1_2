<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP1_2_David_Rodier.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" runat="server">
    <link rel="stylesheet" type="text/css" href="Login_CSS.css"/>
    <div>
        <table>
            <tr>
                <td><asp:Label runat="server">Nom d'usager</asp:Label></td><td><asp:TextBox ID="Username" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Mot de passe</asp:Label></td><td><asp:TextBox ID="Password" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><input type="submit" ID="Connexion" value="Connexion" class="submitBTN"/></td>
            </tr>
            <tr>
                <td><asp:Button runat="server" ID="Inscription" Text="Inscription" class="submitBTN" PostBackUrl="~/Inscription.aspx"/></td>
            </tr>
            <tr>
                <td><input type="submit" ID="Oublie" value="Mot de passe oublié ?" class="submitBTN"/></td>
            </tr>
        </table>
     </div>
</asp:Content>