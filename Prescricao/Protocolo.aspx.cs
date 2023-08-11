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

            ddlProtocolo.DataSource = ProtocoloDAO.listaProtocolo();
            ddlProtocolo.DataTextField = "desc_protocolo";
            ddlProtocolo.DataValueField = "cod_protocolo";
            ddlProtocolo.DataBind();

            select1.DataSource = Listagem_MedicamentoDAO.listaMedicamentos();
            select1.DataTextField = "droga";
            select1.DataValueField = "cod_medicamento";
            select1.DataBind();
        }
    }

    protected void btnGravar_Click(object sender, EventArgs e)
    {
       
       Protocolo protocolo = new Protocolo();
        List<Lista_Medicamento> medicamentos = new List<Lista_Medicamento>();







        protocolo.desc_protocolo = ddlProtocolo.SelectedItem.Text;
        protocolo.cod_protocolo = int.Parse(ddlProtocolo.SelectedValue);
            
      
        for (int i = 0; i < select1.Items.Count; i++)
        {
            if (select1.Items[i].Selected)
            {
                Lista_Medicamento medicamento = new Lista_Medicamento();
                medicamento.droga = select1.Items[i].Text;
                medicamento.cod_medicamento = int.Parse(select1.Items[i].Value);
                medicamentos.Add(medicamento);
            }
        }
        ProtocoloDAO.InativaMedicamentosPorProtocolo(protocolo.cod_protocolo);
        ProtocoloDAO.GravaMedicamentosPorProtocolo(medicamentos, protocolo.cod_protocolo);
        
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
        select1.DataSource = Listagem_MedicamentoDAO.listaMedicamentos();
        select1.DataTextField = "droga";
        select1.DataValueField = "cod_medicamento";
        select1.DataBind();
        if (!String.IsNullOrEmpty(ddlProtocolo.SelectedValue))
        {
            List <Lista_Medicamento> medicamentos_escolhidos = Listagem_MedicamentoDAO.CarregarDropDownListMedicamento(int.Parse(ddlProtocolo.SelectedValue));
           
    

            foreach (Lista_Medicamento medicamento in medicamentos_escolhidos)
            {

                select1.Items[medicamento.cod_medicamento - 1].Selected = true;

            }


        }
    }
}