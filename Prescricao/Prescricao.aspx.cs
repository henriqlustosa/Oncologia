using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Serilog;
using System.Reflection;
public partial class Prescricao_Prescricao : System.Web.UI.Page
{
    private int cod_Prescricao
    {
        get
        {
            if (ViewState["cod_Prescicao"] == null)
            {
                ViewState["cod_Prescicao"] = 0;
            }
            return Convert.ToInt32(ViewState["cod_Prescicao"].ToString());
        }
        set
        {
            ViewState["cod_Prescicao"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Log.Information("Loaded Page: {PageName}", this.GetType().Name);
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
            for (int i = 0; i < cblViasDeAcesso.Items.Count; i++)
            {
                cblViasDeAcesso.Items[i].Attributes.Add("onclick", "MutExChkList(this)");
            }
            btnAtualizar.Visible = false;
            btnVisualizarMedicamento.Visible = false;
            btnImprimir.Visible = false;
        }
    }
    [WebMethod]

    public static List<Paciente> GetNomeDePacientes(string prefixo)
    {

        List<Paciente> pacientes = new List<Paciente>();
        pacientes = PacienteDAO.GETNOME(prefixo.ToUpper());

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
        string usuario = User.Identity.Name.ToUpper();
        // Variável para mostrar mensagem de erro
        string mensagem = "";

  

      

        // Variável que marca a data e hora da criação da prescrição
        DateTime dataCadastro = DateTime.Now;

        // Variável para salvar o prontuário que o usuário digitou no formulário
        int cod_Paciente = int.Parse(txbProntuario.Text);


        string message = PacienteOncologiaDAO.HandlePacienteOncologia(txbProntuario.Text, txbNomePaciente.Text, txbPais.Text,
                                         txbTelefone.Text, txbDdd.Text, ddlSexo.SelectedItem.ToString(),
                                         txbNascimento.Text, dataCadastro);
        Log.Information(message);



        CalculoSuperficieCorporea calculo = CalculoSuperficieCorporeaDAO.HandleCalculoSuperficieCorporea(txbAltura.Value.ToString(), txbPeso.Value.ToString(), txbBSA.Value.ToString(), dataCadastro);

        Prescricao prescricao = PrescricaoDAO.HandlePrescricaoGravacao(cod_Paciente, int.Parse(ddlFinalidade.SelectedValue.ToString()), int.Parse(cblViasDeAcesso.SelectedValue.ToString()), int.Parse(ddlProtocolo.SelectedValue.ToString()), calculo.cod_Calculo, int.Parse(txbCiclos.Text.ToString()), int.Parse(txbIntervalos.Text.ToString()), DateTime.Parse(txbDtInicio.Text.ToString()), Convert.ToDecimal(txbCreatinina.Text), txbObservacao.Text.ToString(), dataCadastro, usuario);

        List<CID_10> listaDeCids = HandleCID();

        CID_10_DAO.GravaCidsPorPrescricao(listaDeCids, prescricao.cod_Prescricao, dataCadastro);

        AgendaDAO.GravarAgenda(prescricao.data_inicio, prescricao.cod_Prescricao, prescricao.ciclos_provaveis, prescricao.intervalo_dias, prescricao.data_cadastro);



        CalculoDosagemPrescricao calculoDosagem = new CalculoDosagemPrescricao();
        CalculoDosagemPrescricaoPreQuimio calculoDosagemPrescricao = new CalculoDosagemPrescricaoPreQuimio();




        List<Protocolos> protocolos = ProtocolosDAO.BuscarProtocolosPorCodProtocolo(int.Parse(ddlProtocolo.SelectedValue.ToString()));

        List<CalculoDosagemPrescricao> calculoDosagens = calculoDosagem.calcular(calculo, protocolos, dataCadastro, prescricao, PacienteOncologiaDAO.ObterPacientePorRh(cod_Paciente), usuario);
        List<MedicacaoPreQuimioDetalhe> prequimios = MedicacaoPreQuimioDetalhelDAO.BuscarPrequimiosPorCodPreQuimio(prescricao.cod_Prequimio);

        List<CalculoDosagemPrescricaoPreQuimio> calculoDosagemPrescricaoPreQuimios = calculoDosagemPrescricao.calcular(prequimios, dataCadastro, prescricao, PacienteOncologiaDAO.ObterPacientePorRh(cod_Paciente), usuario);
        CalculoDosagemPrescricaoDAO.GravarCalculoDosagemPrescricao(calculoDosagens);
        CalculoDosagemPrescricaoPreQuimioDAO.GravarCalculoDosagemPrescricaoPreQuimio(calculoDosagemPrescricaoPreQuimios);





        //while (vias > 0)
        //{

        //    ImpressaoPrescricao.imprimirFicha(prescricao.cod_Prescricao, nome_impressora);
        //    vias--;
        //}

        //cod_Prescricao = prescricao.cod_Prescricao;
        //MostrarTodosMedicamentos(cod_Prescricao);

       
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalMedicamento');", true);
        cod_Prescricao = prescricao.cod_Prescricao;

        btnGravar.Visible = false;
        btnAtualizar.Visible = true;
        btnVisualizarMedicamento.Visible = true;
        btnImprimir.Visible = true;


        //ClearInputs(Page.Controls);// limpa os textbox
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Your Comment", "ClearInputs();", true);
    }

    private void MostrarTodosMedicamentos(int cod_Prescricao)
    {
        GridViewPreQuimio.DataSource = RelatorioPreQumioDosagemDAO.MostrarMedicamentosParaEdicao(cod_Prescricao);
        GridViewPreQuimio.DataBind();

        GridViewProtocolo.DataSource = RelatorioProtocoloDosagemDAO.MostrarMedicamentosParaEdicao(cod_Prescricao);

        GridViewProtocolo.DataBind();
    }

    public List<CID_10> HandleCID()
    {



        return select1.Items.Cast<ListItem>()
                            .Where(i => i.Selected)
                            .Select(i => new CID_10 { SUBCAT = i.Value })
                            .ToList();

    }





    void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is System.Web.UI.WebControls.TextBox)
                ((System.Web.UI.WebControls.TextBox)ctrl).Text = string.Empty;

