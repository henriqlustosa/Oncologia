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
using System.Data.SqlClient;

public partial class Administrativo_checkoutbe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int be = Convert.ToInt32(Request.QueryString["be"]);
            lbBE.Text = be.ToString();
            BindFicha(be);
            listProfissionais();
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
        txbCNS.Text = ficha.cns;
        txbDocumento.Text = ficha.documento;
        txbEndereco.Text = ficha.endereco_rua;
        txbNumero.Text = ficha.numero_casa;
        txbComplemento.Text = ficha.complemento;
        txbBairro.Text = ficha.bairro;
        txbMunicipio.Text = ficha.municipio;
        txbUF.Text = ficha.uf;
        txbCEP.Text = ficha.cep;
        txbPais.Text = ficha.nome_pai_mae;
        txbResponsavel.Text = ficha.responsavel;
        txbTelefone.Text = ficha.telefone;
        txbProcedencia.Text = ficha.procedencia;
    }

    protected void listProfissionais()
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [cod_profissional], [nome_profissional] FROM [Profissional] ORDER BY [nome_profissional] asc";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    ddlProfissional.Items.Add(new ListItem(dr1.GetString(1), dr1.GetInt32(0).ToString()));
                }
                cnn.Close();
                //inserido na posições 0 do DDL, texto: "Selecione a empresa", e valor: "0".
                ddlProfissional.Items.Insert(0, new ListItem("PROFISSIONAL NÃO INFORMADO", "0"));
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
    }


    protected void btnGravar_Click(object sender, EventArgs e)
    {
        string mensagem = "";

        Baixa baixa = new Baixa();
        baixa.cod_ficha = Convert.ToInt32(lbBE.Text);
        baixa.cod_status = Convert.ToInt32(ddlStatusFicha.SelectedValue);
        baixa.cod_profissional = Convert.ToInt32(ddlProfissional.SelectedValue);
        baixa.data_baixa = DateTime.Now;
        baixa.obs = txbJustifica.Text;
        baixa.usuario_baixa = System.Web.HttpContext.Current.User.Identity.Name;

        mensagem = CheckoutDAO.GravaBaixa(baixa.cod_ficha, baixa.cod_status, baixa.cod_profissional, baixa.data_baixa, baixa.obs, baixa.usuario_baixa);
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);

        ClearInputs(Page.Controls);// limpa os textbox

        Response.Redirect("~/Administrativo/checkout.aspx");
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