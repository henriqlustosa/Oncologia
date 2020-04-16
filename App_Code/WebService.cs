using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod()]
    //public string QuantidadeAtivosStatus(string mesAno)
    //{
    //    int mes = Convert.ToInt32(mesAno.Substring(0, 2));
    //    int ano = Convert.ToInt32(mesAno.Substring(3, 4));
    //    var dados = new List<CallStatus>();

    //    using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
    //    {
    //        SqlCommand cmm = cnn.CreateCommand();


    //        cmm.CommandText = "SELECT tipo_paciente,CONVERT(varchar(10), dt_hr_be, 103) as Data ,COUNT(*) AS qtd_fichas, " +
    //                           " cast((count(tipo_paciente)*100.0)/(select COUNT(*) FROM hspmPs.dbo.ficha "+
    //                           " WHERE MONTH(dt_hr_be) = 4 and YEAR(dt_hr_be) = 2020)as decimal(5,2)) as porcentagem "+
    //                           " FROM hspmPs.dbo.ficha "+
    //                           " WHERE MONTH(dt_hr_be) = 4  and YEAR(dt_hr_be) = 2020 "+
    //                           " GROUP BY tipo_paciente, CONVERT(varchar(10), dt_hr_be, 103) " +
    //                           " ORDER BY qtd_fichas DESC";
    //        try
    //        {
    //            cnn.Open();
    //            SqlDataReader dr1 = cmm.ExecuteReader();

    //            //char[] ponto = { '.', ' ' };
    //            while (dr1.Read())
    //            {
    //                CallStatus call = new CallStatus();

    //                call.quantidade = dr1.GetInt32(0);
    //                call.descricao = dr1.GetString(1);
    //                call.porcentagem = Convert.ToString(dr1.GetDecimal(2)) + "%";


    //                dados.Add(call);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string error = ex.Message;
    //        }
    //    }
    //    JavaScriptSerializer js = new JavaScriptSerializer();
    //    return js.Serialize(dados);
    //}
      
}

   
