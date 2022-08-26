<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="CRUD.Pages.CRUD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width: 250px">
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbnombre"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Promedio</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbpromedio"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Telefono</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbtelefono"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Id_Telefono</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbidtelefono"></asp:TextBox>
            </div>
            <asp:Button runat="server" Text="Create" CssClass="btn btn-primary" ID="BtnCreate" Visible="false" OnClick="BtnCreate_Click"/>
            <asp:Button runat="server" Text="Update" CssClass="btn btn-primary" ID="BtnUpdate" Visible="false" OnClick="BtnUpdate_Click"/>
            <asp:Button runat="server" Text="Delete" CssClass="btn btn-primary" ID="BtnDelete" Visible="false" Onclick="BtnDelete_Click"/>
            <asp:Button runat="server" Text="Regresar" CssClass="btn btn-primary btn-dark" ID="BtnBack" Visible="true" OnClick="BtnBack_Click"/>
        </div>
    </form>
</asp:Content>
