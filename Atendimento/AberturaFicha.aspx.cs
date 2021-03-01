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
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using Microsoft.SqlServer.ReportingServices2005.Execution;
using System.Text;
using System.Drawing.Printing;
using System.Threading;
using System.Net;

public partial class Atendimento_AberturaFicha : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            lbUserImprimir.Text = System.Web.HttpContext.Current.User.Identity.Name;

            //try
            //{
            //    foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            //    {
            //        ddlImpressora.Items.Add(strPrinter);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string erro = ex.Message;
            //}
            
            ClearInputs(Page.Controls);// limpa os textbox
        }
    }
    public string nome_impressora { get; set; }
    public int vias { get; set; }
    
    protected void btnGravar_Click(object sender, EventArgs e)
    {
        nome_impressora = ddlImpressora.SelectedValue;
        vias = Convert.ToInt32(ddlVias.SelectedValue);

        string mensagem = "";
        int _pront = 0;
        if (txbProntuario.Text != "")
        {
            _pront = Convert.ToInt32(txbProntuario.Text);
        }

        string _inform_complement = "";
        for (int i = 0; i < chkFormaChegada.Items.Count; i++)
        {
            if (chkFormaChegada.Items[i].Selected == true)// getting selected value from CheckBox List  
            {
                _inform_complement += chkFormaChegada.Items[i].Text + ", "; // add selected Item text to the String .  
            }
        }
        if (_inform_complement != "")
        {
            _inform_complement = _inform_complement.Substring(0, _inform_complement.Length - 2); // Remove Last "," from the string .  
        }

        Ficha be = new Ficha();
        be.dt_rh_be = DateTime.Now;
        be.prontuario = _pront;
        be.rf = txbRF.Text;
        be.documento = txbDocumento.Text;
        be.cns = txbCNS.Text;
        be.tipo_paciente = rbTipoPaciente.SelectedValue;
        be.nome_paciente = txbNomePaciente.Text;

        if (txbNascimento.Text == "")
        {
            DateTime seData = new DateTime(1800, 1, 1);
            be.dt_nascimento = seData;
        }
        else
        {
            be.dt_nascimento = Convert.ToDateTime(txbNascimento.Text);
        }

        be.idade = txbIdade.Text;
        be.sexo = ddlSexo.SelectedValue;
        be.raca = ddlRaca.SelectedValue;
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
        be.telefone1 = txbTelefone1.Text;
        be.telefone2 = txbTelefone2.Text;
        be.email = txbEmail.Text;
        be.procedencia = ddlProcedencia.SelectedValue;
        be.informacao_complementar = _inform_complement;
        be.queixa = txbQueixa.Text;
        be.setor = ddlSetor.SelectedValue;
        be.usuario = System.Web.HttpContext.Current.User.Identity.Name;
        be.info_resgate = txbInfoResgate.Text;

        int _cod_ficha_be = FichaDAO.GravaFicha(be.dt_rh_be
                                                , be.prontuario
                                                , be.documento
                                                , be.cns
                                                , be.tipo_paciente
                                                , be.nome_paciente
                                                , be.dt_nascimento
                                                , be.idade
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
                                                , be.telefone1
                                                , be.telefone2
                                                , be.email
                                                , be.procedencia
                                                , be.informacao_complementar
                                                , be.queixa
                                                , be.setor
                                                , be.usuario
                                                , be.info_resgate
                                                , be.rf
                                               );

        mensagem = "Ficha: " + Convert.ToString(_cod_ficha_be);

        while (vias > 0)
        {
            ImpressaoFicha.imprimirFicha(_cod_ficha_be, nome_impressora);
            vias--;
        }

        // imprimir etiquetas
        int qtd_etiquetas = Convert.ToInt32(ddlQtdEtiquetas.SelectedValue);
        if (qtd_etiquetas > 0)
        {
            ImprimirEtiqueta(_cod_ficha_be, qtd_etiquetas);
        }

        Response.Redirect("~/Atendimento/AberturaFicha.aspx");
    }

    public void ImprimirEtiqueta(int cod_ficha, int qtdEtiquetas)
    {
        int _cod_ficha_be = Convert.ToInt32(cod_ficha);
        //Computador pc = new Computador();
        //string _hostname = "HSPMINS17";
        //pc = ComputadorDAO.getInfoComputador(_hostname);

        if (nome_impressora == "PS - Guichê" )
        {
            string nome_impressora_etiqueta = "TSC_GUICHE_PS"; // impressora termica
            ImpressaoFicha.imprimirEtiqueta(_cod_ficha_be, nome_impressora_etiqueta, qtdEtiquetas);
        }
        if (nome_impressora == "Centro Respiratório")
        {
            string nome_impressora_etiqueta = "TSC_GRIPARIO"; // impressora termica
            ImpressaoFicha.imprimirEtiqueta(_cod_ficha_be, nome_impressora_etiqueta, qtdEtiquetas);
        }
    }

    void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;

            ClearInputs(ctrl.Controls);
        }
        foreach (ListItem item in chkFormaChegada.Items)
        {
            item.Selected = false;
        }
    }

}