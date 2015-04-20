<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Modifier.aspx.cs" Inherits="TP1_2_David_Rodier.Modifier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" runat="server">
        <link rel="stylesheet" type="text/css" href="Inscription_CSS.css"/>
    <div id="body">
    <table id="table">
        <tr>
            <td>
                <table>
                    <tr>
                        <td><span>Nom au complet</span></td><td><asp:TextBox runat="server" ID="TB_Name" class="TextBox" /></td>
                        <td><asp:RequiredFieldValidator runat="server" ID="RFV_Name" ControlToValidate="TB_Name" ErrorMessage="Aucun nom entré" ValidationGroup="Subscribe_Validation" Text="!"/></td>
                    </tr>
                    <tr>
                        <td><span>Nom d'usage</span></td><td><asp:TextBox runat="server" ID="TB_Username" class="TextBox" /></td>
                        <td><asp:RequiredFieldValidator runat="server" ID="RFV_Username" ControlToValidate="TB_Username" ErrorMessage="Aucun Username entré" ValidationGroup="Subscribe_Validation" Text="!"/></td>
                    </tr>
                    <tr>
                        <td><span>Mot de passe</span></td><td><asp:TextBox runat="server" ID="TB_Password" class="TextBox" /></td>
                        <td><asp:RequiredFieldValidator runat="server" ID="RFV_Password" ControlToValidate="TB_Password" ErrorMessage="Aucun Password entré" ValidationGroup="Subscribe_Validation" Text="!"/></td>
                    </tr>
                    <tr>
                        <td><span>Adresse de courriel</span></td><td><asp:TextBox runat="server" ID="TB_Email" class="TextBox" /></td>
                        <td><asp:RequiredFieldValidator runat="server" ID="RFV_Email" ControlToValidate="TB_Email" ErrorMessage="Aucune adresse entré" ValidationGroup="Subscribe_Validation" Text="!"/></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" Text="Modifier..." class="submitButton" ValidationGroup="Subscribe_Validation" OnClick="BTN_Submit_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" Text="Annuler..." ValidationGroup="Subscribe_Validation" class="submitButton" PostBackUrl="~/Index.aspx"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr> 
            <td colspan="3" style="text-align:left;"> <asp:ValidationSummary ID="VGS_Logi" runat="server" ValidationGroup="Subscribe_Validation" HeaderText="Résumé des erreurs: &lt;hr/&gt;" /> </td> 
        </tr>
    </table>
    </div>
</asp:Content>
