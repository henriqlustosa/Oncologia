using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Serilog;
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

        string usuario = User.Identity.Name.ToUpper();




        // Variável que marca a data e hora da criação da prescrição
        DateTime dataCadastro = DateTime.Now;

        // Variável para salvar o prontuário que o usuário digitou no formulário
        int cod_Paciente = int.Parse(txbProntuario.Text);


        string message = PacienteOncologiaDAO.HandlePacienteOncologia(txbProntuario.Text, txbNomePaciente.Text, txbPais.Text,
                                      txbTelefone.Text, txbDdd.Text, ddlSexo.SelectedItem.ToString(),
                                      txbNascimento.Text, dataCadastro);
       Log.Information(message);



        Prescricao prescricaoAnterior = PrescricaoDAO.BuscarPrescricaoPorCodPrescricao(_id);

        CalculoSuperficieCorporea calculoAnterior = CalculoSuperficieCorporeaDAO.BuscarCalculoSuperficieCorporeaPorCod_Calculo(prescricaoAnterior.cod_Calculo);

        CalculoSuperficieCorporeaDAO.DeletarCalculoSuperficieCorporea(calculoAnterior,dataCadastro);

        CalculoSuperficieCorporea calculo = CalculoSuperficieCorporeaDAO.HandleCalculoSuperficieCorporea(txbAltura.Value.ToString(), txbPeso.Value.ToString(), txbBSA.Value.ToString(), dataCadastro);






        List<CID_10> lista_cid_10 = HandleCID();




        Prescricao prescricao = PrescricaoDAO.HandlePrescricaoEdicao(_id,cod_Paciente, int.Parse(ddlFinalidade.SelectedValue.ToString()), int.Parse(cblViasDeAcesso.SelectedValue.ToString()), int.Parse(ddlProtocolo.SelectedValue.ToString()), calculo.cod_Calculo, int.Parse(txbCiclos.Text.ToString()), int.Parse(txbIntervalos.Text.ToString()), DateTime.Parse(txbDtInicio.Text.ToString()), Convert.ToDecimal(txbCreatinina.Text), txbObservacao.Text.ToString(), dataCadastro, usuario);


   

       

        CID_10_DAO.DeletarCidsPorPrescricao(prescricao.cod_Prescricao, prescricao.data_atualizacao);
        CID_10_DAO.GravaCidsPorPrescricao(lista_cid_10, prescricao.cod_Prescricao,dataCadastro);

        AgendaDAO.DeletarAgenda(prescricao.cod_Prescricao, prescricao.data_atualizacao);
        AgendaDAO.GravarAgenda(prescricao.data_inicio, prescricao.cod_Prescricao, prescricao.ciclos_provaveis, prescricao.intervalo_dias, prescricao.data_atualizacao);


      
        CalculoDosagemPrescricao calculoDosagem = new CalculoDosagemPrescricao();

   

        List<Protocolos> protocolos = ProtocolosDAO.BuscarProtocolosPorCodProtocolo(int.Parse(ddlProtocolo.SelectedValue.ToString()));
        List<CalculoDosagemPrescricao>  calculoDosagens = calculoDosagem.calcular(calculo, protocolos, dataCadastro, prescricao, PacienteOncologiaDAO.ObterPacientePorRh(cod_Paciente), usuario);


        CalculoDosagemPrescricaoDAO.DeletarCalculoDosagemPrescricao(prescricao.cod_Prescricao, prescricao.data_atualizacao);
        CalculoDosagemPrescricaoDAO.GravarCalculoDosagemPrescricao(calculoDosagens);




        CalculoDosagemPrescricaoPreQuimio calculoDosagemPrescricaoPreQuimio = new CalculoDosagemPrescricaoPreQuimio();




        List<MedicacaoPreQuimioDetalhe> prequimios = MedicacaoPreQuimioDetalhelDAO.BuscarPrequimiosPorCodPreQuimio(prescricao.cod_Prequimio);
        List<CalculoDosagemPrescricaoPreQuimio> calculoDosagemPrescricaoPreQuimios = calculoDosagemPrescricaoPreQuimio.calcular(prequimios, dataCadastro, prescricao, PacienteOncologiaDAO.ObterPacientePorRh(cod_Paciente), usuario);



        CalculoDosagemPrescricaoPreQuimioDAO.DeletarCalculoDosagemPrescricaoPreQuimio(prescricao.cod_Prescricao, prescricao.data_atualizacao);
        CalculoDosagemPrescricaoPreQuimioDAO.GravarCalculoDosagemPrescricaoPreQuimio(calculoDosagemPrescricaoPreQuimios);
        //string mensagem = ProtocolosDAO.GravarProtocolo(protocolo);

        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);

        ClearInputs(Page.Controls);// limpa os textbox
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Your Comment", "ClearInputs();", true);
        Response.Redirect("~/Prescricao/HistoricoDeDocumentos.aspx");

        // ImpressaoPrescricao.imprimirFicha(prescricao.cod_Prescricao, "Microsoft Print to PDF");
        // vias--;

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
}