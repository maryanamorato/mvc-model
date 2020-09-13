<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLivros.aspx.cs" Inherits="POO3B127.UI.FrmLivros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <title>Formulário Livro</title>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div class="form-group">
                <asp:Label runat="server" Text="Título" for="txtTitulo" />
                <asp:TextBox ID="txtTitulo" runat="server" class="form-control" aria-describedby="emailHelp" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Autor" for="drpAutor" />
                <asp:DropDownList runat="server" ID="drpAutor" class="form-control" aria-describedby="emailHelp" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Editora" for="drpEditora" />
                <asp:DropDownList runat="server" ID="drpEditora"  class="form-control" aria-describedby="emailHelp" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Data de Cadastro" for="txtDataCadastro" />
                <asp:TextBox ID="txtDataCadastro" runat="server"  class="form-control" aria-describedby="emailHelp" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Número de páginas" for="txtNumPaginas" />
                <asp:TextBox ID="txtNumPaginas" runat="server"  class="form-control" aria-describedby="emailHelp" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Valor" for="txtValor" />
                <asp:TextBox ID="txtValor" runat="server"  class="form-control" aria-describedby="emailHelp" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click"   class="btn btn-primary btn-block"/>
            </div>
            <asp:GridView ID="GridLivro" CssClass="table table-striped" runat="server" OnRowDeleting="GridLivro_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="GridLivro_RowCancelingEdit" OnRowEditing="GridLivro_RowEditing" OnRowUpdating="GridLivro_RowUpdating">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowEditButton="True" headerText="Editar" />
                    <asp:CommandField ShowDeleteButton="True" headerText="Excluir" />
                </Columns>
            </asp:GridView>
        </form>
        <div role="alert" runat="server">
            <asp:Label CssClass="alert alert-danger" ID="messageError" runat="server" Visible="false" />
        </div>
        <div role="alert" runat="server">
            <asp:Label CssClass="alert alert-success" ID="messageSuccess" runat="server" Visible="false" />
        </div>
    </div>

</body>
</html>
