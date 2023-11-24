using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Prescricao_Prescricao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlProtocolo.DataSource = DescricaoProtocoloDAO.listaProtocolo();
            ddlProtocolo.DataTextField = "descricao";
            ddlProtocolo.DataValueField = "cod_protocolo";
            ddlProtocolo.DataBind();

            ddlFinalidade.DataSource = FinalidadeDoTratamentoDAO.ListaFinalidade();
            ddlFinalidade.DataTextField = "desc_finalidade";
            ddlFinalidade.DataValueField = "cod_finalidade";
            ddlFinalidade.DataBind();

            select1.DataSource = CID_10_DAO.listaCID_10();
            select1.DataTextField = "DESCRABREV";
            select1.DataValueField = "SUBCAT";
            select1.DataBind();

            cblViasDeAcesso.DataSource = ViasDeAcessoDAO.ListaViasDeAcesso();
            cblViasDeAcesso.DataTextField = "descr_vias_de_acesso"; 
            cblViasDeAcesso.DataValueField = "cod_vias_de_acesso";
            cblViasDeAcesso.DataBind();
        }
    }
    [WebMethod]

    public static List<Paciente> GetNomeDePacientes(string prefixo)
   {
        
        List<Paciente> pacientes = new List<Paciente>();
        pacientes = PacienteDAO.GETNOME( prefixo.ToUpper());

        return pacientes;
    }

    [WebMethod]

    public static Paciente GetNomeDePacientesPoRh(string prefixo)
    {

        Paciente pacientes = new Paciente();
        pacientes = PacienteDAO.GET(prefixo);

        return pacientes;
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "#modalAdicionarPaciente", "$('#modalDadosDoPaciente').modal('show');", true);

      
    }

    protected void btnGravar_Click(object sender, EventArgs e)
    {

        Paciente paciente = new Paciente();
       


        //string mensagem = ProtocolosDAO.GravarProtocolo(protocolo);

        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);

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
}