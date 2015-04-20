<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TP1_2_David_Rodier.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" runat="server">
    <asp:Button runat="server" Text="Gérer votre profil..." style="position:absolute; top:100px; width:150px;" OnClick="Modifier_OnClick"/>
    <asp:Button runat="server" Text="Usagers en ligne..." style="position:absolute; top:140px; width:150px;" PostBackUrl="/OnlineUsers.aspx"/>
    <asp:Button runat="server" Text="Déconnexion..." style="position:absolute; top:180px; width:150px;" OnClick="Deco_OnClick"/>
</asp:Content>
