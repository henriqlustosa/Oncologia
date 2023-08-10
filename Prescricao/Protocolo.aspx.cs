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

        select1.DataSource = Listagem_MedicamentoDAO.listaMedicamentos();
        select1.DataTextField = "droga";
        select1.DataValueField = "cod_medicamento";
        select1.DataBind();

    }
}