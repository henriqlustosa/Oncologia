using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Prescricao_EditarCadastroProtocolo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            int _id = Convert.ToInt32(Request.QueryString["idProtocolo"]);
            Protocolos protocolo = ProtocolosDAO.BuscarProtocoloPorId(_id);

            txbId.Text = _id.ToString();

            ddlProtocolo.DataSource = DescricaoProtocoloDAO.listaProtocolo();
            ddlProtocolo.DataTextField = "descricao";
            ddlProtocolo.DataValueField = "cod_protocolo";
            ddlProtocolo.DataBind();
            ddlPreQuimio.SelectedValue = protocolo.cod_DescricaoProtocolo.ToString();


            ddlMedicacao.DataSource = MedicacaoDAO.listaMedicamentos();
            ddlMedicacao.DataTextField = "descricao";
            ddlMedicacao.DataValueField = "cod_medicacao";
            ddlMedicacao.DataBind();
            ddlPreQuimio.SelectedValue = protocolo.cod_Medicacao.ToString();

            ddlViaDeAdministracao.DataSource = ViaDeAdministracaoDAO.listaViaDeAdministracao();
            ddlViaDeAdministracao.DataTextField = "descricao";
            ddlViaDeAdministracao.DataValueField = "cod_via_de_administracao";
            ddlViaDeAdministracao.DataBind();
            ddlPreQuimio.SelectedValue = protocolo.cod_ViaDeAdministracao.ToString();

            ddlPreQuimio.DataSource = PreQuimioDAO.listaPreQuimio();
            ddlPreQuimio.DataTextField = "descricao";
            ddlPreQuimio.DataValueField = "cod_pre_quimio";
            ddlPreQuimio.DataBind();
            ddlPreQuimio.SelectedValue = protocolo.cod_PreQuimio.ToString();

           
            txbDose.Text = protocolo.dose.ToString();
            txbDiluicao.Text = protocolo.diluicao.ToString();
            txbTempoDeInfusao.Text = protocolo.tempoDeInfusao.ToString();

            if (protocolo.unidadeDose == "mg")
            {
                ddlUnidadeDose.SelectedIndex = 0;
            }
            else
            {
                ddlUnidadeDose.SelectedIndex = 1;
            }
            if (protocolo.unidadeTempoDeInfusao == "min")
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
        
        Protocolos  protocolo = new Protocolos();
        protocolo.Id = Convert.ToInt32(txbId.Text);
        protocolo.cod_DescricaoProtocolo = Convert.ToInt32(ddlProtocolo.SelectedValue);
        protocolo.cod_Medicacao = Convert.ToInt32(ddlMedicacao.SelectedValue);
        protocolo.cod_PreQuimio = Convert.ToInt32(ddlPreQuimio.SelectedValue);
        protocolo.cod_PreQuimio = Convert.ToInt32(ddlPreQuimio.SelectedValue);
        protocolo.cod_ViaDeAdministracao = Convert.ToInt32(ddlViaDeAdministracao.SelectedValue);
        protocolo.nome_Usuario = User.Identity.Name.ToUpper(); ;
        protocolo.dose = Convert.ToInt32(txbDose.Text);
        protocolo.unidadeDose = ddlUnidadeDose.SelectedItem.ToString();
        protocolo.diluicao = txbDiluicao.Text;
        protocolo.tempoDeInfusao =txbTempoDeInfusao.Text;
        protocolo.unidadeTempoDeInfusao = ddlUnidadeTempoDeInfusao.SelectedItem.ToString();
        protocolo.dataCadastro = DateTime.Now;
        protocolo.status = "A";


        string mensagem = ProtocolosDAO.AtualizarProtocolo(protocolo);

        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);

        ClearInputs(Page.Controls);// limpa os textbox
        Response.Redirect("~/Prescricao/CadastroProtocolo.aspx");
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