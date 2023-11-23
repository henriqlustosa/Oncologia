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

           

            ddlLista_Medicamento.DataSource = MedicacaoDAO.listaMedicamentos();
            ddlLista_Medicamento.DataTextField = "descricao";
            ddlLista_Medicamento.DataValueField = "cod_medicacao";
            ddlLista_Medicamento.DataBind();

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
       
       Protocolo protocolo = new Protocolo();
        //List<Medicamento_Amostra> medicamentos = new List<Medicamento_Amostra>();







        protocolo.desc_protocolo = ddlProtocolo.SelectedItem.Text;
        protocolo.cod_protocolo = int.Parse(ddlProtocolo.SelectedValue);
            
      
        //for (int i = 0; i < select1.Items.Count; i++)
        //{
        //    if (select1.Items[i].Selected)
        //    {
        //        Medicamento_Amostra medicamento = new Medicamento_Amostra();
        //        medicamento.droga = select1.Items[i].Text;
        //        medicamento.cod_medicamento = int.Parse(select1.Items[i].Value);
        //        medicamentos.Add(medicamento);
        //    }
        //}
        DescricaoProtocoloDAO.InativaMedicamentosPorProtocolo(protocolo.cod_protocolo);
        //DescricaoProtocoloDAO.GravaMedicamentosPorProtocolo(medicamentos, protocolo.cod_protocolo);
        
        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("$(document).ready(function(){");
        sb.Append("$('#myModal').modal();");
        sb.Append("});");
        ScriptManager.RegisterStartupScript(Page, this.Page.GetType(), "clientscript", sb.ToString(), true);

        //Response.Redirect("~/encaminhamento/cadencaminhamento.aspx");

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