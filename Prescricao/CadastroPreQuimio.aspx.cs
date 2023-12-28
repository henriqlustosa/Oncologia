    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Prescricao_CadastroPreQuimio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //List<PreQuimio> prequimios = new List<PreQuimio>();
        //prequimios = PreQuimioDAO.listaPreQuimio();

        if (!IsPostBack)
        {
            
            ddlPreQuimio.DataSource = PreQuimioDAO.listaPreQuimio();
            ddlPreQuimio.DataTextField = "descricao";
            ddlPreQuimio.DataValueField = "cod_pre_quimio";
            ddlPreQuimio.DataBind();
            ddlPreQuimio.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlPreQuimio.SelectedIndex = 0;
           

            ddlMedicacao.DataSource = MedicacaoPreQuimioDAO.listaMedicacaoPreQuimio();
            ddlMedicacao.DataTextField = "descricao";
            ddlMedicacao.DataValueField = "cod_medicacao_prequimio";
            ddlMedicacao.DataBind();
            ddlMedicacao.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlMedicacao.SelectedIndex = 0;
         

            ddlViaDeAdministracao.DataSource = ViaDeAdministracaoDAO.listaViaDeAdministracao();
            ddlViaDeAdministracao.DataTextField = "descricao";
            ddlViaDeAdministracao.DataValueField = "cod_via_de_administracao";
            ddlViaDeAdministracao.DataBind();
            ddlViaDeAdministracao.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlViaDeAdministracao.SelectedIndex = 0;
           

            ddlQuimio.DataSource = QuimioDAO.listaQuimio();
            ddlQuimio.DataTextField = "descricao";
            ddlQuimio.DataValueField = "cod_quimio";
            ddlQuimio.DataBind();
            ddlQuimio.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlQuimio.SelectedIndex = 0;
            ;
        }



    }
    protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;

        if (e.CommandName.Equals("editRecord"))
        {
            index = Convert.ToInt32(e.CommandArgument);

            int idPreQuimio = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta
            GridViewRow row = GridView1.Rows[index];
            //string _status = row.Cells[7].Text;

            Response.Redirect("~/Prescricao/EditarCadastroPreQuimio.aspx?idPreQuimio=" + idPreQuimio + "");
        }
        if (e.CommandName.Equals("deleteRecord"))
        {
            index = Convert.ToInt32(e.CommandArgument);

            int _id_pedido = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta
            GridViewRow row = GridView1.Rows[index];

            PreQuimioDAO.deletarPreQuimio(_id_pedido);
            Response.Redirect("~/Prescricao/CadastroPreQuimio.aspx");

            //string _status = row.Cells[7].Text;


        }
        
    }

    protected void btnGravar_Click(object sender, EventArgs e)
    {

        MedicacaoPreQuimioDetalhe preQuimioDetalhe = new MedicacaoPreQuimioDetalhe();
        preQuimioDetalhe.cod_Medicacao = Convert.ToInt32(ddlMedicacao.SelectedValue);
        preQuimioDetalhe.cod_PreQuimio = Convert.ToInt32(ddlPreQuimio.SelectedValue);
        preQuimioDetalhe.cod_Quimio = Convert.ToInt32(ddlQuimio.SelectedValue);
        preQuimioDetalhe.cod_ViaDeAdministracao = Convert.ToInt32(ddlViaDeAdministracao.SelectedValue);
        preQuimioDetalhe.nome_Usuario = User.Identity.Name.ToUpper();
        if (string.IsNullOrEmpty(txbQuantidade.Text))
        {
            txbQuantidade.Text = "0";
        }
        preQuimioDetalhe.quantidade = Convert.ToInt32(txbQuantidade.Text);
        preQuimioDetalhe.unidadeQuantidade = ddlUnidadeQuantidade.SelectedItem.ToString();
        preQuimioDetalhe.diluicao = txbDiluicao.Text;
    

        if (string.IsNullOrEmpty(txbTempoDeInfusao.Text))
        {
            txbTempoDeInfusao.Text = "0";
        }
        preQuimioDetalhe.tempoDeInfusao = Convert.ToInt32(txbTempoDeInfusao.Text) ;
        preQuimioDetalhe.unidadeTempoDeInfusao = ddlUnidadeTempoDeInfusao.SelectedItem.ToString();
        preQuimioDetalhe.dataCadastro = DateTime.Now;
        preQuimioDetalhe.status = "A";
     

        string mensagem = MedicacaoPreQuimioDetalhelDAO.GravarPreQuimio(preQuimioDetalhe);

        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);

        ClearInputs(Page.Controls);// limpa os textbox
    }

    void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            ClearInputs(ctrl.Controls);
        }
    }

    protected void GridView1_PreRender(object sender, EventArgs e)
    {

        // colocar no grid OnPreRender="GridView1_PreRender"

        // You only need the following 2 lines of code if you are not 
        // using an ObjectDataSource of SqlDataSource
        GridView1.DataSource = RelatorioPreQuimioDAO.listaTodosPreQuimio();
        GridView1.DataBind();

        if (GridView1.Rows.Count > 0)
        {
            //This replaces <td> with <th> and adds the scope attribute
            GridView1.UseAccessibleHeader = true;

            //This will add the <thead> and <tbody> elements
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //This adds the <tfoot> element. 
            //Remove if you don't have a footer row
            GridView1.FooterRow.TableSection = TableRowSection.TableFooter;

        }
    }
}