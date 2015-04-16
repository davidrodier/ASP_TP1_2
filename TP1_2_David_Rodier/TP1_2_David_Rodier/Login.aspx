<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP1_2_David_Rodier.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" runat="server">
    <link rel="stylesheet" type="text/css" href="Login_CSS.css"/>
    <div>
        <table>
            <tr>
                <td><asp:Label runat="server">Nom d'usager</asp:Label></td><td><asp:TextBox ID="TB_Username" runat="server"></asp:TextBox></td>
                <td><asp:CustomValidator ID="CV_TB_UserName" runat="server" ErrorMessage="Ce nom d'usager n'existe pas!" Text="!" ValidationGroup="VG_Login" OnServerValidate="CV_TB_UserName_ServerValidate"> </asp:CustomValidator></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Mot de passe</asp:Label></td><td><asp:TextBox ID="TB_Password" runat="server" TextMode="Password"></asp:TextBox></td>
                <td><asp:CustomValidator ID="CV_TB_Password" runat="server" ErrorMessage="Mot de passe invalide!" Text="!" ValidationGroup="VG_Login" OnServerValidate="CV_TB_Password_ServerValidate"> </asp:CustomValidator></td>
            </tr>
            <tr>
                <td><asp:Button runat="server" ID="Connexion" Text="Connexion" class="submitBTN"/></td>
            </tr>
            <tr>
                <td><asp:Button runat="server" ID="Inscription" Text="Inscription" class="submitBTN" PostBackUrl="~/Inscription.aspx"/></td>
            </tr>
            <tr>
                <td><asp:Button runat="server" ID="Oublie" Text="Mot de passe oublié ?" class="submitBTN" OnClick="Oublie_OnClick"/></td>
            </tr>
            <tr> 
                <td colspan="3" style="text-align:left;"> <asp:ValidationSummary ID="VGS_Logi" runat="server" ValidationGroup="VG_Login" HeaderText="Résumé des erreurs: &lt;hr/&gt;" /> </td> 
            </tr>
        </table>
     </div>
</asp:Content>