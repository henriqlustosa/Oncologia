using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Administrativo_checkoutbe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            
            int be = Convert.ToInt32(Request.QueryString["be"]);
            lbBE.Text = be.ToString();
            BindFicha(be);
        }
    }

    private void BindFicha(int _nr_be)
    {
        Ficha ficha = new Ficha();

        ficha = FichaDAO.GetDadosBE(_nr_be);

        txbSetor.Text = ficha.setor;
        txbTipoPaciente.Text = ficha.tipo_paciente;
        txbDtFicha.Text = ficha.dt_rh_be.ToString();
        txbProntuario.Text = ficha.prontuario.ToString();
        txbNomePaciente.Text = ficha.nome_paciente;
        txbNascimento.Text = ficha.dt_nascimento.ToShortDateString();
        txbIdade.Text = ficha.idade;
        txbQueixa.Text = ficha.queixa;
    }
}