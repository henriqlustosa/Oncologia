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
using System.Web.Security;
using Microsoft.Exchange.WebServices.Data;
using System.Web.UI.HtmlControls;

public partial class Prescricao_Prescricao : System.Web.UI.Page
{
    // Propriedade centralizada para o código da prescrição
    // Propriedade centralizada para o código da prescrição
    private int CodPrescricao
    {
        get
        {
            return GetFromViewState("CodPrescricao", 0);
        }
        set
        {
            ViewState["CodPrescricao"] = value;
        }
    }

    // Propriedade centralizada para o nome da impressora
    private string NomeDaImpressora
    {
        get
        {
            return GetFromViewState("NomeDaImpressora", string.Empty);
        }
        set
        {
            ViewState["NomeDaImpressora"] = value;
        }
    }

    // Método genérico para acessar valores do ViewState com valor padrão
    private T GetFromViewState<T>(string key, T defaultValue)
    {
        if (ViewState[key] == null)
        {
            ViewState[key] = defaultValue;
        }
        return (T)ViewState[key];
    }




    protected void Page_Load(object sender, EventArgs e)
    {
        Log.Information("Loaded Page: {PageName}", this.GetType().Name);

        if (!IsPostBack)
        {
            InicializarCombos();
            ConfigurarImpressoraPorIP(IPUsuario());
            OcultarBotoesAcoes();
        }
    }

