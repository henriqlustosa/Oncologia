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

public partial class Prescricao_Prescricao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
        }
    }
    [WebMethod]

    public static List<Paciente> GetNomeDePacientes(string prefixo)
   {
        
        List<Paciente> pacientes = new List<Paciente>();
        pacientes = PacienteDAO.GETNOME( prefixo.ToUpper());

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
    public int vias { get; set; }
    protected void btnGravar_Click(object sender, EventArgs e)
    {
        string mensagem = "";

        DateTime dataCadastro = DateTime.Now;
        PacienteOncologia pacienteOncologia = new PacienteOncologia();

        pacienteOncologia.cod_Paciente = int.Parse(txbProntuario.Text.ToString());
        pacienteOncologia.nome_paciente = txbNomePaciente.Text.ToString();
        pacienteOncologia.nome_mae = txbPais.Text.ToString();
        pacienteOncologia.telefone =int.Parse( txbTelefone.Text.ToString());
        pacienteOncologia.ddd_telefone = int.Parse(txbDdd.Text.ToString());
        pacienteOncologia.sexo = ddlSexo.SelectedItem.ToString();
        pacienteOncologia.data_nascimento =DateTime.Parse(txbNascimento.Text.ToString());
        pacienteOncologia.data_Cadastro =dataCadastro;

        if (PacienteOncologiaDAO.VerificarPacientePorRh(pacienteOncologia.cod_Paciente))

            mensagem = PacienteOncologiaDAO.AtualizarPaciente(pacienteOncologia);
       

        else
            pacienteOncologia.cod_Paciente = PacienteOncologiaDAO.GravarPacienteOncologia(pacienteOncologia);


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
        prescricao.intervalo_dias = int.Parse(txbCiclos.Text.ToString());
        prescricao.data_inicio = DateTime.Parse(txbDtInicio.Text.ToString());
        prescricao.data_termino = DateTime.Parse(txbDtTermino.Text.ToString());
        prescricao.observacao = txbObservacao.Text.ToString();

        prescricao.data_cadastro = dataCadastro;
        prescricao.nome_Usuario = User.Identity.Name.ToUpper();

        prescricao.cod_Prescricao = PrescricaoDAO.GravarPrescricao(prescricao);

        CID_10_DAO.GravaCidsPorPrescricao(lista_cid_10, prescricao.cod_Prescricao);

        //string mensagem = ProtocolosDAO.GravarProtocolo(protocolo);

        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);

        ClearInputs(Page.Controls);// limpa os textbox
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Your Comment", "ClearInputs();", true);


        ImpressaoPrescricao.imprimirFicha(prescricao.cod_Prescricao, "Impressora");
            vias--;
        
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
                ((DropDownList)ctrl).SelectedIndex =0;
            ClearInputs(ctrl.Controls);

        }

    
    
    }
}