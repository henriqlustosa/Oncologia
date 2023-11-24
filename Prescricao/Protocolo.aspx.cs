using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Prescricao_Protocolo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ddlProtocolo.DataSource = DescricaoProtocoloDAO.listaProtocolo();
            ddlProtocolo.DataTextField = "descricao";
            ddlProtocolo.DataValueField = "cod_protocolo";
            ddlProtocolo.DataBind();

           

            ddlMedicacao.DataSource = MedicacaoDAO.listaMedicamentos();
            ddlMedicacao.DataTextField = "descricao";
            ddlMedicacao.DataValueField = "cod_medicacao";
            ddlMedicacao.DataBind();

            ddlViaDeAdministracao.DataSource = ViaDeAdministracaoDAO.listaViaDeAdministracao();
            ddlViaDeAdministracao.DataTextField = "descricao";
            ddlViaDeAdministracao.DataValueField = "cod_via_de_administracao";
            ddlViaDeAdministracao.DataBind();

            ddlPreQuimio.DataSource = PreQuimioDAO.listaPreQuimio();
            ddlPreQuimio.DataTextField = "descricao";
            ddlPreQuimio.DataValueField = "cod_pre_quimio";
            ddlPreQuimio.DataBind();

           
        }
    }

    protected void btnGravar_Click(object sender, EventArgs e)
    {
        
        Protocolos  protocolo = new Protocolos();
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
        protocolo.status = 'A';


        string mensagem = ProtocolosDAO.GravarProtocolo(protocolo);

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
        GridView1.DataSource = RelatorioProtocoloDAO.listaTodosProtocolos();
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

    protected void ddlProtocolo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //select1.DataSource = MedicacaoDAO.listaMedicamentos();
        //select1.DataTextField = "droga";
        //select1.DataValueField = "cod_medicamento";
        //select1.DataBind();
        //if (!String.IsNullOrEmpty(ddlProtocolo.SelectedValue))
        //{
        //    List<Medicamento_Amostra> medicamentos_escolhidos = MedicacaoDAO.CarregarDropDownListMedicamento(int.Parse(ddlProtocolo.SelectedValue));



        //    foreach (Medicamento_Amostra medicamento in medicamentos_escolhidos)
        //    {

        //        select1.Items[medicamento.cod_medicamento - 1].Selected = true;

        //    }


        //}
    }
}