    protected void btnGravarDosagem_Click(object sender, EventArgs e)
    {
        DateTime dataCadastro = DateTime.Now;
        int cod_Codigo = Convert.ToInt32(txbCodigo.Text);
        string usuario = User.Identity.Name.ToUpper();
        if (lblNome.Text == "Protocolo")
        {
            CalculoDosagemPrescricaoDAO.AtualizarCalculoDosagemPrescricao(cod_Codigo, dataCadastro, usuario, Convert.ToInt32(ddlPercentagem.SelectedValue), Convert.ToDecimal(txbDoseAlterada.Text));

        }
        else
        {
            CalculoDosagemPrescricaoPreQuimioDAO.AtualizarCalculoDosagemPrescricaoPreQuimio(cod_Codigo, dataCadastro, usuario, Convert.ToInt32(ddlPercentagem.SelectedValue), Convert.ToDecimal(txbDoseAlterada.Text));


        }

        MostrarTodosMedicamentos(CodPrescricao);
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



            CalculoDosagemPrescricaoDAO.DeletarCalculoDosagemPrescricaoIndividual(idCalculoDosagemProtocolo, dataCadastro);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalMedicamento');", true);
            MostrarTodosMedicamentos(CodPrescricao);

        }






    }


    private void CarregarHtmlSelect(HtmlSelect htmlSelect, object dataSource, string textField, string valueField)
    {
        htmlSelect.DataSource = dataSource;
        htmlSelect.DataTextField = textField;
        htmlSelect.DataValueField = valueField;
        htmlSelect.DataBind();
    }

    // Inicialização dos combos (DDL e CheckBoxList)
    private void InicializarCombos()
    {
        CarregarCombo(ddlProtocolo, DescricaoProtocoloDAO.listaProtocolo(), "descricao", "cod_protocolo");
        CarregarCombo(ddlFinalidade, FinalidadeDoTratamentoDAO.ListaFinalidade(), "desc_finalidade", "cod_finalidade");
        CarregarHtmlSelect(select1, CID_10_DAO.listaCID_10(), "DESCRABREV", "SUBCAT");
        CarregarCheckBoxList(cblViasDeAcesso, ViasDeAcessoDAO.ListaViasDeAcesso(), "descr_vias_de_acesso", "cod_vias_de_acesso");
        CarregarCombo(ddlImpressora, ImpressoraDAO.ListaImpressora(), "nome_impressora", "cod_impressora");
    }

    private void CarregarCombo(DropDownList ddl, object dataSource, string textField, string valueField)
    {
        ddl.DataSource = dataSource;
        ddl.DataTextField = textField;
        ddl.DataValueField = valueField;
        ddl.DataBind();
    }

    private void CarregarCheckBoxList(CheckBoxList cbl, object dataSource, string textField, string valueField)
    {
        cbl.DataSource = dataSource;
        cbl.DataTextField = textField;
        cbl.DataValueField = valueField;
        cbl.DataBind();
    }

    private void OcultarBotoesAcoes()
    {
        btnAtualizar.Visible = false;
        btnVisualizarMedicamento.Visible = false;
        btnImprimir.Visible = false;
        btnAgendar.Visible = false;
    }

    private void ConfigurarImpressoraPorIP(string ipUsuario)
    {
        var impressora = ImpressoraDAO.buscarNomeDaImpressoraPorIP(ipUsuario);
        if (impressora != null && impressora.nome_impressora != null)
        {
            NomeDaImpressora = impressora.nome_impressora;
        }
        else
        {
            NomeDaImpressora = "INFO";
        }

        var item = ddlImpressora.Items.FindByText(NomeDaImpressora);
        if (item != null)
        {
            item.Selected = true;
        }
    }

    public string IPUsuario()
    {
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ??
                    HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

        if (string.IsNullOrEmpty(ip) || ip == "::1" || ip == "127.0.0.1")
        {
            ip = "Localhost";
        }

        string[] addresses = ip.Split(',');
        return addresses.Length > 0 ? addresses[0].Trim() : ip;

    }

    [WebMethod]
    public static List<Paciente> GetNomeDePacientes(string prefixo)
    {
        return PacienteDAO.GETNOME(prefixo.ToUpper());
    }

    [WebMethod]
    public static Paciente GetNomeDePacientesPoRh(string prefixo)
    {
        return PacienteDAO.GET(prefixo);
    }

    protected void btnGravar_Click(object sender, EventArgs e)
    {
        try
        {
            int codProfissional = ObterCodigoProfissional();
            DateTime dataCadastro = DateTime.Now;

            // Validação de campos obrigatórios
            if (!ValidarCamposObrigatorios())
            {
                MostrarMensagem("Preencha todos os campos obrigatórios.");
                return;
            }

            // Salvando os dados da prescrição
            CodPrescricao = SalvarPrescricao(dataCadastro, codProfissional);
            MostrarMensagem("Prescrição salva com sucesso!");

            AtualizarUIPosGravacao();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Erro ao gravar prescrição");
            MostrarMensagem("Erro ao gravar prescrição. Tente novamente.");
        }
    }

    private int ObterCodigoProfissional()
    {
        MembershipUser currentUser = Membership.GetUser();
        if (currentUser != null)
        {
            return ProfissionalDAO.GetProfissionalByUserId(currentUser.ProviderUserKey.ToString()).cod_profissional;
        }
        throw new Exception("Usuário não autenticado.");
    }

    private int SalvarPrescricao(DateTime dataCadastro, int codProfissional)
    {
        string usuario = User.Identity.Name.ToUpper();


        // Variável para salvar o prontuário que o usuário digitou no formulário
        int cod_Paciente = int.Parse(txbProntuario.Text);


        string message = PacienteOncologiaDAO.HandlePacienteOncologia(txbProntuario.Text, txbNomePaciente.Text, txbPais.Text,
                                         txbTelefone.Text, txbDdd.Text, ddlSexo.SelectedItem.ToString(),
                                         txbNascimento.Text, dataCadastro);
        Log.Information(message);



        CalculoSuperficieCorporea calculo = CalculoSuperficieCorporeaDAO.HandleCalculoSuperficieCorporea(txbAltura.Value.ToString(), txbPeso.Value.ToString(), txbBSA.Value.ToString(), dataCadastro);

        Prescricao prescricao = PrescricaoDAO.HandlePrescricaoGravacao(cod_Paciente, int.Parse(ddlFinalidade.SelectedValue.ToString()), int.Parse(ddlProtocolo.SelectedValue.ToString()), calculo.cod_Calculo, int.Parse(txbCiclos.Text.ToString()), int.Parse(txbIntervalos.Text.ToString()), DateTime.Parse(txbDtInicio.Text.ToString()), Convert.ToDecimal(txbCreatinina.Text), txbObservacao.Text.ToString(), dataCadastro, usuario, codProfissional);

        List<CID_10> listaDeCids = HandleCID();

        CID_10_DAO.GravaCidsPorPrescricao(listaDeCids, prescricao.cod_Prescricao, dataCadastro);


        List<ViasDeAcesso> listaDeViasDeAcesso = HandleViasDeAcesso();
        ViasDeAcessoDAO.GravaViasDeAcessoPorPrescricao(listaDeViasDeAcesso, prescricao.cod_Prescricao, dataCadastro);

        AgendaDAO.GravarAgenda(prescricao.data_inicio, prescricao.cod_Prescricao, prescricao.ciclos_provaveis, prescricao.intervalo_dias, prescricao.data_cadastro);



        CalculoDosagemPrescricao calculoDosagem = new CalculoDosagemPrescricao();
        CalculoDosagemPrescricaoPreQuimio calculoDosagemPrescricao = new CalculoDosagemPrescricaoPreQuimio();




        List<Protocolos> protocolos = ProtocolosDAO.BuscarProtocolosPorCodProtocolo(int.Parse(ddlProtocolo.SelectedValue.ToString()));

        List<CalculoDosagemPrescricao> calculoDosagens = calculoDosagem.calcular(calculo, protocolos, dataCadastro, prescricao, PacienteOncologiaDAO.ObterPacientePorRh(cod_Paciente), usuario);
        List<MedicacaoPreQuimioDetalhe> prequimios = MedicacaoPreQuimioDetalhelDAO.BuscarPrequimiosPorCodPreQuimio(prescricao.cod_Prequimio);

        List<CalculoDosagemPrescricaoPreQuimio> calculoDosagemPrescricaoPreQuimios = calculoDosagemPrescricao.calcular(prequimios, dataCadastro, prescricao, PacienteOncologiaDAO.ObterPacientePorRh(cod_Paciente), usuario);
        CalculoDosagemPrescricaoDAO.GravarCalculoDosagemPrescricao(calculoDosagens);
        CalculoDosagemPrescricaoPreQuimioDAO.GravarCalculoDosagemPrescricaoPreQuimio(calculoDosagemPrescricaoPreQuimios);








        btnGravar.Visible = false;
        btnAtualizar.Visible = true;
        btnVisualizarMedicamento.Visible = true;
        btnImprimir.Visible = true;
        btnAgendar.Visible = true;
        for (int i = 0; i < cblViasDeAcesso.Items.Count; i++)
        {
            cblViasDeAcesso.Items[i].Attributes.Add("onclick", "MutExChkList(this)");
        }
        CodPrescricao = prescricao.cod_Prescricao;
        return prescricao.cod_Prescricao;  // Substitua pelo ID retornado ao salvar
    }

    private void AtualizarUIPosGravacao()
    {
        btnGravar.Visible = false;
        btnAtualizar.Visible = true;
        btnVisualizarMedicamento.Visible = true;
        btnImprimir.Visible = true;
        btnAgendar.Visible = true;
    }

    private bool ValidarCamposObrigatorios()
    {
        return !string.IsNullOrEmpty(txbProntuario.Text) && ddlProtocolo.SelectedValue != null;
    }

    private void MostrarMensagem(string mensagem)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + mensagem + "');", true);

    }

    public List<CID_10> HandleCID()
    {



        return select1.Items.Cast<ListItem>()
                            .Where(i => i.Selected)
                            .Select(i => new CID_10 { SUBCAT = i.Value })
                            .ToList();

    }

    public List<ViasDeAcesso> HandleViasDeAcesso()
    {



        return cblViasDeAcesso.Items.Cast<ListItem>()
                            .Where(i => i.Selected)
                            .Select(i => new ViasDeAcesso { descr_vias_de_acesso = i.Text, cod_vias_de_acesso = int.Parse(i.Value) })// Convert string to int 
                            .ToList();

    }

    protected void btnAtualizar_Click(object sender, EventArgs e)
    {


        int cod_profissional = 0;
        MembershipUser currentUser = Membership.GetUser();
        if (currentUser != null)
        {
            object userId = currentUser.ProviderUserKey;
            cod_profissional = ProfissionalDAO.GetProfissionalByUserId(userId.ToString()).cod_profissional;
        }
        else
        {
            Response.Write("Failed to retrieve user information.");
        }

        string usuario = User.Identity.Name.ToUpper();




        // Variável que marca a data e hora da criação da prescrição
        DateTime dataCadastro = DateTime.Now;

        // Variável para salvar o prontuário que o usuário digitou no formulário
        int cod_Paciente = int.Parse(txbProntuario.Text);


        string message = PacienteOncologiaDAO.HandlePacienteOncologia(txbProntuario.Text, txbNomePaciente.Text, txbPais.Text,
                                      txbTelefone.Text, txbDdd.Text, ddlSexo.SelectedItem.ToString(),
                                      txbNascimento.Text, dataCadastro);
        Log.Information(message);



        Prescricao prescricaoAnterior = PrescricaoDAO.BuscarPrescricaoPorCodPrescricao(CodPrescricao);

        CalculoSuperficieCorporea calculoAnterior = CalculoSuperficieCorporeaDAO.BuscarCalculoSuperficieCorporeaPorCod_Calculo(prescricaoAnterior.cod_Calculo);

        CalculoSuperficieCorporeaDAO.DeletarCalculoSuperficieCorporea(calculoAnterior, dataCadastro);

        CalculoSuperficieCorporea calculo = CalculoSuperficieCorporeaDAO.HandleCalculoSuperficieCorporea(txbAltura.Value.ToString(), txbPeso.Value.ToString(), txbBSA.Value.ToString(), dataCadastro);






        List<CID_10> lista_cid_10 = HandleCID();


    
        Prescricao prescricao = PrescricaoDAO.HandlePrescricaoEdicao(CodPrescricao, cod_Paciente, int.Parse(ddlFinalidade.SelectedValue.ToString()), int.Parse(cblViasDeAcesso.SelectedValue.ToString()), int.Parse(ddlProtocolo.SelectedValue.ToString()), calculo.cod_Calculo, int.Parse(txbCiclos.Text.ToString()), int.Parse(txbIntervalos.Text.ToString()), DateTime.Parse(txbDtInicio.Text.ToString()), Convert.ToDecimal(txbCreatinina.Text), txbObservacao.Text.ToString(), dataCadastro, usuario, cod_profissional);

        CodPrescricao = prescricao.cod_Prescricao;





        CID_10_DAO.DeletarCidsPorPrescricao(prescricao.cod_Prescricao, prescricao.data_atualizacao);
        CID_10_DAO.GravaCidsPorPrescricao(lista_cid_10, prescricao.cod_Prescricao, dataCadastro);

        AgendaDAO.DeletarAgendaTodos(prescricao.cod_Prescricao, prescricao.data_atualizacao);
        AgendaDAO.GravarAgenda(prescricao.data_inicio, prescricao.cod_Prescricao, prescricao.ciclos_provaveis, prescricao.intervalo_dias, prescricao.data_atualizacao);



        CalculoDosagemPrescricao calculoDosagem = new CalculoDosagemPrescricao();



        List<Protocolos> protocolos = ProtocolosDAO.BuscarProtocolosPorCodProtocolo(int.Parse(ddlProtocolo.SelectedValue.ToString()));
        List<CalculoDosagemPrescricao> calculoDosagens = calculoDosagem.calcular(calculo, protocolos, dataCadastro, prescricao, PacienteOncologiaDAO.ObterPacientePorRh(cod_Paciente), usuario);


        CalculoDosagemPrescricaoDAO.DeletarCalculoDosagemPrescricaoTodos(prescricao.cod_Prescricao, prescricao.data_atualizacao);
        CalculoDosagemPrescricaoDAO.GravarCalculoDosagemPrescricao(calculoDosagens);

        CalculoDosagemPrescricaoPreQuimio calculoDosagemPrescricaoPrequimio = new CalculoDosagemPrescricaoPreQuimio();





        List<MedicacaoPreQuimioDetalhe> prequimios = MedicacaoPreQuimioDetalhelDAO.BuscarPrequimiosPorCodPreQuimio(prescricao.cod_Prequimio);
        List<CalculoDosagemPrescricaoPreQuimio> calculoDosagemPrescricaoPreQuimios = calculoDosagemPrescricaoPrequimio.calcular(prequimios, dataCadastro, prescricao, PacienteOncologiaDAO.ObterPacientePorRh(cod_Paciente), usuario);



        CalculoDosagemPrescricaoPreQuimioDAO.DeletarCalculoDosagemPrescricaoPreQuimioTodos(prescricao.cod_Prescricao, prescricao.data_atualizacao);
        CalculoDosagemPrescricaoPreQuimioDAO.GravarCalculoDosagemPrescricaoPreQuimio(calculoDosagemPrescricaoPreQuimios);




        //string mensagem = ProtocolosDAO.GravarProtocolo(protocolo);

        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);

        //ClearInputs(Page.Controls);// limpa os textbox
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Your Comment", "ClearInputs();", true);
        //Response.Redirect("~/Prescricao/HistoricoDeDocumentos.aspx");

    }



    protected void btnGravarAgenda_Click(object sender, EventArgs e)
    {
        DateTime dataCadastro = DateTime.Now;
        int cod_Codigo_Agenda = Convert.ToInt32(txbCodigoAgenda.Text);
        string usuario = User.Identity.Name.ToUpper();
        AgendaDAO.AtualizarAgenda(cod_Codigo_Agenda, dataCadastro, usuario, DateTime.Parse(txbDataAlterada.Text.ToString()));




        MostrarTodosAgendamentos(CodPrescricao);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalAgendamento');", true);
    }
    protected void gridViewAgendamento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        int idAgenda = Convert.ToInt32(GridViewAgendamento.DataKeys[index].Value.ToString()); //id da consulta
        DateTime dataCadastro = DateTime.Now;

        if (e.CommandName.Equals("editRecord"))
        {


            GridViewRow row = GridViewAgendamento.Rows[index];

            txbCodigoAgenda.Text = idAgenda.ToString();
            lbPaciente.InnerText = HttpUtility.HtmlDecode(PacienteDAO.BuscarPacientePorCodPrescricao(CodPrescricao).nome_paciente);
            Agenda dadosAgenda = AgendaDAO.ApresentarDadosAgendamento(idAgenda);
            txbDataAgenda.Text = dadosAgenda.data_agendada.ToString("dd/MM/yyyy");
            // Initialize the dropdown list with a specific value
            txbCodigoAgenda.Visible = false;
            lbCodigoAgenda.Visible = false;
            txbDataAlterada.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalEdicaoAgenda');", true);
        }
        else if (e.CommandName.Equals("deleteRecord"))
        {

            // Criar uma função para atualizar a posição e o total de posições da agenda criada para uma mesma prescrição.(cod_Prescricao)
            AgendaDAO.DeletarAgendaIndividual(idAgenda, dataCadastro);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalAgendamento');", true);

            MostrarTodosAgendamentos(CodPrescricao);

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
            txbCodigo.Visible = false;
            lbCodigo.Visible = false;
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


            CalculoDosagemPrescricaoPreQuimioDAO.DeletarCalculoDosagemPrescricaoPreQuimioIndividual(idCalculoDosagemPreQuimio, dataCadastro);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalMedicamento');", true);

            MostrarTodosMedicamentos(CodPrescricao);

        }






    }

    protected void btnCancelarAgenda_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalAgendamento');", true);
    }
    protected void btnImprimir_Click(object sender, EventArgs e)
    {

        // Variável para armazenar o nome da impressora selecionada
        string nome_impressora = ddlImpressora.SelectedItem.Text;
        // Variável para armazenar a quantidade cópias de cada prescrição 
        int vias = Convert.ToInt32(ddlVias.SelectedValue);
        while (vias > 0)
        {

            ImpressaoPrescricao.imprimirFicha(CodPrescricao, nome_impressora);
            vias--;
        }
    }
    private void MostrarTodosMedicamentos(int CodPrescricao)
    {
        GridViewPreQuimio.DataSource = RelatorioPreQumioDosagemDAO.MostrarMedicamentosParaEdicao(CodPrescricao);
        GridViewPreQuimio.DataBind();

        GridViewProtocolo.DataSource = RelatorioProtocoloDosagemDAO.MostrarMedicamentosParaEdicao(CodPrescricao);

        GridViewProtocolo.DataBind();
    }

    private void MostrarTodosAgendamentos(int CodPrescricao)
    {
        GridViewAgendamento.DataSource = AgendaDAO.BuscarAgendasPorCodPrescricao(CodPrescricao);
        GridViewAgendamento.DataBind();


    }

    protected void btnVisualizarMedicamento_Click(object sender, EventArgs e)
    {
        MostrarTodosMedicamentos(CodPrescricao);


        ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalMedicamento');", true);
    }

    protected void btnCancelarDosagem_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalMedicamento');", true);

    }


    protected void btnAgendar_Click(object sender, EventArgs e)
    {
        MostrarTodosAgendamentos(CodPrescricao);


        ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalAgendamento');", true);
    }
}