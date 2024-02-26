using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Prescricao_EditarCadastroPrescricao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int _id = Convert.ToInt32(Request.QueryString["idPrescricao"]);
            Prescricao prescricao = PrescricaoDAO.BuscarPrescricaoPorCodPrescricao(_id);
            if (prescricao != null)
            {

                txbCiclos.Text = prescricao.ciclos_provaveis.ToString();
                txbIntervalos.Text = prescricao.intervalo_dias.ToString();
                txbDtInicio.Text = prescricao.data_inicio.ToString();
                txbCreatinina.Text = prescricao.creatinina.ToString();
                txbObservacao.Text = prescricao.observacao.ToString();


                PacienteOncologia paciente = PacienteDAO.BuscarPacientePorCodPrescricao(prescricao.cod_Paciente);

                txbNomePaciente.Text = paciente.nome_paciente.ToString();
                txbProntuario.Text = paciente.cod_Paciente.ToString();
                txbNascimento.Text = paciente.data_nascimento.ToString("dd/MM/yyyy");
                txbPais.Text = paciente.nome_mae.ToString();
                txbDdd.Text = paciente.ddd_telefone.ToString();
                txbTelefone.Text = paciente.telefone.ToString();
                txbIdade.Text = CalcularIdade(paciente.data_nascimento).ToString();
                ddlSexo.Items.FindByValue(paciente.sexo.ToString()).Selected = true;

                CalculoSuperficieCorporea calculo = CalculoSuperficieCorporeaDAO.BuscarCalculoSuperficieCorporeaPorCod_Calculo(prescricao.cod_Calculo);





                txbAltura.Value = calculo.altura.ToString();
                txbPeso.Value = calculo.peso.ToString();
                txbBSA.Value = calculo.BSA.ToString();

                ddlProtocolo.DataSource = DescricaoProtocoloDAO.listaProtocolo();
                ddlProtocolo.DataTextField = "descricao";
                ddlProtocolo.DataValueField = "cod_protocolo";
                ddlProtocolo.DataBind();


                ddlProtocolo.Items.FindByValue(prescricao.cod_Protocolos.ToString()).Selected = true;


                ddlFinalidade.DataSource = FinalidadeDoTratamentoDAO.ListaFinalidade();
                ddlFinalidade.DataTextField = "desc_finalidade";
                ddlFinalidade.DataValueField = "cod_finalidade";
                ddlFinalidade.DataBind();

                ddlFinalidade.Items.FindByValue(prescricao.cod_Finalidade.ToString()).Selected = true;

                select1.DataSource = CID_10_DAO.listaCID_10();
                select1.DataTextField = "DESCRABREV";
                select1.DataValueField = "SUBCAT";
                select1.DataBind();

                List<CID_Prescricao> cids_escolhidos = new List<CID_Prescricao>();
                cids_escolhidos = CID_10_DAO.BuscarCIDsPorCodPrescricao(_id);
                foreach (CID_Prescricao cid in cids_escolhidos)
                {

                    select1.Items.FindByValue(cid.SUBCAT).Selected = true;

                }

                cblViasDeAcesso.DataSource = ViasDeAcessoDAO.ListaViasDeAcesso();
                cblViasDeAcesso.DataTextField = "descr_vias_de_acesso";
                cblViasDeAcesso.DataValueField = "cod_vias_de_acesso";
                cblViasDeAcesso.DataBind();
                for (int i = 0; i < cblViasDeAcesso.Items.Count; i++)
                {
                    cblViasDeAcesso.Items[i].Attributes.Add("onclick", "MutExChkList(this)");
                }
                cblViasDeAcesso.Items.FindByValue(prescricao.cod_Vias_De_Acesso.ToString()).Selected = true;
            }
        }
    }



    private static int CalcularIdade(DateTime dataNascimento)
    {
        int idade = DateTime.Now.Year - dataNascimento.Year;
        if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
        {
            idade = idade - 1;
        }
        return idade;
    }
    //[WebMethod]

    //public static List<Paciente> GetNomeDePacientes(string prefixo)
    //{

    //    List<Paciente> pacientes = new List<Paciente>();
    //    pacientes = PacienteDAO.GETNOME(prefixo.ToUpper());

    //    return pacientes;
    //}

    //[WebMethod]

    //public static Paciente GetNomeDePacientesPoRh(string prefixo)
    //{

    //    Paciente pacientes = new Paciente();
    //    pacientes = PacienteDAO.GET(prefixo);

    //    return pacientes;
    //}

    //protected void btnPesquisar_Click(object sender, EventArgs e)
    //{

    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "#modalAdicionarPaciente", "$('#modalDadosDoPaciente').modal('show');", true);


    //}
    public int vias { get; set; }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Prescricao/HistoricoDeDocumentos.aspx");
    }
        
        protected void btnGravar_Click(object sender, EventArgs e)
    {
        string mensagem = "";
        int _id = Convert.ToInt32(Request.QueryString["idPrescricao"]);
        DateTime dataCadastro = DateTime.Now;
        PacienteOncologia pacienteOncologia = new PacienteOncologia();

        pacienteOncologia.cod_Paciente = int.Parse(txbProntuario.Text.ToString());
        pacienteOncologia.nome_paciente = txbNomePaciente.Text.ToString();
        pacienteOncologia.nome_mae = txbPais.Text.ToString();
        pacienteOncologia.telefone = int.Parse(txbTelefone.Text.ToString());
        pacienteOncologia.ddd_telefone = int.Parse(txbDdd.Text.ToString());
        pacienteOncologia.sexo = ddlSexo.SelectedItem.ToString();
        pacienteOncologia.data_nascimento = DateTime.Parse(txbNascimento.Text.ToString());
        pacienteOncologia.data_Cadastro = dataCadastro;

        if (PacienteOncologiaDAO.VerificarPacientePorRh(pacienteOncologia.cod_Paciente))

            mensagem = PacienteOncologiaDAO.AtualizarPaciente(pacienteOncologia);


        else
            pacienteOncologia.cod_Paciente = PacienteOncologiaDAO.GravarPacienteOncologia(pacienteOncologia);

        CalculoSuperficieCorporea calculoAnterior = CalculoSuperficieCorporeaDAO.BuscarCalculoSuperficieCorporeaPorCod_Calculo(_id);

        CalculoSuperficieCorporeaDAO.DeletarCalculoSuperficieCorporea(calculoAnterior,dataCadastro);
        CalculoSuperficieCorporea calculo = new CalculoSuperficieCorporea();

        calculo.altura = int.Parse(txbAltura.Value.ToString());
        calculo.peso = int.Parse(txbPeso.Value.ToString());
        calculo.BSA = Decimal.Parse(txbBSA.Value.ToString().Replace('.', ','));
        calculo.dataCadastro = dataCadastro;

        calculo.cod_Calculo = CalculoSuperficieCorporeaDAO.GravarCalculoSuperficieCorporea(calculo);





        List<CID_10> lista_cid_10 = new List<CID_10>();

        for (int i = 0; i < select1.Items.Count; i++)
        {
            if (select1.Items[i].Selected)
            {
                CID_10 cid = new CID_10();

                cid.SUBCAT = select1.Items[i].Value;
                lista_cid_10.Add(cid);
            }
        }




        Prescricao prescricao = new Prescricao();

        prescricao.cod_Paciente = pacienteOncologia.cod_Paciente;
        prescricao.cod_Finalidade = int.Parse(ddlFinalidade.SelectedValue.ToString());
        prescricao.cod_Vias_De_Acesso = int.Parse(cblViasDeAcesso.SelectedValue.ToString());
        prescricao.cod_Protocolos = int.Parse(ddlProtocolo.SelectedValue.ToString());
        prescricao.cod_Calculo = calculo.cod_Calculo;
        prescricao.ciclos_provaveis = int.Parse(txbCiclos.Text.ToString());
        prescricao.intervalo_dias = int.Parse(txbIntervalos.Text.ToString());
        prescricao.data_inicio = DateTime.Parse(txbDtInicio.Text.ToString());
        prescricao.creatinina = Convert.ToDecimal(txbCreatinina.Text);
        prescricao.observacao = txbObservacao.Text.ToString();

        prescricao.data_atualizacao = dataCadastro;
        prescricao.nome_Usuario_Atualizacao= User.Identity.Name.ToUpper();

        prescricao.cod_Prequimio = PrescricaoDAO.BuscarPrequimioPorCod_Protocolo(prescricao.cod_Protocolos);

        prescricao.cod_Prescricao = _id;

        PrescricaoDAO.AtualizarPrescricao(prescricao);

        CID_10_DAO.DeletarCidsPorPrescricao(prescricao.cod_Prescricao, prescricao.data_atualizacao);
        CID_10_DAO.GravaCidsPorPrescricao(lista_cid_10, prescricao.cod_Prescricao);

        AgendaDAO.DeletarAgenda(prescricao.cod_Prescricao, prescricao.data_atualizacao);
        AgendaDAO.GravarAgenda(prescricao.data_inicio, prescricao.cod_Prescricao, prescricao.ciclos_provaveis, prescricao.intervalo_dias, prescricao.data_atualizacao);


        List<CalculoDosagemPrescricao> calculoDosagens = new List<CalculoDosagemPrescricao>();
        CalculoDosagemPrescricao calculoDosagem = new CalculoDosagemPrescricao();

        List<Protocolos> protocolos = new List<Protocolos>();

        protocolos = ProtocolosDAO.BuscarProtocolosPorCodPrescricao(int.Parse(ddlProtocolo.SelectedValue.ToString()));
        calculoDosagens = calculoDosagem.calcular(calculo, protocolos, dataCadastro, prescricao, pacienteOncologia);


        CalculoDosagemPrescricaoDAO.DeletarCalculoDosagemPrescricao(prescricao.cod_Prescricao, prescricao.data_atualizacao);
        CalculoDosagemPrescricaoDAO.GravarCalculoDosagemPrescricao(calculoDosagens);


        //string mensagem = ProtocolosDAO.GravarProtocolo(protocolo);

        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);

        ClearInputs(Page.Controls);// limpa os textbox
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Your Comment", "ClearInputs();", true);
        Response.Redirect("~/Prescricao/HistoricoDeDocumentos.aspx");

        // ImpressaoPrescricao.imprimirFicha(prescricao.cod_Prescricao, "Microsoft Print to PDF");
        // vias--;

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
}