            if (ctrl is CheckBoxList)
                ((CheckBoxList)ctrl).ClearSelection();
            if (ctrl is DropDownList)
                ((DropDownList)ctrl).SelectedIndex = 0;
            ClearInputs(ctrl.Controls);

        }



    }
    protected void gridViewPreQuimio_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int index = Convert.ToInt32(e.CommandArgument);
        int idCalculoDosagemPreQuimio = Convert.ToInt32(GridViewPreQuimio.DataKeys[index].Value.ToString()); //id da consulta
        DateTime dataCadastro = DateTime.Now;

        if (e.CommandName.Equals("editRecord"))
        {

            lblNome.Text = "PreQuimio";
            GridViewRow row = GridViewPreQuimio.Rows[index];

            txbCodigo.Text = idCalculoDosagemPreQuimio.ToString();
            lbMedicacao.InnerText = HttpUtility.HtmlDecode(row.Cells[0].Text);
            CalculoDosagemPrescricaoPreQuimio dados = CalculoDosagemPrescricaoPreQuimioDAO.ApresentarDadosCalculoDosagemPreQuimio(idCalculoDosagemPreQuimio);
            txbDoseProtocolo.Text = dados.dose.ToString();
            // Initialize the dropdown list with a specific value
            string initialPercentage = dados.porcentagemDiminuirDose.ToString(); // Example value 
            ListItem selectedItem = ddlPercentagem.Items.FindByValue(initialPercentage);
            ddlPercentagem.ClearSelection();
            selectedItem.Selected = true;
            txbDoseAlterada.Text = dados.dose_alterada.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalDosagem');", true);
        }
        else if (e.CommandName.Equals("deleteRecord"))
        {


            CalculoDosagemPrescricaoPreQuimioDAO.DeletarCalculoDosagemPrescricaoPreQuimio(idCalculoDosagemPreQuimio, dataCadastro);
          
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalMedicamento');", true);

            MostrarTodosMedicamentos(cod_Prescricao);

        }






    }
    protected void btnCancelarDosagem_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalMedicamento');", true);
    }
    protected void btnGravarImpressora_Click(object sender, EventArgs e)
    {
    }

    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        // Variável para armazenar o nome da impressora selecionada
        string nome_impressora = ddlImpressora.SelectedValue;
        // Variável para armazenar a quantidade cópias de cada prescrição 
        int vias = Convert.ToInt32(ddlVias.SelectedValue);
        while (vias > 0)
        {

            ImpressaoPrescricao.imprimirFicha(cod_Prescricao, nome_impressora);
            vias--;
        }
    }

    protected void btnVisualizarMedicamento_Click(object sender, EventArgs e)
    {
        MostrarTodosMedicamentos(cod_Prescricao);


        ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalMedicamento');", true);
    }

    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
    }













    protected void btnGravarDosagem_Click(object sender, EventArgs e)
    {
        DateTime dataCadastro = DateTime.Now;
        int cod_Codigo = Convert.ToInt32(txbCodigo.Text);
        string usuario = User.Identity.Name.ToUpper();
        if (lblNome.Text == "Protocolo")
        {
            CalculoDosagemPrescricaoDAO.AtualizarCalculoDosagemPrescricao(cod_Codigo, dataCadastro, usuario,Convert.ToInt32(ddlPercentagem.SelectedValue), Convert.ToDecimal(txbDoseAlterada.Text));
          
        }
        else
        {
            CalculoDosagemPrescricaoPreQuimioDAO.AtualizarCalculoDosagemPrescricaoPreQuimio(cod_Codigo, dataCadastro, usuario, Convert.ToInt32(ddlPercentagem.SelectedValue), Convert.ToDecimal(txbDoseAlterada.Text));


        }
        
        MostrarTodosMedicamentos(cod_Prescricao);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalMedicamento');", true);
    }
    protected void gridViewProtocolo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DateTime dataCadastro = DateTime.Now;
        int index = Convert.ToInt32(e.CommandArgument);
        int idCalculoDosagemProtocolo = Convert.ToInt32(GridViewProtocolo.DataKeys[index].Value.ToString());

        if (e.CommandName.Equals("editRecord"))
        {




            lblNome.Text = "Protocolo";
            GridViewRow row = GridViewProtocolo.Rows[index];
            txbCodigo.Text = idCalculoDosagemProtocolo.ToString();
            txbCodigo.Visible = false;
            lbCodigo.Visible = false;
            lbMedicacao.InnerText = HttpUtility.HtmlDecode(row.Cells[0].Text);
            CalculoDosagemPrescricao dados = CalculoDosagemPrescricaoDAO.ApresentarDadosCalculoDosagem(idCalculoDosagemProtocolo);
            txbDoseProtocolo.Text = dados.dose.ToString();
            // Initialize the dropdown list with a specific value
            string initialPercentage = dados.porcentagemDiminuirDose.ToString(); // Example value 
            ListItem selectedItem = ddlPercentagem.Items.FindByValue(initialPercentage);
            ddlPercentagem.ClearSelection();
            selectedItem.Selected = true;
            txbDoseAlterada.Text = dados.dose_alterada.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalDosagem');", true);
        }
        else if (e.CommandName.Equals("deleteRecord"))
        {



            CalculoDosagemPrescricaoDAO.DeletarCalculoDosagemPrescricao(idCalculoDosagemProtocolo, dataCadastro);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalMedicamento');", true);
            MostrarTodosMedicamentos(cod_Prescricao);

        }






    }
}
