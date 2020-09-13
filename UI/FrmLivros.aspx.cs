using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POO3B127.BLL;
using POO3B127.DTO;

namespace POO3B127.UI
{
    public partial class FrmLivros : System.Web.UI.Page
    {

        readonly tblAutorBLL autorBLL = new tblAutorBLL();
        readonly tblEditoraBLL editoraBLL = new tblEditoraBLL();

        readonly tblLivroBLL livroBLL = new tblLivroBLL();
        readonly tblLivroDTO livroDTO = new tblLivroDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                drpAutor.DataSource = autorBLL.listarAutores();
                drpAutor.DataTextField = "nome";
                drpAutor.DataValueField = "idAutor";
                drpAutor.DataBind();

                drpEditora.DataSource = editoraBLL.listarEditoras();
                drpEditora.DataTextField = "nome";
                drpEditora.DataValueField = "idEditora";
                drpEditora.DataBind();

                renderizarGrid();
            }
        }

        public void renderizarGrid()
        {
            GridLivro.DataSource = livroBLL.listarLivros();
            GridLivro.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                livroDTO.idAutor = int.Parse(drpAutor.SelectedValue.ToString());
                livroDTO.idEditora= int.Parse(drpEditora.SelectedValue.ToString());
                livroDTO.dataCadastro = Convert.ToDateTime(txtDataCadastro.Text);
                livroDTO.tituloLivro = txtTitulo.Text;
                livroDTO.numPaginas = int.Parse(txtNumPaginas.Text);
                livroDTO.valorLivro = double.Parse(txtValor.Text);

                livroBLL.criarLivro(livroDTO);

                messageError.Visible = false;

                renderizarGrid();
                messageSuccess.Visible = true;
                messageSuccess.Text = "Livro salvo!";
            }
            catch (Exception error)
            {
                messageSuccess.Text = string.Empty;
                messageSuccess.Visible = false;
                messageError.Visible = true;
                messageError.Text = error.Message;
            }
        }

        protected void GridLivro_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                livroDTO.idLivro = Convert.ToInt32(e.Values[0]);
                livroBLL.deletarLivro(livroDTO);

                messageSuccess.Visible = true;
                messageSuccess.Text = "Livro deletado!";

                renderizarGrid();
            }
            catch (Exception ex)
            {
                messageError.Visible = true;
                messageError.Text = ex.Message;
            }
        }

        protected void GridLivro_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridLivro.EditIndex = e.NewEditIndex;
            renderizarGrid();
        }

        protected void GridLivro_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                livroDTO.idLivro = int.Parse(e.NewValues[0].ToString());
                livroDTO.idAutor = int.Parse(e.NewValues[1].ToString());
                livroDTO.idEditora = int.Parse(e.NewValues[2].ToString());
                livroDTO.tituloLivro = e.NewValues[3].ToString();
                livroDTO.dataCadastro = Convert.ToDateTime(e.NewValues[4]);
                livroDTO.numPaginas = int.Parse(e.NewValues[5].ToString());
                livroDTO.valorLivro = double.Parse(e.NewValues[6].ToString());

                livroBLL.atualizarLivro(livroDTO);

                GridLivro.EditIndex = -1;
                renderizarGrid();
            }
            catch (Exception ex)
            {
                messageError.Visible = true;
                messageError.Text = ex.Message;
            }
        }

        protected void GridLivro_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridLivro.EditIndex = -1;
            renderizarGrid();
        }
    }
}
