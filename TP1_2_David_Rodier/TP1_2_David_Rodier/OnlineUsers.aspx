<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OnlineUsers.aspx.cs" Inherits="TP1_2_David_Rodier.Gestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" runat="server">
    <div>
        <asp:Panel id="PN_GridView" runat="server"></asp:Panel>  
    </div>
    <asp:Button runat="server" PostBackURL="Index.aspx" Text="Retour..."/>
</asp:Content>
