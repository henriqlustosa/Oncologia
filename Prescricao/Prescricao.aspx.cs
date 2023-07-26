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

    }
    [WebMethod]

    public static List<Paciente> GetNomeDePacientes(string prefixo)
    {
        List<Paciente> pacientes = new List<Paciente>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["psConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = string.Format("SELECT  TOP 10 nome, prontuario FROM [Oncologia_Desenv].[dbo].[Paciente] where [nome] like '{0}%' group by nome, prontuario", prefixo);

                cmd.Connection = conn;
                conn.Open();
                Paciente c = null;

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        c = new Paciente();


                        c = PacienteDAO.GET(Convert.ToString(sdr["prontuario"]));

                        pacientes.Add(c);
                    }
                }
                conn.Close();
            }
        }
        return pacientes;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string script = "$('#modalAdicionarPaciente').modal('show');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalScript", script, true);
    }
    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "#modalAdicionarPaciente", "$('#modalDadosDoPaciente').modal('show');", true);
        
       

    }
}