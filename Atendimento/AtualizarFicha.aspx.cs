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

public partial class Atendimento_AtualizarFicha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        int num_be = Convert.ToInt32(txbBE.Text);
        BindFicha(num_be);
    }

    private void BindFicha(int _nr_be)
    {
        Ficha ficha = new Ficha();

        ficha = FichaDAO.GetDadosBE(_nr_be);
        lbBE.Text = _nr_be.ToString();
        txbSetor.Text = ficha.setor;
        //txbTipoPaciente.Text = ficha.tipo_paciente;
        if (ficha.tipo_paciente == "MUNÍCIPE")
        {
            ddlTipoPaciente.SelectedIndex = 0;
        }
        else if (ficha.tipo_paciente == "FUNCIONÁRIO")
        {
            ddlTipoPaciente.SelectedIndex = 1;
        }

        txbDtFicha.Text = ficha.dt_rh_be.ToString();
        txbProntuario.Text = ficha.prontuario.ToString();
        txbRF.Text = ficha.rf;
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
        txbTelefone1.Text = ficha.telefone1;
        txbTelefone2.Text = ficha.telefone2;
        txbEmail.Text = ficha.email;

        if (ficha.procedencia == "ESPONTÂNEA")
        {
            ddlTipoPaciente.SelectedIndex = 0;
        }
        if (ficha.procedencia == "BOMBEIRO")
        {
            ddlTipoPaciente.SelectedIndex = 1;
        }
        if (ficha.procedencia == "POLÍCIA MILITAR")
        {
            ddlTipoPaciente.SelectedIndex = 2;
        }
        if (ficha.procedencia == "GCM")
        {
            ddlTipoPaciente.SelectedIndex = 3;
        }
        if (ficha.procedencia == "METRÔ")
        {
            ddlTipoPaciente.SelectedIndex = 4;
        }
        if (ficha.procedencia == "AMA - SÉ")
        {
            ddlTipoPaciente.SelectedIndex = 5;
        }
        if (ficha.procedencia == "SAMU")
        {
            ddlTipoPaciente.SelectedIndex = 6;
        }
        if (ficha.procedencia == "AMBULÂNCIA PARTICULAR")
        {
            ddlTipoPaciente.SelectedIndex = 5;
        }

        if (ficha.sexo == "Masculino")
        {
            ddlSexo.SelectedIndex = 0;
        }
        if (ficha.sexo == "Feminino")
        {
            ddlSexo.SelectedIndex = 1;
        }
        if (ficha.sexo == "Não informado")
        {
            ddlSexo.SelectedIndex = 2;
        }

        if (ficha.raca == "Branca")
        {
            ddlRaca.SelectedIndex = 0;
        }
        if (ficha.raca == "Preta")
        {
            ddlRaca.SelectedIndex = 1;
        }
        if (ficha.raca == "Parda")
        {
            ddlRaca.SelectedIndex = 2;
        }
        if (ficha.raca == "Amarela")
        {
            ddlRaca.SelectedIndex = 3;
        }
        if (ficha.raca == "Indígena")
        {
            ddlRaca.SelectedIndex = 4;
        }
    }

    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
        string mensagem = "";
        Ficha f = new Ficha();
        f.cod_ficha = Convert.ToInt32(lbBE.Text);
        f.documento = txbDocumento.Text;
        f.rf = txbRF.Text;
        f.cns = txbCNS.Text;
        f.tipo_paciente = ddlTipoPaciente.SelectedValue;
        f.nome_paciente = txbNomePaciente.Text;
        if (txbNascimento.Text == "")
        {
            DateTime seData = new DateTime(1800, 1, 1);
            f.dt_nascimento = seData;
        }
        else
        {
            f.dt_nascimento = Convert.ToDateTime(txbNascimento.Text);
        } 
        f.idade = txbIdade.Text;
        f.sexo = ddlSexo.SelectedValue;
        f.raca = ddlRaca.SelectedValue;
        f.endereco_rua = txbEndereco.Text;
        f.numero_casa = txbNumero.Text;
        f.complemento = txbComplemento.Text;
        f.bairro = txbBairro.Text;
        f.municipio = txbMunicipio.Text;
        f.uf = txbUF.Text;
        f.cep = txbCEP.Text;
        f.nome_pai_mae = txbPais.Text;
        f.responsavel = txbResponsavel.Text;
        f.telefone = txbTelefone.Text;
        f.telefone1 = txbTelefone1.Text;
        f.telefone2 = txbTelefone2.Text;
        f.email = txbEmail.Text;
        f.procedencia = ddlProcedencia.SelectedValue;

        mensagem = FichaDAO.AtualizarFicha(f.cod_ficha, f.documento, f.cns, f.tipo_paciente, f.nome_paciente,
            f.dt_nascimento, f.idade, f.sexo, f.raca, f.endereco_rua, f.numero_casa, f.complemento, f.bairro, f.municipio, f.uf, f.cep,
            f.nome_pai_mae, f.responsavel, f.telefone, f.telefone1, f.telefone2, f.email, f.procedencia, f.rf);
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);
    }
}
