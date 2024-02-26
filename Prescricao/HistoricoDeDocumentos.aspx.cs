using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Prescricao_HistoricoDeDocumentos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
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

            CalculoSuperficieCorporea calculoAnterior = CalculoSuperficieCorporeaDAO.BuscarCalculoSuperficieCorporeaPorCod_Calculo(cod_Prescricao);

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

            int _id_pedido = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta
            GridViewRow row = GridView1.Rows[index];
          ImpressaoPrescricao.imprimirFicha(_id_pedido, "Microsoft Print to PDF");

          
            Response.Redirect("~/Prescricao/Prescricao.aspx");

            //string _status = row.Cells[7].Text;


        }

    }

    protected void GridView1_PreRender(object sender, EventArgs e)
    {




        // colocar no grid OnPreRender="GridView1_PreRender"

        // You only need the following 2 lines of code if you are not 
        // using an ObjectDataSource of SqlDataSource
        GridView1.DataSource = RelatorioPrescricaoloDAO.listaTodosProtocolos();

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
}