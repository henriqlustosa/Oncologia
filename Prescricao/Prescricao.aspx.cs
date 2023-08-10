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
        select1.DataSource = CID_10_DAO.listaCID_10();
        select1.DataTextField = "DESCRABREV";
        select1.DataValueField = "SUBCAT";
        select1.DataBind();

    }
    [WebMethod]

    public static List<Paciente> GetNomeDePacientes(string prefixo)
   {
        
        List<Paciente> pacientes = new List<Paciente>();
        pacientes = PacienteDAO.GETNOME( prefixo.ToUpper());

        return pacientes;
    }
   
    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "#modalAdicionarPaciente", "$('#modalDadosDoPaciente').modal('show');", true);

      
    }
}