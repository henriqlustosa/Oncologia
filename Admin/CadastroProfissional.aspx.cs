using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrativo_CadastroProfissional : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        // Get all users
        MembershipUserCollection users = Membership.GetAllUsers();

        // Create a list to hold the users
        var userList = new List<UserItem>();

        // Populate the list with usernames and UserIds
        foreach (MembershipUser user in users)
        {
            object userId = user.ProviderUserKey;
            if (userId != null)
            {
                userList.Add(new UserItem
                {
                    UserName = user.UserName,
                    UserId = userId.ToString()
                });
            }
        }



        if (!IsPostBack)
        {

            // Set the DataSource of the DropDownList
            ddlLogin.DataSource = userList;
            ddlLogin.DataTextField = "UserName";
            ddlLogin.DataValueField = "UserId";
            ddlLogin.DataBind();

            ddlConselho.DataSource = ConselhoDAO.ListaConselho();
            ddlConselho.DataTextField = "sigla_conselho";
            ddlConselho.DataValueField = "cod_conselho";
            ddlConselho.DataBind();


        }

    }
    protected void gridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            MembershipUserCollection users = Membership.GetAllUsers();

            // Create a list to hold the users
            var userList = new List<UserItem>();

            // Populate the list with usernames and UserIds
            foreach (MembershipUser user in users)
            {
                object userId = user.ProviderUserKey;
                if (userId != null)
                {
                    userList.Add(new UserItem
                    {
                        UserName = user.UserName,
                        UserId = userId.ToString()
                    });
                }
            }

            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("editRecord"))
            {
                EditRecord(index, userList);
            }
            else if (e.CommandName.Equals("deleteRecord"))
            {
                DeleteRecord(index);
            }
        }
        catch (Exception ex)
        {
            LogError(ex);
            ShowMessage("An error occurred while processing your request.");
        }
    }

    private void EditRecord(int index, List<UserItem> userList)
    {
        try
        {
            ddlConselhoEdicao.DataSource = ConselhoDAO.ListaConselho();
            ddlConselhoEdicao.DataTextField = "sigla_conselho";
            ddlConselhoEdicao.DataValueField = "cod_conselho";
            ddlConselhoEdicao.DataBind();

            // Set the DataSource of the DropDownList
            ddlLoginEdicao.DataSource = userList;
            ddlLoginEdicao.DataTextField = "UserName";
            ddlLoginEdicao.DataValueField = "UserId";
            ddlLoginEdicao.DataBind();
            foreach (ListItem item in ddlStatusEdicao.Items)
            {
                item.Selected = false;
            }
            int idProfissional = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); // id da consulta

            Profissional profissional = ProfissionalDAO.GetProfissionalByCodProfissional(idProfissional);

            txbNomeProfissionalEdicao.Text = profissional.nome_profissional;
            txbNumeroconselhoEdicao.Text = profissional.nr_conselho.ToString();
            ddlConselhoEdicao.Items.FindByText(profissional.sigla_conselho).Selected = true;
            ddlLoginEdicao.Items.FindByValue(profissional.UserId.ToString()).Selected = true;
            txbCodProfissionalEdicao.Text = profissional.cod_profissional.ToString();
            ddlStatusEdicao.Items.FindByValue(profissional.status_profissional).Selected = true;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "showModal('myModalProfissional');", true);
        }
        catch (Exception ex)
        {
            LogError(ex);
            ShowMessage("An error occurred while editing the record.");
        }
    }

    private void DeleteRecord(int index)
    {
        try
        {
            int cod_profissional = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); // id da consulta
            ProfissionalDAO.DeletarProfisional(cod_profissional);

            Response.Redirect("~/Admin/CadastroProfissional.aspx");
        }
        catch (Exception ex)
        {
            LogError(ex);
            ShowMessage("An error occurred while deleting the record.");
        }
    }

    private void ShowMessage(string message)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message +"');", true);
    }

    private void LogError(Exception ex)
    {
        // Replace with your logging mechanism
        Console.WriteLine(ex.Message);
        // For example, you might log to a file, database, or a logging framework like log4net or NLog
    }
    protected void btnGravar_Click(object sender, EventArgs e)
    {
        try
        {
            Profissional prof = new Profissional
            {
                nome_profissional = txbNomeProfissional.Text,
                conselho = Convert.ToInt32(ddlConselho.SelectedValue),
                nr_conselho = Convert.ToInt32(txbNumeroconselho.Text),
                status_profissional = "1", // 1 = ativo, 0 inativo
                UserId = ddlLogin.SelectedValue
            };

            string usuario = User.Identity.Name.ToUpper();
            DateTime data_cadastro = DateTime.Now;

            // Save the professional details to the database
            string mensagem = ProfissionalDAO.GravaProfissional(
                prof.nome_profissional,
                prof.conselho,
                prof.nr_conselho,
                prof.status_profissional,
                prof.UserId,
                data_cadastro,
                usuario
            );

            // Display the message to the user
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(" +mensagem+ "');", true);

            // Clear all inputs on the page
            ClearInputs(Page.Controls);
        }
        catch (Exception ex)
        {
            // Log the exception and show an error message
            // Replace with your logging mechanism
            Console.WriteLine(ex.Message);

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('An error occurred while processing your request.');", true);
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
    }
    protected void btnGravarProfissional_Click(object sender, EventArgs e)
    {
        try
        {
            // Create and populate the Profissional object
            Profissional prof = new Profissional
            {
                cod_profissional = Convert.ToInt32(txbCodProfissionalEdicao.Text),
                nome_profissional = txbNomeProfissionalEdicao.Text,
                conselho = Convert.ToInt32(ddlConselhoEdicao.SelectedValue),
                nr_conselho = Convert.ToInt32(txbNumeroconselhoEdicao.Text),
                status_profissional = ddlStatusEdicao.SelectedValue, // 1 = ativo, 2 inativo
                UserId = ddlLoginEdicao.SelectedValue
            };

            string usuario = User.Identity.Name.ToUpper();
            DateTime data_cadastro_atualizado = DateTime.Now;

            // Update the professional details in the database
            ProfissionalDAO.AtualizarProfissional(
                prof.cod_profissional,
                prof.nome_profissional,
                prof.conselho,
                prof.nr_conselho,
                prof.status_profissional,
                prof.UserId,
                data_cadastro_atualizado,
                usuario
            );

            // Display success message
            Console.WriteLine("Profissional atualizado com sucesso.");

            // Clear all inputs on the page
            ClearInputs(Page.Controls);
        }
        catch (Exception ex)
        {
            // Log the exception and show an error message
            // Replace with your logging mechanism
            Console.WriteLine(ex.Message);

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('An error occurred while processing your request.');", true);
        }
    }
    protected void btnCancelarProfissional_Click(object sender, EventArgs e)
    {
    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        try
        {
            // You only need the following 2 lines of code if you are not 
            // using an ObjectDataSource of SqlDataSource
            GridView1.DataSource = ProfissionalDAO.ListaProfissionais();
            GridView1.DataBind();

            if (GridView1.Rows.Count > 0)
            {
                try
                {
                    // This replaces <td> with <th> and adds the scope attribute
                    GridView1.UseAccessibleHeader = true;

                    // This will add the <thead> and <tbody> elements
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

                    // This adds the <tfoot> element. 
                    // Remove if you don't have a footer row
                    if (GridView1.FooterRow != null)
                    {
                        GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    ShowMessage("An error occurred while rendering the GridView.");
                }
            }
        }
        catch (Exception ex)
        {
            LogError(ex);
            ShowMessage("An error occurred while binding the GridView.");
        }
    }

  


}