<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="TP1_2_David_Rodier.Inscription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" runat="server">
    <link rel="stylesheet" type="text/css" href="Inscription_CSS.css"/>
    <div id="body">
    <table id="table">
        <tr>
            <td>
                <table>
                    <tr>
                        <td><span>Nom au complet</span></td><td><input class="TextBox" /></td>
                    </tr>
                    <tr>
                        <td><span>Nom d'usage</span></td><td><input class="TextBox" /></td>
                    </tr>
                    <tr>
                        <td><span>Mot de passe</span></td><td><input class="TextBox" /></td>
                    </tr>
                    <tr>
                        <td><span>Confirmation du mot de passe</span></td><td><input class="TextBox" /></td>
                    </tr>
                    <tr>
                        <td><span>Adresse de courriel</span></td><td><input class="TextBox" /></td>
                    </tr>
                    <tr>
                        <td><span>Confirmation de l'adresse de courriel</span></td><td><input class="TextBox" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" Text="S'inscrire..." class="submitButton"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" Text="Annuler..." class="submitButton" PostBackUrl="~/Login.aspx"/>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table>
                    <tr>
                        <td class="RightPNL">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"/>
                            <div>
                                <table>
                                    <tr>    
                                        <td colspan="2">
                                            <asp:UpdatePanel ID="PN_Captcha" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton    ID="RegenarateCaptcha" runat="server" 
                                                                            ImageUrl="~/Images/RegenerateCaptcha.png" 
                                                                            CausesValidation="False" 
                                                                            onclick="RegenarateCaptcha_Click" 
                                                                            ValidationGroup="Subscribe_Validation" 
                                                                            width="48"
                                                                            ToolTip="Regénérer le captcha..." />  
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="IMGCaptcha" imageurl="~/captcha.png" runat="server" />
                                                        </td>
                                                    </tr>
                                            </table>
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>      
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="TB_Captcha" runat="server" MaxLength="5" ></asp:TextBox>
                                            <asp:CustomValidator    ID="CV_Captcha" runat="server" 
                                                                    ErrorMessage="Code captcha incorrect!" 
                                                                    ValidationGroup="Subscribe_Validation"
                                                                    Text="!" 
                                                                    ControlToValidate="TB_Captcha" 
                                                                    onservervalidate="CV_Captcha_ServerValidate" 
                                                                    ValidateEmptyText="True">
                                                                    </asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr style="text-align:center;">
                        <td class="RightPNL"> <br/><img id="New_IMG_Avatar" class="Avatar" src="Images/Anonymous.png" style="border-width:0px;"/></td>
                    </tr>
                    <tr>
                        <td style="text-align:center;" class="RightPNL">
                            <input type="file" name="ctl00$MainMasterContent$FU_Avatar" id="FU_Avatar" onchange="PreLoadImage();" style="display:none;">
                            <input type="button" class="AvatarBrowseButton" id="uploadTrigger" onclick="document.getElementById('FU_Avatar').click();" value="Choisir...">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
