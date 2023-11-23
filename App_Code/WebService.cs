using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Configuration;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod()]
    public string QuantidadeBeProcedenciaGrafico(string mesAno)
    {
        int mes = Convert.ToInt32(mesAno.Substring(0, 2));
        int ano = Convert.ToInt32(mesAno.Substring(3, 4));

        var dados = new List<BeStatus>();

        var quantidade1 = new List<int>();
        var descricao1 = new List<string>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT " +
                                   " CASE " +
                                       " WHEN procedencia != 'Espontânea' THEN 'Resgate' " +
                                       " ELSE procedencia " +
                                   " END AS Procedencia , " +
                                     " Count(*) as Quantidade" +
                                      " FROM [Oncologia_Desenv].[dbo].[ficha] " +
                                      " WHERE      status_ficha != 8 AND status_ficha != 4 " +
                                      " AND MONTH(dt_hr_be) = " + mes + " and YEAR(dt_hr_be) = " + ano +
                                      " group by CASE " +
                                       " WHEN procedencia != 'Espontânea' THEN 'Resgate' " +
                                       " ELSE procedencia " +
                                    " END ";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    descricao1.Add(dr1.GetString(0) + " - " + dr1.GetInt32(1));
                    quantidade1.Add(dr1.GetInt32(1));
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        Chart _chart = new Chart();


        _chart.labels = descricao1.ToArray();
        _chart.datasets = new List<Datasets>();

        List<Datasets> _dataSet = new List<Datasets>();

        _dataSet.Add(new Datasets()
        {
            label = "Total do Mês",
            data = quantidade1.ToArray(),
            backgroundColor = new string[] { "rgba(38, 185, 154, 0.31)", 
                                                 "rgba(231,76,60)" ,
                                                  },

            borderColor = new string[] { "rgba(38, 185, 154, 0.7)",
                                          "rgba(231,76,60)" ,
                                        },
            pointHoverBackgroundColor = new string[] { "#fff" },
            pointHoverBorderColor = new string[] { "rgba(220,220,220,1)" },
            pointBorderColor = new string[] { "rgba(38, 185, 154, 0.7)" },
            pointBackgroundColor = new string[] { "rgba(38, 185, 154, 0.7)" }
        });

        _chart.datasets = _dataSet;

        //O JavaScriptSerializer vai fazer o web service retornar JSON
        JavaScriptSerializer js = new JavaScriptSerializer();
        //return js.Serialize(dados);
        return js.Serialize(_chart);
    }



    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod()]
    public string PercentBeProcedenciaGrafico(string mesAno)
    {
        int mes = Convert.ToInt32(mesAno.Substring(0, 2));
        int ano = Convert.ToInt32(mesAno.Substring(3, 4));

        var dados = new List<BeStatus>();

        var quantidade1 = new List<decimal>();
        var descricao1 = new List<string>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT " +
                                   " CASE " +
                                       " WHEN procedencia != 'Espontânea' THEN 'Resgate' " +
                                       " ELSE procedencia " +
                                   " END AS Procedencia , " +
                                      " CAST(COUNT(procedencia) * 100.0 /(SELECT  COUNT(*) AS Expr1 FROM [Oncologia_Desenv].[dbo].[ficha]  WHERE (MONTH(dt_hr_be) = " + mes + ") AND (YEAR(dt_hr_be) = " + ano + ") AND  status_ficha != 8 AND status_ficha != 4) AS decimal(5, 2)) AS porcentagem " +
                                      " FROM [Oncologia_Desenv].[dbo].[ficha] " +
                                      " WHERE      status_ficha != 8 AND status_ficha != 4 " +
                                      " AND MONTH(dt_hr_be) = " + mes + " and YEAR(dt_hr_be) = " + ano +
                                      " group by CASE " +
                                       " WHEN procedencia != 'Espontânea' THEN 'Resgate' " +
                                       " ELSE procedencia " +
                                    " END ";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    descricao1.Add(dr1.GetString(0) + " - " + dr1.GetDecimal(1) +"%");
                    quantidade1.Add(dr1.GetDecimal(1));
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        Chart2 _chart = new Chart2();
        

        _chart.labels = descricao1.ToArray();
        _chart.datasets = new List<Datasets2>();
        
        List<Datasets2> _dataSet = new List<Datasets2>();
        
        _dataSet.Add(new Datasets2()
        {
            label = "Total do Mês",
            data = quantidade1.ToArray(),
            
            
            backgroundColor = new string[] { "rgba(38, 185, 154, 0.31)", 
                                                 "rgba(231,76,60)" ,
                                                  },

            borderColor = new string[] { "rgba(38, 185, 154, 0.7)",
                                          "rgba(231,76,60)" ,
                                        },

            pointHoverBackgroundColor = new string[] { "#fff" },
            pointHoverBorderColor = new string[] { "rgba(220,220,220,1)" },
            pointBorderColor = new string[] { "rgba(38, 185, 154, 0.7)" },
            pointBackgroundColor = new string[] { "rgba(38, 185, 154, 0.7)" }
        });

        _chart.datasets = _dataSet;

        //O JavaScriptSerializer vai fazer o web service retornar JSON
        JavaScriptSerializer js = new JavaScriptSerializer();
        //return js.Serialize(dados);
        return js.Serialize(_chart);
    }




    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod()]
    public string QuantidadeBeStatusGrafico(string mesAno)
    {
        int mes = Convert.ToInt32(mesAno.Substring(0, 2));
        int ano = Convert.ToInt32(mesAno.Substring(3, 4));

        var dados = new List<BeStatus>();

        var quantidade1 = new List<int>();
        var descricao1 = new List<string>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT count(f.status_ficha) as qtd_status, s.descricao_status " +
                                  " FROM [Oncologia_Desenv].[dbo].[ficha] f, [Oncologia_Desenv].[dbo].[status_ficha] s " +
                                  " WHERE s.cod_status = f.status_ficha " +
                                  " AND MONTH(f.dt_hr_be) = " + mes + " and YEAR(f.dt_hr_be) = " + ano +
                                  " GROUP BY s.descricao_status";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    BeStatus be = new BeStatus();

                    be.quantidade = dr1.GetInt32(0);
                    be.descricao = dr1.GetString(1) + " - " + dr1.GetInt32(0);

                    quantidade1.Add(be.quantidade);
                    descricao1.Add(be.descricao.ToString());

                    //dados.Add(call);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        Chart _chart = new Chart();
        _chart.labels = descricao1.ToArray();
        _chart.datasets = new List<Datasets>();

        List<Datasets> _dataSet = new List<Datasets>();
        _dataSet.Add(new Datasets()
        {
            label = "Total do Mês",
            data = quantidade1.ToArray(),
            backgroundColor = new string[] { "rgba(38, 185, 154, 0.31)", 
                                                 "rgba(0, 255, 255)" ,
                                                 "rgba(0, 128, 255)", 
                                                 "rgba(0, 0, 255)" ,
                                                 "rgba(0,100,0)", 
                                                 "rgba(0,255,0)" ,
                                                 "rgba(143,188,143)", 
                                                 "rgba(102,205,170)" ,
                                                 "rgba(0,128,128)", 
                                                 "rgba(0,0,0)" ,
                                                 "rgba(224,255,255)",
                                                 "rgba(106,90,205)",
                                                 "rgba(128,0,128)" },

            borderColor = new string[] { "rgba(38, 185, 154, 0.7)",
                                          "rgba(0, 255, 255)" ,
                                                 "rgba(0, 128, 255)", 
                                                 "rgba(0, 0, 255)" ,
                                                 "rgba(0,100,0)", 
                                                 "rgba(0,255,0)" ,
                                                 "rgba(143,188,143)", 
                                                 "rgba(102,205,170)" ,
                                                 "rgba(0,128,128)", 
                                                 "rgba(0,0,0)" ,
                                                 "rgba(224,255,255)",
                                                 "rgba(106,90,205)",
                                                 "rgba(128,0,128)"
                                        },

            pointHoverBackgroundColor = new string[] { "#fff" },
            pointHoverBorderColor = new string[] { "rgba(220,220,220,1)" },
            pointBorderColor = new string[] { "rgba(38, 185, 154, 0.7)" },
            pointBackgroundColor = new string[] { "rgba(38, 185, 154, 0.7)" }

        });

        _chart.datasets = _dataSet;

        //O JavaScriptSerializer vai fazer o web service retornar JSON
        JavaScriptSerializer js = new JavaScriptSerializer();
        //return js.Serialize(dados);
        return js.Serialize(_chart);
    }


    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod()]
    public string QuantidadeBeStatus(string mesAno)
    {
        int mes = Convert.ToInt32(mesAno.Substring(0, 2));
        int ano = Convert.ToInt32(mesAno.Substring(3, 4));
        var dados = new List<BeStatus>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT COUNT(s.descricao_status) AS qtd_status, s.descricao_status, " +
                               " cast((count(f.status_ficha)*100.0)/(select COUNT(*) FROM Oncologia_Desenv.dbo.ficha f INNER JOIN Oncologia_Desenv.dbo.status_ficha s ON f.status_ficha = s.cod_status " +
                               " WHERE MONTH(f.dt_hr_be) =" + mes + " and YEAR(f.dt_hr_be) = " + ano + ")as decimal(5,2)) as porcentagem " +
                               " FROM Oncologia_Desenv.dbo.ficha f INNER JOIN Oncologia_Desenv.dbo.status_ficha s ON f.status_ficha = s.cod_status " +
                               " WHERE MONTH(f.dt_hr_be) = " + mes + " and YEAR(f.dt_hr_be) = " + ano + " " +
                               " GROUP BY s.descricao_status " +
                               " ORDER BY qtd_status DESC";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    BeStatus call = new BeStatus();

                    call.quantidade = dr1.GetInt32(0);
                    call.descricao = dr1.GetString(1);
                    call.porcentagem = Convert.ToString(dr1.GetDecimal(2)) + "%";


                    dados.Add(call);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        return js.Serialize(dados);
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod()]
    public string AtendimentosMes(string mesAno)
    {
        int mes = Convert.ToInt32(mesAno.Substring(0, 2));
        int ano = Convert.ToInt32(mesAno.Substring(3, 4));

        var horas = new List<string>();
        var total = new List<int>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT DATEPART(DAY, dt_hr_be) AS [Day], COALESCE(COUNT(cod_ficha), 0) AS [Total Be] " +
                             " FROM [Oncologia_Desenv].[dbo].[ficha] " +
                             " WHERE MONTH(dt_hr_be) = " + mes + " and YEAR(dt_hr_be) = " + ano +
                             " AND status_ficha !=8 AND status_ficha !=4 " +
                             " GROUP BY DATEPART(DAY, dt_hr_be) " +
                             " ORDER BY DATEPART(DAY, dt_hr_be)";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    BeHoras be = new BeHoras();
                    be.horaDoDia = dr1.GetInt32(0);
                    be.totalBe = dr1.GetInt32(1);

                    horas.Add(be.horaDoDia.ToString());
                    total.Add(be.totalBe);

                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        Chart _chart = new Chart();
        _chart.labels = horas.ToArray();
        _chart.datasets = new List<Datasets>();

        List<Datasets> _dataSet = new List<Datasets>();
        _dataSet.Add(new Datasets()
        {
            label = "Evolução de atendimentos durante o Mês",
            data = total.ToArray(),
            backgroundColor = new string[] { "rgba(38, 185, 154, 0.31)" },
            borderColor = new string[] { "rgba(38, 185, 154, 0.7)" },

            pointBorderColor = new string[] { "rgba(38, 185, 154, 0.7)" },
            pointBackgroundColor = new string[] { "rgba(38, 185, 154, 0.7)" },
            pointHoverBackgroundColor = new string[] { "#fff" },
            pointHoverBorderColor = new string[] { "rgba(220,220,220,1)" },
            pointBorderWidth = "1",
            borderWidth = "1"
        });

        _chart.datasets = _dataSet;

        //O JavaScriptSerializer vai fazer o web service retornar JSON
        JavaScriptSerializer js = new JavaScriptSerializer();
        return js.Serialize(_chart);
    }



    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod()]
    public string TotalAtendimentosResgate(string mesAno)
    {
        int mes = Convert.ToInt32(mesAno.Substring(0, 2));
        int ano = Convert.ToInt32(mesAno.Substring(3, 4));
        var dados = new List<ResgateMes>();


        int t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0, t9 = 0,
                        t10 = 0, t11 = 0, t12 = 0, t13 = 0, t14 = 0, t15 = 0, t16 = 0, t17 = 0,
                        t18 = 0, t19 = 0, t20 = 0, t21 = 0, t22 = 0, t23 = 0, t24 = 0, t25 = 0,
                        t26 = 0, t27 = 0, t28 = 0, t29 = 0, t30 = 0, t31 = 0, ttotal = 0;


        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT [procedencia] " +
                                  ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10]" +
                                  ",[11],[12],[13],[14],[15],[16],[17],[18],[19],[20]" +
                                  ",[21],[22],[23],[24],[25],[26],[27],[28],[29]" +
                                  ",[30],[31]" +
                                  ",[TOTAL]" +
                              " FROM [Oncologia_Desenv].[dbo].[vw_con_be_total_procedencia]" +
                              " where BE_MONTH = "+ mes +" AND BE_YEAR =" + ano +
                              " and procedencia != 'ESPONTÂNEA'";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                ResgateMes rtotal = new ResgateMes();
                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    ResgateMes r = new ResgateMes();

                    r.procedencia = dr1.GetString(0);
                    r.dia1 = dr1.GetInt32(1);
                    t1 += r.dia1;
                    r.dia2 = dr1.GetInt32(2);
                    t2 += r.dia2;
                    r.dia3 = dr1.GetInt32(3);
                    t3 += r.dia3;
                    r.dia4 = dr1.GetInt32(4);
                    t4 += r.dia4;
                    r.dia5 = dr1.GetInt32(5);
                    t5 += r.dia5;
                    r.dia6 = dr1.GetInt32(6);
                    t6 += r.dia6;
                    r.dia7 = dr1.GetInt32(7);
                    t7 += r.dia7;
                    r.dia8 = dr1.GetInt32(8);
                    t8 += r.dia8;
                    r.dia9 = dr1.GetInt32(9);
                    t9 += r.dia9;
                    r.dia10 = dr1.GetInt32(10);
                    t10 += r.dia10;
                    r.dia11 = dr1.GetInt32(11);
                    t11 += r.dia11;
                    r.dia12 = dr1.GetInt32(12);
                    t12 += r.dia12;
                    r.dia13 = dr1.GetInt32(13);
                    t13 += r.dia13;
                    r.dia14 = dr1.GetInt32(14);
                    t14 += r.dia14;
                    r.dia15 = dr1.GetInt32(15);
                    t15 += r.dia15;
                    r.dia16 = dr1.GetInt32(16);
                    t16 += r.dia16;
                    r.dia17 = dr1.GetInt32(17);
                    t17 += r.dia17;
                    r.dia18 = dr1.GetInt32(18);
                    t18 += r.dia18;
                    r.dia19 = dr1.GetInt32(19);
                    t19 += r.dia19;
                    r.dia20 = dr1.GetInt32(20);
                    t20 += r.dia20;
                    r.dia21 = dr1.GetInt32(21);
                    t21 += r.dia21;
                    r.dia22 = dr1.GetInt32(22);
                    t22 += r.dia22;
                    r.dia23 = dr1.GetInt32(23);
                    t23 += r.dia23;
                    r.dia24 = dr1.GetInt32(24);
                    t24 += r.dia24;
                    r.dia25 = dr1.GetInt32(25);
                    t25 += r.dia25;
                    r.dia26 = dr1.GetInt32(26);
                    t26 += r.dia26;
                    r.dia27 = dr1.GetInt32(27);
                    t27 += r.dia27;
                    r.dia28 = dr1.GetInt32(28);
                    t28 += r.dia28;
                    r.dia29 = dr1.GetInt32(29);
                    t29 += r.dia29;
                    r.dia30 = dr1.GetInt32(30);
                    t30 += r.dia30;
                    r.dia31 = dr1.GetInt32(31);
                    t31 += r.dia31;
                    r.total = dr1.GetInt32(32);
                    ttotal += r.total;

                    dados.Add(r);
                }
                rtotal.procedencia = "Total";
                rtotal.dia1 = t1;
                rtotal.dia2 = t2;
                rtotal.dia3 = t3;
                rtotal.dia4 = t4;
                rtotal.dia5 = t5;
                rtotal.dia6 = t6;
                rtotal.dia7 = t7;
                rtotal.dia8 = t8;
                rtotal.dia9 = t9;
                rtotal.dia10 = t10;
                rtotal.dia11 = t11;
                rtotal.dia12 = t12;
                rtotal.dia13 = t13;
                rtotal.dia14 = t14;
                rtotal.dia15 = t15;
                rtotal.dia16 = t16;
                rtotal.dia17 = t17;
                rtotal.dia18 = t18;
                rtotal.dia19 = t19;
                rtotal.dia20 = t20;
                rtotal.dia21 = t21;
                rtotal.dia22 = t22;
                rtotal.dia23 = t23;
                rtotal.dia24 = t24;
                rtotal.dia25 = t25;
                rtotal.dia26 = t26;
                rtotal.dia27 = t27;
                rtotal.dia28 = t28;
                rtotal.dia29 = t29;
                rtotal.dia30 = t30;
                rtotal.dia31 = t31;
                rtotal.total = ttotal;
                dados.Add(rtotal);

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        return js.Serialize(dados);
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod()]
    public string TotalAtendimentosEspontaneo(string mesAno)
    {
        int mes = Convert.ToInt32(mesAno.Substring(0, 2));
        int ano = Convert.ToInt32(mesAno.Substring(3, 4));
        var dados = new List<ResgateMes>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT " +
                                  "[1],[2],[3],[4],[5],[6],[7],[8],[9],[10]" +
                                  ",[11],[12],[13],[14],[15],[16],[17],[18],[19],[20]" +
                                  ",[21],[22],[23],[24],[25],[26],[27],[28],[29]" +
                                  ",[30],[31]" +
                                  ",[TOTAL]" +
                              " FROM [Oncologia_Desenv].[dbo].[vw_con_be_total_procedencia]" +
                              " where BE_MONTH = "+ mes +" AND BE_YEAR = "+ ano +
                              " and procedencia = 'ESPONTÂNEA'";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    ResgateMes r = new ResgateMes();

                    r.procedencia = "Total";
                    r.dia1 = dr1.GetInt32(0);
                    r.dia2 = dr1.GetInt32(1);
                    r.dia3 = dr1.GetInt32(2);
                    r.dia4 = dr1.GetInt32(3);
                    r.dia5 = dr1.GetInt32(4);
                    r.dia6 = dr1.GetInt32(5);
                    r.dia7 = dr1.GetInt32(6);
                    r.dia8 = dr1.GetInt32(7);
                    r.dia9 = dr1.GetInt32(8);
                    r.dia10 = dr1.GetInt32(9);
                    r.dia11 = dr1.GetInt32(10);
                    r.dia12 = dr1.GetInt32(11);
                    r.dia13 = dr1.GetInt32(12);
                    r.dia14 = dr1.GetInt32(13);
                    r.dia15 = dr1.GetInt32(14);
                    r.dia16 = dr1.GetInt32(15);
                    r.dia17 = dr1.GetInt32(16);
                    r.dia18 = dr1.GetInt32(17);
                    r.dia19 = dr1.GetInt32(18);
                    r.dia20 = dr1.GetInt32(19);
                    r.dia21 = dr1.GetInt32(20);
                    r.dia22 = dr1.GetInt32(21);
                    r.dia23 = dr1.GetInt32(22);
                    r.dia24 = dr1.GetInt32(23);
                    r.dia25 = dr1.GetInt32(24);
                    r.dia26 = dr1.GetInt32(25);
                    r.dia27 = dr1.GetInt32(26);
                    r.dia28 = dr1.GetInt32(27);
                    r.dia29 = dr1.GetInt32(28);
                    r.dia30 = dr1.GetInt32(29);
                    r.dia31 = dr1.GetInt32(30);
                    r.total = dr1.GetInt32(31);
                    dados.Add(r);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        return js.Serialize(dados);
    }


    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod()]
    public string TotalAtendimentos(string mesAno)
    {
        int mes = Convert.ToInt32(mesAno.Substring(0, 2));
        int ano = Convert.ToInt32(mesAno.Substring(3, 4));
        var dados = new List<ResgateMes>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT [1],[2],[3],[4],[5],[6],[7],[8],[9],[10]" +
                                  ",[11],[12],[13],[14],[15],[16],[17],[18],[19],[20]" +
                                  ",[21],[22],[23],[24],[25],[26],[27],[28],[29]" +
                                  ",[30],[31]" +
                                  ",[TOTAL]" +
                              " FROM [Oncologia_Desenv].[dbo].[vw_con_be_total_mes]" +
                              " where BE_MONTH = "+ mes +" AND BE_YEAR =  " + ano ;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
               
                while (dr1.Read())
                {
                    ResgateMes r = new ResgateMes();
                    r.procedencia = "Total";

                    r.dia1 = dr1.GetInt32(0);
                    r.dia2 = dr1.GetInt32(1);
                    r.dia3 = dr1.GetInt32(2);
                    r.dia4 = dr1.GetInt32(3);
                    r.dia5 = dr1.GetInt32(4);
                    r.dia6 = dr1.GetInt32(5);
                    r.dia7 = dr1.GetInt32(6);
                    r.dia8 = dr1.GetInt32(7);
                    r.dia9 = dr1.GetInt32(8);
                    r.dia10 = dr1.GetInt32(9);
                    r.dia11 = dr1.GetInt32(10);
                    r.dia12 = dr1.GetInt32(11);
                    r.dia13 = dr1.GetInt32(12);
                    r.dia14 = dr1.GetInt32(13);
                    r.dia15 = dr1.GetInt32(14);
                    r.dia16 = dr1.GetInt32(15);
                    r.dia17 = dr1.GetInt32(16);
                    r.dia18 = dr1.GetInt32(17);
                    r.dia19 = dr1.GetInt32(18);
                    r.dia20 = dr1.GetInt32(19);
                    r.dia21 = dr1.GetInt32(20);
                    r.dia22 = dr1.GetInt32(21);
                    r.dia23 = dr1.GetInt32(22);
                    r.dia24 = dr1.GetInt32(23);
                    r.dia25 = dr1.GetInt32(24);
                    r.dia26 = dr1.GetInt32(25);
                    r.dia27 = dr1.GetInt32(26);
                    r.dia28 = dr1.GetInt32(27);
                    r.dia29 = dr1.GetInt32(28);
                    r.dia30 = dr1.GetInt32(29);
                    r.dia31 = dr1.GetInt32(30);
                    r.total = dr1.GetInt32(31);

                    dados.Add(r);
                }
                
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        return js.Serialize(dados);
    }


    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod()]
    public string QuantidadeBeProcedencia(string mesAno)
    {
        int mes = Convert.ToInt32(mesAno.Substring(0, 2));
        int ano = Convert.ToInt32(mesAno.Substring(3, 4));
        var dados = new List<BeStatus>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT "+
                                   " CASE "+
	                                   " WHEN procedencia != 'Espontânea' THEN 'Resgate' "+
	                                   " ELSE procedencia "+
                                   " END AS Procedencia , "+
                                   " COUNT(*) as qtd, "+
                                      " CAST(COUNT(procedencia) * 100.0 /(SELECT  COUNT(*) AS Expr1 FROM [Oncologia_Desenv].[dbo].[ficha]  WHERE (MONTH(dt_hr_be) = "+ mes +") AND (YEAR(dt_hr_be) = "+ ano +") AND  status_ficha != 8 AND status_ficha != 4 ) AS decimal(5, 2)) AS porcentagem "+
                                      " FROM [Oncologia_Desenv].[dbo].[ficha] "+
                                      " WHERE      status_ficha != 8 AND status_ficha != 4 " +
                                      " AND MONTH(dt_hr_be) = " + mes + " and YEAR(dt_hr_be) = " + ano +
                                      " group by CASE " +
	                                   " WHEN procedencia != 'Espontânea' THEN 'Resgate' "+
	                                   " ELSE procedencia " +
                                    " END ";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    BeStatus call = new BeStatus();

                    call.descricao = dr1.GetString(0);
                    call.quantidade = dr1.GetInt32(1);
                    call.porcentagem = Convert.ToString(dr1.GetDecimal(2)) + "%";


                    dados.Add(call);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        return js.Serialize(dados);
    }
}