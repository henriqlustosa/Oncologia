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

        // Set the DataSource of the DropDownList
        ddlLogin.DataSource = userList;
        ddlLogin.DataTextField = "UserName";
        ddlLogin.DataValueField = "UserId";
        ddlLogin.DataBind();



    }
    protected void btnGravar_Click(object sender, EventArgs e)
    {
        Profissional prof = new Profissional();
        prof.nome_profissional = txbNomeProfissional.Text;
        prof.conselho = Convert.ToInt32(ddlConselho.SelectedValue);
        prof.nr_conselho = Convert.ToInt32(txbNumeroconselho.Text);
        prof.status_profissional = 1;//1 = ativo, 0 inativo
        prof.UserId = ddlLogin.SelectedValue.ToString();

        string mensagem = ProfissionalDAO.GravaProfissional(prof.nome_profissional, prof.conselho, prof.nr_conselho, prof.status_profissional, prof.UserId);

        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);

        ClearInputs(Page.Controls);// limpa os textbox
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

    protected void GridView1_PreRender(object sender, EventArgs e)
    {

        // colocar no grid OnPreRender="GridView1_PreRender"

        // You only need the following 2 lines of code if you are not 
        // using an ObjectDataSource of SqlDataSource
        GridView1.DataSource = ProfissionalDAO.ListaProfissionais();
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