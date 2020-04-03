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

public partial class Atendimento_AberturaFicha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnGravar_Click(object sender, EventArgs e)
    {
        Ficha be = new Ficha();
        be.dt_rh_be = Convert.ToDateTime(lbData.Text);
        be.prontuario = Convert.ToInt32(txbProntuario.Text);
        be.documento = txbDocumento.Text;
        be.tipo_paciente = rbTipoPaciente.SelectedValue;
        be.nome_paciente = txbNomePaciente.Text;
        be.dt_nascimento = Convert.ToDateTime(txbNascimento.Text);
        be.sexo = Convert.ToInt32(txbSexo.Text);
        be.raca = Convert.ToInt32(txbRaca.Text);
        be.endereco_rua = txbEndereco.Text;
        be.numero_casa = txbNumero.Text;
        be.complemento = txbComplemento.Text;
        be.bairro = txbBairro.Text;
        be.municipio = txbMunicipio.Text;
        be.uf = txbUF.Text;
        be.cep = txbCEP.Text;
        be.nome_pai_mae = txbPais.Text;
        be.responsavel = txbResponsavel.Text;
        be.telefone = txbTelefone.Text;
        be.procedencia = txbProcedencia.Text;
        be.queixa = txbQueixa.Text;

        be.setor = Convert.ToInt32(txbSetor.Text);


        string mensagem = FichaDAO.GravaFicha(be.dt_rh_be
                                                ,be.prontuario
                                                , be.documento
                                                , be.tipo_paciente
                                                , be.nome_paciente
                                                , be.dt_nascimento
                                                , be.sexo
                                                , be.raca
                                                , be.endereco_rua
                                                , be.numero_casa
                                                , be.complemento
                                                , be.bairro
                                                , be.municipio
                                                , be.uf
                                                , be.cep
                                                , be.nome_pai_mae
                                                , be.responsavel
                                                , be.telefone
                                                , be.procedencia
                                                , be.queixa
                                                ,be.setor
                                               );


        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(mensagem);
        ScriptManager.RegisterStartupScript(Page, this.Page.GetType(), "clientscript", sb.ToString(), true);

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
