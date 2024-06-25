using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


public partial class Prescricao_HistoricoDeDocumentos : System.Web.UI.Page
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
    private string nome_da_impressora
    {
        get
        {
            if (ViewState["nome_da_impressora"] == null)
            {
                ViewState["nome_da_impressora"] = "";
            }
            return ViewState["nome_da_impressora"].ToString();
        }
        set
        {
            ViewState["nome_da_impressora"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            MembershipUser user = Membership.GetUser(User.Identity.Name);

            // Set the user ID in the hidden field when the page loads
            if (user != null)
            {
                // Assuming UserId is stored as ProviderUserKey
                Guid _userId = (Guid)user.ProviderUserKey;
                userId = _userId.ToString();


            }
            string ipAddress = IPUsuario();
            var impressora = ImpressoraDAO.buscarNomeDaImpressoraPorIP(ipAddress);
            string nome_da_impressora;
            if (impressora == null || impressora.nome_impressora == null)
            {
                nome_da_impressora = "";
            }
            else
            {
                nome_da_impressora = impressora.nome_impressora;
            }

            ddlImpressora.DataSource = ImpressoraDAO.ListaImpressora();
            ddlImpressora.DataTextField = "nome_impressora";
            ddlImpressora.DataValueField = "cod_impressora";
            ddlImpressora.DataBind();
            ddlImpressora.Items.FindByText(nome_da_impressora).Selected = true;
        }

    }
    public string userId { get; set; }

    public int _id_pedido { get; set; }
    public string nome_impressora { get; set; }
    protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        nome_impressora = ddlImpressora.SelectedValue;
        int index;

        if (e.CommandName.Equals("editRecord"))
        {
            index = Convert.ToInt32(e.CommandArgument);



            int idPrescricao = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta

            Response.Redirect("~/Prescricao/EditarCadastroPrescricao.aspx?idPrescricao=" + idPrescricao + "");
        }
        else if (e.CommandName.Equals("deleteRecord"))
        {
            index = Convert.ToInt32(e.CommandArgument);
            DateTime dataAtualizacao = DateTime.Now;
            int cod_Prescricao = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta
            Prescricao prescricao = PrescricaoDAO.BuscarPrescricaoPorCodPrescricao(cod_Prescricao);

            CalculoSuperficieCorporea calculoAnterior = CalculoSuperficieCorporeaDAO.BuscarCalculoSuperficieCorporeaPorCod_Calculo(prescricao.cod_Calculo);

            CalculoSuperficieCorporeaDAO.DeletarCalculoSuperficieCorporea(calculoAnterior, dataAtualizacao);

            CID_10_DAO.DeletarCidsPorPrescricao(cod_Prescricao, dataAtualizacao);
            AgendaDAO.DeletarAgendaTodos(cod_Prescricao, dataAtualizacao);
            CalculoDosagemPrescricaoDAO.DeletarCalculoDosagemPrescricaoTodos(cod_Prescricao, dataAtualizacao);
            CalculoDosagemPrescricaoPreQuimioDAO.DeletarCalculoDosagemPrescricaoPreQuimioTodos(cod_Prescricao, dataAtualizacao);
            GridViewRow row = GridView1.Rows[index];

            PrescricaoDAO.DeletarPrescricao(cod_Prescricao, dataAtualizacao);
            Response.Redirect("~/Prescricao/HistoricoDeDocumentos.aspx");

            //string _status = row.Cells[7].Text;


        }
        else if (e.CommandName.Equals("printRecord"))
        {
            index = Convert.ToInt32(e.CommandArgument);

            int cod_Prescricao = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta

            nome_impressora = ddlImpressora.SelectedItem.Text;
            // Variável para armazenar a quantidade cópias de cada prescrição 
           

                ImpressaoPrescricao.imprimirFicha(cod_Prescricao, nome_impressora);
           
          

            Response.Redirect("~/Prescricao/HistoricoDeDocumentos.aspx");


        }
        else if (e.CommandName.Equals("copyRecord"))
        {
            index = Convert.ToInt32(e.CommandArgument);

            _id_pedido = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta

       
            int idPrescricao = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta
     
            Response.Redirect("~/Prescricao/EditarCadastroPrescricao.aspx?idPrescricaoCopia=" + idPrescricao + "");


        }


        //string _status = row.Cells[7].Text;


    }


    public string IPUsuario()
    {
        string strIPUsuario = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(strIPUsuario))
        {
            // If there are multiple IP addresses, take the first one
            string[] addresses = strIPUsuario.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }
        else
        {
            // Fall back to REMOTE_ADDR if HTTP_X_FORWARDED_FOR is not present
            strIPUsuario = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        // Check if the IP is "::1" (IPv6 loopback address) and handle it accordingly
        if (strIPUsuario == "::1" || strIPUsuario == "127.0.0.1")
        {
            // Handle the loopback address case here (e.g., return a default message or a specific IP)
            strIPUsuario = "Localhost";
        }
        // Fall back to REMOTE_ADDR if HTTP_X_FORWARDED_FOR is not present
        return strIPUsuario;
    }

    protected void GridView1_PreRender(object sender, EventArgs e)
    {



        MembershipUser user = Membership.GetUser(User.Identity.Name);
        // Set the user ID in the hidden field when the page loads
        if (user != null)
        {
            Profissional profissional = ProfissionalDAO.GetProfissionalByUserId(userId);
            if (Roles.IsUserInRole(user.UserName, "administrador"))
            {

                GridView1.DataSource = RelatorioPrescricaoloDAO.listaTodosProtocolosByAdministradorl();

            }
            else
            {
                GridView1.DataSource = RelatorioPrescricaoloDAO.listaTodosProtocolosByCod_Profissional(profissional.cod_profissional);
            }
        }
        GridView1.DataBind();

        if (GridView1.Rows.Count > 0)
        {
            //This replaces <td> with <th> and adds the scope attribute
            GridView1.UseAccessibleHeader = true;

            //This will add the <thead> and <tbody> elements
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //This adds the <tfoot> element. 
            //Remove if you don't have a footer row
            GridView1.FooterRow.TableSection = TableRowSection.TableFooter;

        }
    }

    protected void btnGravar_Click(object sender, EventArgs e)
    {



    }
}
