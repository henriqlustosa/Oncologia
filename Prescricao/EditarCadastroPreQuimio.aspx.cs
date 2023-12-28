    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Prescricao_EditarCadastroPreQuimio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //List<PreQuimio> prequimios = new List<PreQuimio>();
        //prequimios = PreQuimioDAO.listaPreQuimio();

        if (!IsPostBack)
        {
            int _id = Convert.ToInt32(Request.QueryString["idPreQuimio"]);
            MedicacaoPreQuimioDetalhe preQuimio = MedicacaoPreQuimioDetalhelDAO.BuscarPreQuimioPorId(_id);
            txbId.Text = _id.ToString();
            ddlPreQuimio.DataSource = PreQuimioDAO.listaPreQuimio();
            ddlPreQuimio.DataTextField = "descricao";
            ddlPreQuimio.DataValueField = "cod_pre_quimio";
            ddlPreQuimio.DataBind();
            //ddlPreQuimio.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlPreQuimio.SelectedValue = preQuimio.cod_PreQuimio.ToString();
           

            ddlMedicacao.DataSource = MedicacaoPreQuimioDAO.listaMedicacaoPreQuimio();
            ddlMedicacao.DataTextField = "descricao";
            ddlMedicacao.DataValueField = "cod_medicacao_prequimio";
            ddlMedicacao.DataBind();
            //ddlMedicacao.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlMedicacao.SelectedValue = preQuimio.cod_Medicacao.ToString();
         

            ddlViaDeAdministracao.DataSource = ViaDeAdministracaoDAO.listaViaDeAdministracao();
            ddlViaDeAdministracao.DataTextField = "descricao";
            ddlViaDeAdministracao.DataValueField = "cod_via_de_administracao";
            ddlViaDeAdministracao.DataBind();
            //ddlViaDeAdministracao.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlViaDeAdministracao.SelectedValue = preQuimio.cod_ViaDeAdministracao.ToString();
           

            ddlQuimio.DataSource = QuimioDAO.listaQuimio();
            ddlQuimio.DataTextField = "descricao";
            ddlQuimio.DataValueField = "cod_quimio";
            ddlQuimio.DataBind();
            //ddlQuimio.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlQuimio.SelectedValue = preQuimio.cod_Quimio.ToString();


            if (String.IsNullOrEmpty(preQuimio.quantidade.ToString()))
                txbQuantidade.Text = "";
            else
                txbQuantidade.Text = preQuimio.quantidade.ToString();

            if (String.IsNullOrEmpty(preQuimio.diluicao))
                txbDiluicao.Text = "";
            else
                txbDiluicao.Text = preQuimio.diluicao.ToString();

            if (String.IsNullOrEmpty(preQuimio.tempoDeInfusao.ToString()))
                txbTempoDeInfusao.Text = "";
            else
                txbTempoDeInfusao.Text = preQuimio.tempoDeInfusao.ToString();


          
            if (preQuimio.unidadeQuantidade == "mg") {
                ddlUnidadeQuantidade.SelectedIndex = 0;
            } else
            {
                ddlUnidadeQuantidade.SelectedIndex = 1;
            }
            if (preQuimio.unidadeTempoDeInfusao == "min")
            {
                ddlUnidadeTempoDeInfusao.SelectedIndex = 0;
            }
            else
            {
                ddlUnidadeTempoDeInfusao.SelectedIndex = 1;
            }
        }



    }
   

    protected void btnGravar_Click(object sender, EventArgs e)
    {
        
        MedicacaoPreQuimioDetalhe preQuimioDetalhe = new MedicacaoPreQuimioDetalhe();

        preQuimioDetalhe.Id = Convert.ToInt32(txbId.Text);
        preQuimioDetalhe.cod_Medicacao = Convert.ToInt32(ddlMedicacao.SelectedValue);
        preQuimioDetalhe.cod_PreQuimio = Convert.ToInt32(ddlPreQuimio.SelectedValue);
        preQuimioDetalhe.cod_Quimio = Convert.ToInt32(ddlQuimio.SelectedValue);
        preQuimioDetalhe.cod_ViaDeAdministracao = Convert.ToInt32(ddlViaDeAdministracao.SelectedValue);
        preQuimioDetalhe.nome_Usuario = User.Identity.Name.ToUpper(); ;
        preQuimioDetalhe.quantidade = Convert.ToDecimal(txbQuantidade.Text);
        preQuimioDetalhe.unidadeQuantidade = ddlUnidadeQuantidade.SelectedItem.ToString();
        preQuimioDetalhe.diluicao = txbDiluicao.Text;
        preQuimioDetalhe.tempoDeInfusao = Convert.ToInt32(txbTempoDeInfusao.Text);
        preQuimioDetalhe.unidadeTempoDeInfusao = ddlUnidadeTempoDeInfusao.SelectedItem.ToString();
        preQuimioDetalhe.dataCadastro = DateTime.Now;
        preQuimioDetalhe.status = "A";
     

        string mensagem = MedicacaoPreQuimioDetalhelDAO.AtualizarPreQuimio(preQuimioDetalhe);

        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);

        ClearInputs(Page.Controls);// limpa os textbox

        Response.Redirect("~/Prescricao/CadastroPreQuimio.aspx");
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {

        



        ClearInputs(Page.Controls);// limpa os textbox

        Response.Redirect("~/Prescricao/CadastroPreQuimio.aspx");
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

   
}