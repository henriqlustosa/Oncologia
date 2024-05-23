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
            AgendaDAO.DeletarAgenda(cod_Prescricao, dataAtualizacao);
            CalculoDosagemPrescricaoDAO.DeletarCalculoDosagemPrescricao(cod_Prescricao, dataAtualizacao);
            GridViewRow row = GridView1.Rows[index];
            
            PrescricaoDAO.DeletarPrescricao(cod_Prescricao, dataAtualizacao);
            Response.Redirect("~/Prescricao/HistoricoDeDocumentos.aspx");

            //string _status = row.Cells[7].Text;


        }
        else if  (e.CommandName.Equals("printRecord"))
        {
            index = Convert.ToInt32(e.CommandArgument);

            _id_pedido = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

            ImpressaoPrescricao.imprimirFicha(_id_pedido, nome_impressora);
            Response.Redirect("~/Prescricao/HistoricoDeDocumentos.aspx");

            
        }



        //string _status = row.Cells[7].Text;


    }



    protected void GridView1_PreRender(object sender, EventArgs e)
    {
    



        Profissional profissional = ProfissionalDAO.GetProfissionalByUserId(userId);

        // colocar no grid OnPreRender="GridView1_PreRender"

        // You only need the following 2 lines of code if you are not 
        // using an ObjectDataSource of SqlDataSource
        GridView1.DataSource = RelatorioPrescricaoloDAO.listaTodosProtocolosByCod_Profissional(profissional.cod_profissional);

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
