using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ConsolidadosDAO
/// </summary>
public class ConsolidadosDAO
{
    public static DataTable GetListaDados(int mes, int ano, int categoria)
    {

        string qyPaciente = "SELECT [tipo_paciente] " +
                          ",[BE_MONTH] " +
                          ",[BE_YEAR] " +
                          ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14] ,[15],[16],[17] ,[18],[19],[20]" +
                          ",[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31],[TOTAL] " +
                      " FROM [Oncologia_Desenv].[dbo].[vw_con_be_tipo_pac_mes]" +
                      " WHERE BE_MONTH =" + mes + " AND BE_YEAR =" + ano;

        string qySetor = "SELECT [setor] " +
                        ",[BE_MONTH] " +
                        ",[BE_YEAR] " +
                        ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14] ,[15],[16],[17] ,[18],[19],[20]" +
                        ",[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31],[TOTAL] " +
                    " FROM [Oncologia_Desenv].[dbo].[vw_con_be_setor_mes]" +
                    " WHERE BE_MONTH =" + mes + " AND BE_YEAR =" + ano;

        string qyProcedencia = "SELECT [tipo_paciente] " +
                        ",[BE_MONTH] " +
                        ",[BE_YEAR] " +
                        ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14] ,[15],[16],[17] ,[18],[19],[20]" +
                        ",[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31],[TOTAL] " +
                    " FROM [Oncologia_Desenv].[dbo].[vw_con_be_procedencia]" +
                    " WHERE [procedencia] = 'SAMU' AND BE_MONTH =" + mes + " AND BE_YEAR =" + ano;

        string qyPM = "SELECT [tipo_paciente] " +
                        ",[BE_MONTH] " +
                        ",[BE_YEAR] " +
                        ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14] ,[15],[16],[17] ,[18],[19],[20]" +
                        ",[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31],[TOTAL] " +
                    " FROM [Oncologia_Desenv].[dbo].[vw_con_be_procedencia]" +
                    " WHERE [procedencia] = 'POLÍCIA MILITAR' AND BE_MONTH =" + mes + " AND BE_YEAR =" + ano;

        string qyAMA = "SELECT [tipo_paciente] " +
                        ",[BE_MONTH] " +
                        ",[BE_YEAR] " +
                        ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14] ,[15],[16],[17] ,[18],[19],[20]" +
                        ",[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31],[TOTAL] " +
                    " FROM [Oncologia_Desenv].[dbo].[vw_con_be_procedencia]" +
                    " WHERE [procedencia] = 'AMA - Sé' AND BE_MONTH =" + mes + " AND BE_YEAR =" + ano;

        string qyBombeiro = "SELECT [tipo_paciente] " +
                        ",[BE_MONTH] " +
                        ",[BE_YEAR] " +
                        ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14] ,[15],[16],[17] ,[18],[19],[20]" +
                        ",[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31],[TOTAL] " +
                    " FROM [Oncologia_Desenv].[dbo].[vw_con_be_procedencia]" +
                    " WHERE [procedencia] = 'BOMBEIRO' AND BE_MONTH =" + mes + " AND BE_YEAR =" + ano;

        string qyMetro = "SELECT [tipo_paciente] " +
                               ",[BE_MONTH] " +
                               ",[BE_YEAR] " +
                               ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14] ,[15],[16],[17] ,[18],[19],[20]" +
                               ",[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31],[TOTAL] " +
                           " FROM [Oncologia_Desenv].[dbo].[vw_con_be_procedencia]" +
                           " WHERE [procedencia] = 'METRÔ' AND BE_MONTH =" + mes + " AND BE_YEAR =" + ano;

        string qyGCM = "SELECT [tipo_paciente] " +
                        ",[BE_MONTH] " +
                        ",[BE_YEAR] " +
                        ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14] ,[15],[16],[17] ,[18],[19],[20]" +
                        ",[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31],[TOTAL] " +
                    " FROM [Oncologia_Desenv].[dbo].[vw_con_be_procedencia]" +
                    " WHERE [procedencia] = 'GCM' AND BE_MONTH =" + mes + " AND BE_YEAR =" + ano;

        string qyAP = "SELECT [tipo_paciente] " +
                       ",[BE_MONTH] " +
                       ",[BE_YEAR] " +
                       ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14] ,[15],[16],[17] ,[18],[19],[20]" +
                       ",[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31],[TOTAL] " +
                   " FROM [Oncologia_Desenv].[dbo].[vw_con_be_procedencia]" +
                   " WHERE [procedencia] = 'AMBULÂNCIA PARTICULAR' AND BE_MONTH =" + mes + " AND BE_YEAR =" + ano;





        int t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0, t9 = 0,
                        t10 = 0, t11 = 0, t12 = 0, t13 = 0, t14 = 0, t15 = 0, t16 = 0, t17 = 0,
                        t18 = 0, t19 = 0, t20 = 0, t21 = 0, t22 = 0, t23 = 0, t24 = 0, t25 = 0,
                        t26 = 0, t27 = 0, t28 = 0, t29 = 0, t30 = 0, t31 = 0, ttotal = 0;
        DataTable dt = new DataTable();
        dt.Columns.Add("#", typeof(string));

        if (Util.verificaAno(ano))
        {
            if (new[] { 2 }.Contains(mes))
            {
                for (int i = 1; i <= 29; i++)
                {
                    dt.Columns.Add(i.ToString(), typeof(int));
                }
            }
        }

        if (new[] { 2 }.Contains(mes))
        {
            for (int i = 1; i <= 28; i++)
            {
                dt.Columns.Add(i.ToString(), typeof(int));
            }
        }
        else if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(mes))
        {
            for (int i = 1; i <= 31; i++)
            {
                dt.Columns.Add(i.ToString(), typeof(int));
            }
        }
        else if (new[] { 4, 6, 9, 11 }.Contains(mes))
        {
            for (int i = 1; i <= 30; i++)
            {
                dt.Columns.Add(i.ToString(), typeof(int));
            }
        }
        dt.Columns.Add("Total", typeof(int));


        var lista = new List<ConsolidadoMesTipo>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();
            if (categoria.Equals(1))
            {
                cmm.CommandText = qyPaciente;
            }
            else if (categoria.Equals(2))
            {
                cmm.CommandText = qySetor;
            }
            else if (categoria.Equals(3))
            {
                cmm.CommandText = qyProcedencia;
            }
            else if (categoria.Equals(4))
            {
                cmm.CommandText = qyPM;
            }
            else if (categoria.Equals(5))
            {
                cmm.CommandText = qyAMA;
            }
            else if (categoria.Equals(6))
            {
                cmm.CommandText = qyBombeiro;
            }
            else if (categoria.Equals(7))
            {
                cmm.CommandText = qyMetro;
            }
            else if (categoria.Equals(8))
            {
                cmm.CommandText = qyGCM;
            }
            else if (categoria.Equals(9))
            {
                cmm.CommandText = qyAP;
            }

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                DataRow rowTotais = dt.NewRow();

                while (dr1.Read())
                {
                    DataRow row1 = dt.NewRow();

                    ConsolidadoMesTipo consolidado = new ConsolidadoMesTipo();

                    if (categoria.Equals(1) || categoria.Equals(3) || categoria.Equals(4) || categoria.Equals(5) || categoria.Equals(6) || categoria.Equals(7) || categoria.Equals(8) || categoria.Equals(9))
                    {
                        if (dr1.GetString(0) == "F")
                        {
                            consolidado.tipo = "FUNCIONÁRIO";
                        }
                        if (dr1.GetString(0) == "M")
                        {
                            consolidado.tipo = "MUNÍCIPE";
                        }
                    }
                    else if (categoria.Equals(2))
                    {
                        consolidado.tipo = dr1.GetString(0);
                    }

                    consolidado.mes = dr1.GetInt32(1);
                    consolidado.ano = dr1.GetInt32(2);
                    consolidado.dia1 = dr1.GetInt32(3);
                    t1 += consolidado.dia1;
                    consolidado.dia2 = dr1.GetInt32(4);
                    t2 += consolidado.dia2;
                    consolidado.dia3 = dr1.GetInt32(5);
                    t3 += consolidado.dia3;
                    consolidado.dia4 = dr1.GetInt32(6);
                    t4 += consolidado.dia4;
                    consolidado.dia5 = dr1.GetInt32(7);
                    t5 += consolidado.dia5;
                    consolidado.dia6 = dr1.GetInt32(8);
                    t6 += consolidado.dia6;
                    consolidado.dia7 = dr1.GetInt32(9);
                    t7 += consolidado.dia7;
                    consolidado.dia8 = dr1.GetInt32(10);
                    t8 += consolidado.dia8;
                    consolidado.dia9 = dr1.GetInt32(11);
                    t9 += consolidado.dia9;
                    consolidado.dia10 = dr1.GetInt32(12);
                    t10 += consolidado.dia10;
                    consolidado.dia11 = dr1.GetInt32(13);
                    t11 += consolidado.dia11;
                    consolidado.dia12 = dr1.GetInt32(14);
                    t12 += consolidado.dia12;
                    consolidado.dia13 = dr1.GetInt32(15);
                    t13 += consolidado.dia13;
                    consolidado.dia14 = dr1.GetInt32(16);
                    t14 += consolidado.dia14;
                    consolidado.dia15 = dr1.GetInt32(17);
                    t15 += consolidado.dia15;
                    consolidado.dia16 = dr1.GetInt32(18);
                    t16 += consolidado.dia16;
                    consolidado.dia17 = dr1.GetInt32(19);
                    t17 += consolidado.dia17;
                    consolidado.dia18 = dr1.GetInt32(20);
                    t18 += consolidado.dia18;
                    consolidado.dia19 = dr1.GetInt32(21);
                    t19 += consolidado.dia19;
                    consolidado.dia20 = dr1.GetInt32(22);
                    t20 += consolidado.dia20;
                    consolidado.dia21 = dr1.GetInt32(23);
                    t21 += consolidado.dia21;
                    consolidado.dia22 = dr1.GetInt32(24);
                    t22 += consolidado.dia22;
                    consolidado.dia23 = dr1.GetInt32(25);
                    t23 += consolidado.dia23;
                    consolidado.dia24 = dr1.GetInt32(26);
                    t24 += consolidado.dia24;
                    consolidado.dia25 = dr1.GetInt32(27);
                    t25 += consolidado.dia25;
                    consolidado.dia26 = dr1.GetInt32(28);
                    t26 += consolidado.dia26;
                    consolidado.dia27 = dr1.GetInt32(29);
                    t27 += consolidado.dia27;
                    consolidado.dia28 = dr1.GetInt32(30);
                    t28 += consolidado.dia28;
                    consolidado.dia29 = dr1.GetInt32(31);
                    t29 += consolidado.dia29;
                    consolidado.dia30 = dr1.GetInt32(32);
                    t30 += consolidado.dia30;
                    consolidado.dia31 = dr1.GetInt32(33);
                    t31 += consolidado.dia31;
                    consolidado.total = dr1.GetInt32(34);
                    ttotal += consolidado.total;


                    row1["#"] = consolidado.tipo;

                    if (Util.verificaAno(ano))
                    {
                        if (new[] { 2 }.Contains(mes))
                        {

                            row1["1"] = consolidado.dia1;
                            row1["2"] = consolidado.dia2;
                            row1["3"] = consolidado.dia3;
                            row1["4"] = consolidado.dia4;
                            row1["5"] = consolidado.dia5;
                            row1["6"] = consolidado.dia6;
                            row1["7"] = consolidado.dia7;
                            row1["8"] = consolidado.dia8;
                            row1["9"] = consolidado.dia9;
                            row1["10"] = consolidado.dia10;
                            row1["11"] = consolidado.dia11;
                            row1["12"] = consolidado.dia12;
                            row1["13"] = consolidado.dia13;
                            row1["14"] = consolidado.dia14;
                            row1["15"] = consolidado.dia15;
                            row1["16"] = consolidado.dia16;
                            row1["17"] = consolidado.dia17;
                            row1["18"] = consolidado.dia18;
                            row1["19"] = consolidado.dia19;
                            row1["20"] = consolidado.dia20;
                            row1["21"] = consolidado.dia21;
                            row1["22"] = consolidado.dia22;
                            row1["23"] = consolidado.dia23;
                            row1["24"] = consolidado.dia24;
                            row1["25"] = consolidado.dia25;
                            row1["26"] = consolidado.dia26;
                            row1["27"] = consolidado.dia27;
                            row1["28"] = consolidado.dia28;
                            row1["29"] = consolidado.dia29;
                        }
                    }
                    if (new[] { 2 }.Contains(mes))
                    {

                        row1["1"] = consolidado.dia1;
                        row1["2"] = consolidado.dia2;
                        row1["3"] = consolidado.dia3;
                        row1["4"] = consolidado.dia4;
                        row1["5"] = consolidado.dia5;
                        row1["6"] = consolidado.dia6;
                        row1["7"] = consolidado.dia7;
                        row1["8"] = consolidado.dia8;
                        row1["9"] = consolidado.dia9;
                        row1["10"] = consolidado.dia10;
                        row1["11"] = consolidado.dia11;
                        row1["12"] = consolidado.dia12;
                        row1["13"] = consolidado.dia13;
                        row1["14"] = consolidado.dia14;
                        row1["15"] = consolidado.dia15;
                        row1["16"] = consolidado.dia16;
                        row1["17"] = consolidado.dia17;
                        row1["18"] = consolidado.dia18;
                        row1["19"] = consolidado.dia19;
                        row1["20"] = consolidado.dia20;
                        row1["21"] = consolidado.dia21;
                        row1["22"] = consolidado.dia22;
                        row1["23"] = consolidado.dia23;
                        row1["24"] = consolidado.dia24;
                        row1["25"] = consolidado.dia25;
                        row1["26"] = consolidado.dia26;
                        row1["27"] = consolidado.dia27;
                        row1["28"] = consolidado.dia28;
                    }
                    else if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(mes))
                    {
                        row1["1"] = consolidado.dia1;
                        row1["2"] = consolidado.dia2;
                        row1["3"] = consolidado.dia3;
                        row1["4"] = consolidado.dia4;
                        row1["5"] = consolidado.dia5;
                        row1["6"] = consolidado.dia6;
                        row1["7"] = consolidado.dia7;
                        row1["8"] = consolidado.dia8;
                        row1["9"] = consolidado.dia9;
                        row1["10"] = consolidado.dia10;
                        row1["11"] = consolidado.dia11;
                        row1["12"] = consolidado.dia12;
                        row1["13"] = consolidado.dia13;
                        row1["14"] = consolidado.dia14;
                        row1["15"] = consolidado.dia15;
                        row1["16"] = consolidado.dia16;
                        row1["17"] = consolidado.dia17;
                        row1["18"] = consolidado.dia18;
                        row1["19"] = consolidado.dia19;
                        row1["20"] = consolidado.dia20;
                        row1["21"] = consolidado.dia21;
                        row1["22"] = consolidado.dia22;
                        row1["23"] = consolidado.dia23;
                        row1["24"] = consolidado.dia24;
                        row1["25"] = consolidado.dia25;
                        row1["26"] = consolidado.dia26;
                        row1["27"] = consolidado.dia27;
                        row1["28"] = consolidado.dia28;
                        row1["29"] = consolidado.dia29;
                        row1["30"] = consolidado.dia30;
                        row1["31"] = consolidado.dia31;
                    }
                    else if (new[] { 4, 6, 9, 11 }.Contains(mes))
                    {
                        row1["1"] = consolidado.dia1;
                        row1["2"] = consolidado.dia2;
                        row1["3"] = consolidado.dia3;
                        row1["4"] = consolidado.dia4;
                        row1["5"] = consolidado.dia5;
                        row1["6"] = consolidado.dia6;
                        row1["7"] = consolidado.dia7;
                        row1["8"] = consolidado.dia8;
                        row1["9"] = consolidado.dia9;
                        row1["10"] = consolidado.dia10;
                        row1["11"] = consolidado.dia11;
                        row1["12"] = consolidado.dia12;
                        row1["13"] = consolidado.dia13;
                        row1["14"] = consolidado.dia14;
                        row1["15"] = consolidado.dia15;
                        row1["16"] = consolidado.dia16;
                        row1["17"] = consolidado.dia17;
                        row1["18"] = consolidado.dia18;
                        row1["19"] = consolidado.dia19;
                        row1["20"] = consolidado.dia20;
                        row1["21"] = consolidado.dia21;
                        row1["22"] = consolidado.dia22;
                        row1["23"] = consolidado.dia23;
                        row1["24"] = consolidado.dia24;
                        row1["25"] = consolidado.dia25;
                        row1["26"] = consolidado.dia26;
                        row1["27"] = consolidado.dia27;
                        row1["28"] = consolidado.dia28;
                        row1["29"] = consolidado.dia29;
                        row1["30"] = consolidado.dia30;
                    }
                    row1["Total"] = consolidado.total;

                    dt.Rows.Add(row1);
                }
                if (Util.verificaAno(ano))
                {
                    if (new[] { 2 }.Contains(mes))
                    {

                        rowTotais["#"] = "TOTAL";
                        rowTotais["1"] = t1;
                        rowTotais["2"] = t2;
                        rowTotais["3"] = t3;
                        rowTotais["4"] = t4;
                        rowTotais["5"] = t5;
                        rowTotais["6"] = t6;
                        rowTotais["7"] = t7;
                        rowTotais["8"] = t8;
                        rowTotais["9"] = t9;
                        rowTotais["10"] = t10;
                        rowTotais["11"] = t11;
                        rowTotais["12"] = t12;
                        rowTotais["13"] = t13;
                        rowTotais["14"] = t14;
                        rowTotais["15"] = t15;
                        rowTotais["16"] = t16;
                        rowTotais["17"] = t17;
                        rowTotais["18"] = t18;
                        rowTotais["19"] = t19;
                        rowTotais["20"] = t20;
                        rowTotais["21"] = t21;
                        rowTotais["22"] = t22;
                        rowTotais["23"] = t23;
                        rowTotais["24"] = t24;
                        rowTotais["25"] = t25;
                        rowTotais["26"] = t26;
                        rowTotais["27"] = t27;
                        rowTotais["28"] = t28;
                        rowTotais["29"] = t29;
                        rowTotais["Total"] = ttotal;
                        dt.Rows.Add(rowTotais);
                    }
                }
                if (new[] { 2 }.Contains(mes))
                {

                    rowTotais["#"] = "TOTAL";
                    rowTotais["1"] = t1;
                    rowTotais["2"] = t2;
                    rowTotais["3"] = t3;
                    rowTotais["4"] = t4;
                    rowTotais["5"] = t5;
                    rowTotais["6"] = t6;
                    rowTotais["7"] = t7;
                    rowTotais["8"] = t8;
                    rowTotais["9"] = t9;
                    rowTotais["10"] = t10;
                    rowTotais["11"] = t11;
                    rowTotais["12"] = t12;
                    rowTotais["13"] = t13;
                    rowTotais["14"] = t14;
                    rowTotais["15"] = t15;
                    rowTotais["16"] = t16;
                    rowTotais["17"] = t17;
                    rowTotais["18"] = t18;
                    rowTotais["19"] = t19;
                    rowTotais["20"] = t20;
                    rowTotais["21"] = t21;
                    rowTotais["22"] = t22;
                    rowTotais["23"] = t23;
                    rowTotais["24"] = t24;
                    rowTotais["25"] = t25;
                    rowTotais["26"] = t26;
                    rowTotais["27"] = t27;
                    rowTotais["28"] = t28;
                    rowTotais["Total"] = ttotal;
                    dt.Rows.Add(rowTotais);
                }
                else if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(mes))
                {
                    rowTotais["#"] = "TOTAL";
                    rowTotais["1"] = t1;
                    rowTotais["2"] = t2;
                    rowTotais["3"] = t3;
                    rowTotais["4"] = t4;
                    rowTotais["5"] = t5;
                    rowTotais["6"] = t6;
                    rowTotais["7"] = t7;
                    rowTotais["8"] = t8;
                    rowTotais["9"] = t9;
                    rowTotais["10"] = t10;
                    rowTotais["11"] = t11;
                    rowTotais["12"] = t12;
                    rowTotais["13"] = t13;
                    rowTotais["14"] = t14;
                    rowTotais["15"] = t15;
                    rowTotais["16"] = t16;
                    rowTotais["17"] = t17;
                    rowTotais["18"] = t18;
                    rowTotais["19"] = t19;
                    rowTotais["20"] = t20;
                    rowTotais["21"] = t21;
                    rowTotais["22"] = t22;
                    rowTotais["23"] = t23;
                    rowTotais["24"] = t24;
                    rowTotais["25"] = t25;
                    rowTotais["26"] = t26;
                    rowTotais["27"] = t27;
                    rowTotais["28"] = t28;
                    rowTotais["29"] = t29;
                    rowTotais["30"] = t30;
                    rowTotais["31"] = t31;
                    rowTotais["Total"] = ttotal;
                    dt.Rows.Add(rowTotais);
                }
                else if (new[] { 4, 6, 9, 11 }.Contains(mes))
                {
                    rowTotais["#"] = "TOTAL";
                    rowTotais["1"] = t1;
                    rowTotais["2"] = t2;
                    rowTotais["3"] = t3;
                    rowTotais["4"] = t4;
                    rowTotais["5"] = t5;
                    rowTotais["6"] = t6;
                    rowTotais["7"] = t7;
                    rowTotais["8"] = t8;
                    rowTotais["9"] = t9;
                    rowTotais["10"] = t10;
                    rowTotais["11"] = t11;
                    rowTotais["12"] = t12;
                    rowTotais["13"] = t13;
                    rowTotais["14"] = t14;
                    rowTotais["15"] = t15;
                    rowTotais["16"] = t16;
                    rowTotais["17"] = t17;
                    rowTotais["18"] = t18;
                    rowTotais["19"] = t19;
                    rowTotais["20"] = t20;
                    rowTotais["21"] = t21;
                    rowTotais["22"] = t22;
                    rowTotais["23"] = t23;
                    rowTotais["24"] = t24;
                    rowTotais["25"] = t25;
                    rowTotais["26"] = t26;
                    rowTotais["27"] = t27;
                    rowTotais["28"] = t28;
                    rowTotais["29"] = t29;
                    rowTotais["30"] = t30;
                    rowTotais["Total"] = ttotal;
                    dt.Rows.Add(rowTotais);
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return dt;
    }



    public static DataTable GetListaDadosSetor(int mes, int ano, string _setor)
    {
        string qySetor = "SELECT [tipo_paciente] " +
      ",[BE_MONTH]" +
      ",[BE_YEAR]" +
      ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20],[21],[22],[23],[24] ,[25],[26] ,[27],[28],[29],[30] ,[31]" +
      ",[TOTAL] " +
  " FROM [Oncologia_Desenv].[dbo].[vw_setor_grupo_pac] " +
  " where setor = '" + _setor + "' and [BE_MONTH] = " + mes + " and [BE_YEAR] = " + ano;

        int t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0, t9 = 0,
                        t10 = 0, t11 = 0, t12 = 0, t13 = 0, t14 = 0, t15 = 0, t16 = 0, t17 = 0,
                        t18 = 0, t19 = 0, t20 = 0, t21 = 0, t22 = 0, t23 = 0, t24 = 0, t25 = 0,
                        t26 = 0, t27 = 0, t28 = 0, t29 = 0, t30 = 0, t31 = 0, ttotal = 0;
        DataTable dt = new DataTable();
        dt.Columns.Add("#", typeof(string));

        if (Util.verificaAno(ano))
        {
            if (new[] { 2 }.Contains(mes))
            {
                for (int i = 1; i <= 29; i++)
                {
                    dt.Columns.Add(i.ToString(), typeof(int));
                }
            }
        }

        if (new[] { 2 }.Contains(mes))
        {
            for (int i = 1; i <= 28; i++)
            {
                dt.Columns.Add(i.ToString(), typeof(int));
            }
        }
        else if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(mes))
        {
            for (int i = 1; i <= 31; i++)
            {
                dt.Columns.Add(i.ToString(), typeof(int));
            }
        }
        else if (new[] { 4, 6, 9, 11 }.Contains(mes))
        {
            for (int i = 1; i <= 30; i++)
            {
                dt.Columns.Add(i.ToString(), typeof(int));
            }
        }
        dt.Columns.Add("Total", typeof(int));


        var lista = new List<ConsolidadoMesTipo>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = qySetor;


            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                DataRow rowTotais = dt.NewRow();

                while (dr1.Read())
                {
                    DataRow row1 = dt.NewRow();
                    ConsolidadoMesTipo consolidado = new ConsolidadoMesTipo();

                    if (dr1.GetString(0) == "F")
                    {
                        consolidado.tipo = "FUNCIONÁRIO";
                    }
                    if (dr1.GetString(0) == "M")
                    {
                        consolidado.tipo = "MUNÍCIPE";
                    }

                    consolidado.mes = dr1.GetInt32(1);
                    consolidado.ano = dr1.GetInt32(2);
                    consolidado.dia1 = dr1.GetInt32(3);
                    t1 += consolidado.dia1;
                    consolidado.dia2 = dr1.GetInt32(4);
                    t2 += consolidado.dia2;
                    consolidado.dia3 = dr1.GetInt32(5);
                    t3 += consolidado.dia3;
                    consolidado.dia4 = dr1.GetInt32(6);
                    t4 += consolidado.dia4;
                    consolidado.dia5 = dr1.GetInt32(7);
                    t5 += consolidado.dia5;
                    consolidado.dia6 = dr1.GetInt32(8);
                    t6 += consolidado.dia6;
                    consolidado.dia7 = dr1.GetInt32(9);
                    t7 += consolidado.dia7;
                    consolidado.dia8 = dr1.GetInt32(10);
                    t8 += consolidado.dia8;
                    consolidado.dia9 = dr1.GetInt32(11);
                    t9 += consolidado.dia9;
                    consolidado.dia10 = dr1.GetInt32(12);
                    t10 += consolidado.dia10;
                    consolidado.dia11 = dr1.GetInt32(13);
                    t11 += consolidado.dia11;
                    consolidado.dia12 = dr1.GetInt32(14);
                    t12 += consolidado.dia12;
                    consolidado.dia13 = dr1.GetInt32(15);
                    t13 += consolidado.dia13;
                    consolidado.dia14 = dr1.GetInt32(16);
                    t14 += consolidado.dia14;
                    consolidado.dia15 = dr1.GetInt32(17);
                    t15 += consolidado.dia15;
                    consolidado.dia16 = dr1.GetInt32(18);
                    t16 += consolidado.dia16;
                    consolidado.dia17 = dr1.GetInt32(19);
                    t17 += consolidado.dia17;
                    consolidado.dia18 = dr1.GetInt32(20);
                    t18 += consolidado.dia18;
                    consolidado.dia19 = dr1.GetInt32(21);
                    t19 += consolidado.dia19;
                    consolidado.dia20 = dr1.GetInt32(22);
                    t20 += consolidado.dia20;
                    consolidado.dia21 = dr1.GetInt32(23);
                    t21 += consolidado.dia21;
                    consolidado.dia22 = dr1.GetInt32(24);
                    t22 += consolidado.dia22;
                    consolidado.dia23 = dr1.GetInt32(25);
                    t23 += consolidado.dia23;
                    consolidado.dia24 = dr1.GetInt32(26);
                    t24 += consolidado.dia24;
                    consolidado.dia25 = dr1.GetInt32(27);
                    t25 += consolidado.dia25;
                    consolidado.dia26 = dr1.GetInt32(28);
                    t26 += consolidado.dia26;
                    consolidado.dia27 = dr1.GetInt32(29);
                    t27 += consolidado.dia27;
                    consolidado.dia28 = dr1.GetInt32(30);
                    t28 += consolidado.dia28;
                    consolidado.dia29 = dr1.GetInt32(31);
                    t29 += consolidado.dia29;
                    consolidado.dia30 = dr1.GetInt32(32);
                    t30 += consolidado.dia30;
                    consolidado.dia31 = dr1.GetInt32(33);
                    t31 += consolidado.dia31;
                    consolidado.total = dr1.GetInt32(34);
                    ttotal += consolidado.total;


                    row1["#"] = consolidado.tipo;

                    if (Util.verificaAno(ano))
                    {
                        if (new[] { 2 }.Contains(mes))
                        {

                            row1["1"] = consolidado.dia1;
                            row1["2"] = consolidado.dia2;
                            row1["3"] = consolidado.dia3;
                            row1["4"] = consolidado.dia4;
                            row1["5"] = consolidado.dia5;
                            row1["6"] = consolidado.dia6;
                            row1["7"] = consolidado.dia7;
                            row1["8"] = consolidado.dia8;
                            row1["9"] = consolidado.dia9;
                            row1["10"] = consolidado.dia10;
                            row1["11"] = consolidado.dia11;
                            row1["12"] = consolidado.dia12;
                            row1["13"] = consolidado.dia13;
                            row1["14"] = consolidado.dia14;
                            row1["15"] = consolidado.dia15;
                            row1["16"] = consolidado.dia16;
                            row1["17"] = consolidado.dia17;
                            row1["18"] = consolidado.dia18;
                            row1["19"] = consolidado.dia19;
                            row1["20"] = consolidado.dia20;
                            row1["21"] = consolidado.dia21;
                            row1["22"] = consolidado.dia22;
                            row1["23"] = consolidado.dia23;
                            row1["24"] = consolidado.dia24;
                            row1["25"] = consolidado.dia25;
                            row1["26"] = consolidado.dia26;
                            row1["27"] = consolidado.dia27;
                            row1["28"] = consolidado.dia28;
                            row1["29"] = consolidado.dia29;
                        }
                    }
                    if (new[] { 2 }.Contains(mes))
                    {

                        row1["1"] = consolidado.dia1;
                        row1["2"] = consolidado.dia2;
                        row1["3"] = consolidado.dia3;
                        row1["4"] = consolidado.dia4;
                        row1["5"] = consolidado.dia5;
                        row1["6"] = consolidado.dia6;
                        row1["7"] = consolidado.dia7;
                        row1["8"] = consolidado.dia8;
                        row1["9"] = consolidado.dia9;
                        row1["10"] = consolidado.dia10;
                        row1["11"] = consolidado.dia11;
                        row1["12"] = consolidado.dia12;
                        row1["13"] = consolidado.dia13;
                        row1["14"] = consolidado.dia14;
                        row1["15"] = consolidado.dia15;
                        row1["16"] = consolidado.dia16;
                        row1["17"] = consolidado.dia17;
                        row1["18"] = consolidado.dia18;
                        row1["19"] = consolidado.dia19;
                        row1["20"] = consolidado.dia20;
                        row1["21"] = consolidado.dia21;
                        row1["22"] = consolidado.dia22;
                        row1["23"] = consolidado.dia23;
                        row1["24"] = consolidado.dia24;
                        row1["25"] = consolidado.dia25;
                        row1["26"] = consolidado.dia26;
                        row1["27"] = consolidado.dia27;
                        row1["28"] = consolidado.dia28;
                    }
                    else if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(mes))
                    {
                        row1["1"] = consolidado.dia1;
                        row1["2"] = consolidado.dia2;
                        row1["3"] = consolidado.dia3;
                        row1["4"] = consolidado.dia4;
                        row1["5"] = consolidado.dia5;
                        row1["6"] = consolidado.dia6;
                        row1["7"] = consolidado.dia7;
                        row1["8"] = consolidado.dia8;
                        row1["9"] = consolidado.dia9;
                        row1["10"] = consolidado.dia10;
                        row1["11"] = consolidado.dia11;
                        row1["12"] = consolidado.dia12;
                        row1["13"] = consolidado.dia13;
                        row1["14"] = consolidado.dia14;
                        row1["15"] = consolidado.dia15;
                        row1["16"] = consolidado.dia16;
                        row1["17"] = consolidado.dia17;
                        row1["18"] = consolidado.dia18;
                        row1["19"] = consolidado.dia19;
                        row1["20"] = consolidado.dia20;
                        row1["21"] = consolidado.dia21;
                        row1["22"] = consolidado.dia22;
                        row1["23"] = consolidado.dia23;
                        row1["24"] = consolidado.dia24;
                        row1["25"] = consolidado.dia25;
                        row1["26"] = consolidado.dia26;
                        row1["27"] = consolidado.dia27;
                        row1["28"] = consolidado.dia28;
                        row1["29"] = consolidado.dia29;
                        row1["30"] = consolidado.dia30;
                        row1["31"] = consolidado.dia31;
                    }
                    else if (new[] { 4, 6, 9, 11 }.Contains(mes))
                    {
                        row1["1"] = consolidado.dia1;
                        row1["2"] = consolidado.dia2;
                        row1["3"] = consolidado.dia3;
                        row1["4"] = consolidado.dia4;
                        row1["5"] = consolidado.dia5;
                        row1["6"] = consolidado.dia6;
                        row1["7"] = consolidado.dia7;
                        row1["8"] = consolidado.dia8;
                        row1["9"] = consolidado.dia9;
                        row1["10"] = consolidado.dia10;
                        row1["11"] = consolidado.dia11;
                        row1["12"] = consolidado.dia12;
                        row1["13"] = consolidado.dia13;
                        row1["14"] = consolidado.dia14;
                        row1["15"] = consolidado.dia15;
                        row1["16"] = consolidado.dia16;
                        row1["17"] = consolidado.dia17;
                        row1["18"] = consolidado.dia18;
                        row1["19"] = consolidado.dia19;
                        row1["20"] = consolidado.dia20;
                        row1["21"] = consolidado.dia21;
                        row1["22"] = consolidado.dia22;
                        row1["23"] = consolidado.dia23;
                        row1["24"] = consolidado.dia24;
                        row1["25"] = consolidado.dia25;
                        row1["26"] = consolidado.dia26;
                        row1["27"] = consolidado.dia27;
                        row1["28"] = consolidado.dia28;
                        row1["29"] = consolidado.dia29;
                        row1["30"] = consolidado.dia30;
                    }
                    row1["Total"] = consolidado.total;

                    dt.Rows.Add(row1);
                }

                if (Util.verificaAno(ano))
                    {
                        if (new[] { 2 }.Contains(mes))
                        {

                            rowTotais["#"] = "TOTAL";
                            rowTotais["1"] = t1;
                            rowTotais["2"] = t2;
                            rowTotais["3"] = t3;
                            rowTotais["4"] = t4;
                            rowTotais["5"] = t5;
                            rowTotais["6"] = t6;
                            rowTotais["7"] = t7;
                            rowTotais["8"] = t8;
                            rowTotais["9"] = t9;
                            rowTotais["10"] = t10;
                            rowTotais["11"] = t11;
                            rowTotais["12"] = t12;
                            rowTotais["13"] = t13;
                            rowTotais["14"] = t14;
                            rowTotais["15"] = t15;
                            rowTotais["16"] = t16;
                            rowTotais["17"] = t17;
                            rowTotais["18"] = t18;
                            rowTotais["19"] = t19;
                            rowTotais["20"] = t20;
                            rowTotais["21"] = t21;
                            rowTotais["22"] = t22;
                            rowTotais["23"] = t23;
                            rowTotais["24"] = t24;
                            rowTotais["25"] = t25;
                            rowTotais["26"] = t26;
                            rowTotais["27"] = t27;
                            rowTotais["28"] = t28;
                            rowTotais["29"] = t29;
                            rowTotais["Total"] = ttotal;
                            dt.Rows.Add(rowTotais);
                        }
                    }
                    if (new[] { 2 }.Contains(mes))
                    {

                        rowTotais["#"] = "TOTAL";
                        rowTotais["1"] = t1;
                        rowTotais["2"] = t2;
                        rowTotais["3"] = t3;
                        rowTotais["4"] = t4;
                        rowTotais["5"] = t5;
                        rowTotais["6"] = t6;
                        rowTotais["7"] = t7;
                        rowTotais["8"] = t8;
                        rowTotais["9"] = t9;
                        rowTotais["10"] = t10;
                        rowTotais["11"] = t11;
                        rowTotais["12"] = t12;
                        rowTotais["13"] = t13;
                        rowTotais["14"] = t14;
                        rowTotais["15"] = t15;
                        rowTotais["16"] = t16;
                        rowTotais["17"] = t17;
                        rowTotais["18"] = t18;
                        rowTotais["19"] = t19;
                        rowTotais["20"] = t20;
                        rowTotais["21"] = t21;
                        rowTotais["22"] = t22;
                        rowTotais["23"] = t23;
                        rowTotais["24"] = t24;
                        rowTotais["25"] = t25;
                        rowTotais["26"] = t26;
                        rowTotais["27"] = t27;
                        rowTotais["28"] = t28;
                        rowTotais["Total"] = ttotal;
                        dt.Rows.Add(rowTotais);
                    }
                    else if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(mes))
                    {
                        rowTotais["#"] = "TOTAL";
                        rowTotais["1"] = t1;
                        rowTotais["2"] = t2;
                        rowTotais["3"] = t3;
                        rowTotais["4"] = t4;
                        rowTotais["5"] = t5;
                        rowTotais["6"] = t6;
                        rowTotais["7"] = t7;
                        rowTotais["8"] = t8;
                        rowTotais["9"] = t9;
                        rowTotais["10"] = t10;
                        rowTotais["11"] = t11;
                        rowTotais["12"] = t12;
                        rowTotais["13"] = t13;
                        rowTotais["14"] = t14;
                        rowTotais["15"] = t15;
                        rowTotais["16"] = t16;
                        rowTotais["17"] = t17;
                        rowTotais["18"] = t18;
                        rowTotais["19"] = t19;
                        rowTotais["20"] = t20;
                        rowTotais["21"] = t21;
                        rowTotais["22"] = t22;
                        rowTotais["23"] = t23;
                        rowTotais["24"] = t24;
                        rowTotais["25"] = t25;
                        rowTotais["26"] = t26;
                        rowTotais["27"] = t27;
                        rowTotais["28"] = t28;
                        rowTotais["29"] = t29;
                        rowTotais["30"] = t30;
                        rowTotais["31"] = t31;
                        rowTotais["Total"] = ttotal;
                        dt.Rows.Add(rowTotais);
                    }
                    else if (new[] { 4, 6, 9, 11 }.Contains(mes))
                    {
                        rowTotais["#"] = "TOTAL";
                        rowTotais["1"] = t1;
                        rowTotais["2"] = t2;
                        rowTotais["3"] = t3;
                        rowTotais["4"] = t4;
                        rowTotais["5"] = t5;
                        rowTotais["6"] = t6;
                        rowTotais["7"] = t7;
                        rowTotais["8"] = t8;
                        rowTotais["9"] = t9;
                        rowTotais["10"] = t10;
                        rowTotais["11"] = t11;
                        rowTotais["12"] = t12;
                        rowTotais["13"] = t13;
                        rowTotais["14"] = t14;
                        rowTotais["15"] = t15;
                        rowTotais["16"] = t16;
                        rowTotais["17"] = t17;
                        rowTotais["18"] = t18;
                        rowTotais["19"] = t19;
                        rowTotais["20"] = t20;
                        rowTotais["21"] = t21;
                        rowTotais["22"] = t22;
                        rowTotais["23"] = t23;
                        rowTotais["24"] = t24;
                        rowTotais["25"] = t25;
                        rowTotais["26"] = t26;
                        rowTotais["27"] = t27;
                        rowTotais["28"] = t28;
                        rowTotais["29"] = t29;
                        rowTotais["30"] = t30;
                        rowTotais["Total"] = ttotal;
                        dt.Rows.Add(rowTotais);
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return dt;
    }

    public static object GetListaBaixasPorProfissional(int mes, int ano)
    {
        string qyProfissional = "SELECT [nome_profissional] " +
                          ",[BE_MONTH] " +
                          ",[BE_YEAR] " +
                          ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14] ,[15],[16],[17] ,[18],[19],[20]" +
                          ",[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31],[TOTAL] " +
                      " FROM [Oncologia_Desenv].[dbo].[vw_baixa_por_profissional_mes_consolidado]" +
                      " WHERE BE_MONTH =" + mes + " AND BE_YEAR =" + ano;


        int t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0, t9 = 0,
                        t10 = 0, t11 = 0, t12 = 0, t13 = 0, t14 = 0, t15 = 0, t16 = 0, t17 = 0,
                        t18 = 0, t19 = 0, t20 = 0, t21 = 0, t22 = 0, t23 = 0, t24 = 0, t25 = 0,
                        t26 = 0, t27 = 0, t28 = 0, t29 = 0, t30 = 0, t31 = 0, ttotal = 0;
        DataTable dt = new DataTable();
        dt.Columns.Add("#", typeof(string));

        if (Util.verificaAno(ano))
        {
            if (new[] { 2 }.Contains(mes))
            {
                for (int i = 1; i <= 29; i++)
                {
                    dt.Columns.Add(i.ToString(), typeof(int));
                }
            }
        }

        if (new[] { 2 }.Contains(mes))
        {
            for (int i = 1; i <= 28; i++)
            {
                dt.Columns.Add(i.ToString(), typeof(int));
            }
        }
        else if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(mes))
        {
            for (int i = 1; i <= 31; i++)
            {
                dt.Columns.Add(i.ToString(), typeof(int));
            }
        }
        else if (new[] { 4, 6, 9, 11 }.Contains(mes))
        {
            for (int i = 1; i <= 30; i++)
            {
                dt.Columns.Add(i.ToString(), typeof(int));
            }
        }
        dt.Columns.Add("Total", typeof(int));


        var lista = new List<ConsolidadoMesTipo>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = qyProfissional;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                DataRow rowTotais = dt.NewRow();
                while (dr1.Read())
                {
                    DataRow row1 = dt.NewRow();

                    ConsolidadoMesTipo consolidado = new ConsolidadoMesTipo();

                  
                    consolidado.tipo = dr1.GetString(0);

                    consolidado.mes = dr1.GetInt32(1);
                    consolidado.ano = dr1.GetInt32(2);
                    consolidado.dia1 = dr1.GetInt32(3);
                    t1 += consolidado.dia1;
                    consolidado.dia2 = dr1.GetInt32(4);
                    t2 += consolidado.dia2;
                    consolidado.dia3 = dr1.GetInt32(5);
                    t3 += consolidado.dia3;
                    consolidado.dia4 = dr1.GetInt32(6);
                    t4 += consolidado.dia4;
                    consolidado.dia5 = dr1.GetInt32(7);
                    t5 += consolidado.dia5;
                    consolidado.dia6 = dr1.GetInt32(8);
                    t6 += consolidado.dia6;
                    consolidado.dia7 = dr1.GetInt32(9);
                    t7 += consolidado.dia7;
                    consolidado.dia8 = dr1.GetInt32(10);
                    t8 += consolidado.dia8;
                    consolidado.dia9 = dr1.GetInt32(11);
                    t9 += consolidado.dia9;
                    consolidado.dia10 = dr1.GetInt32(12);
                    t10 += consolidado.dia10;
                    consolidado.dia11 = dr1.GetInt32(13);
                    t11 += consolidado.dia11;
                    consolidado.dia12 = dr1.GetInt32(14);
                    t12 += consolidado.dia12;
                    consolidado.dia13 = dr1.GetInt32(15);
                    t13 += consolidado.dia13;
                    consolidado.dia14 = dr1.GetInt32(16);
                    t14 += consolidado.dia14;
                    consolidado.dia15 = dr1.GetInt32(17);
                    t15 += consolidado.dia15;
                    consolidado.dia16 = dr1.GetInt32(18);
                    t16 += consolidado.dia16;
                    consolidado.dia17 = dr1.GetInt32(19);
                    t17 += consolidado.dia17;
                    consolidado.dia18 = dr1.GetInt32(20);
                    t18 += consolidado.dia18;
                    consolidado.dia19 = dr1.GetInt32(21);
                    t19 += consolidado.dia19;
                    consolidado.dia20 = dr1.GetInt32(22);
                    t20 += consolidado.dia20;
                    consolidado.dia21 = dr1.GetInt32(23);
                    t21 += consolidado.dia21;
                    consolidado.dia22 = dr1.GetInt32(24);
                    t22 += consolidado.dia22;
                    consolidado.dia23 = dr1.GetInt32(25);
                    t23 += consolidado.dia23;
                    consolidado.dia24 = dr1.GetInt32(26);
                    t24 += consolidado.dia24;
                    consolidado.dia25 = dr1.GetInt32(27);
                    t25 += consolidado.dia25;
                    consolidado.dia26 = dr1.GetInt32(28);
                    t26 += consolidado.dia26;
                    consolidado.dia27 = dr1.GetInt32(29);
                    t27 += consolidado.dia27;
                    consolidado.dia28 = dr1.GetInt32(30);
                    t28 += consolidado.dia28;
                    consolidado.dia29 = dr1.GetInt32(31);
                    t29 += consolidado.dia29;
                    consolidado.dia30 = dr1.GetInt32(32);
                    t30 += consolidado.dia30;
                    consolidado.dia31 = dr1.GetInt32(33);
                    t31 += consolidado.dia31;
                    consolidado.total = dr1.GetInt32(34);
                    ttotal += consolidado.total;


                    row1["#"] = consolidado.tipo;

                    if (Util.verificaAno(ano))
                    {
                        if (new[] { 2 }.Contains(mes))
                        {

                            row1["1"] = consolidado.dia1;
                            row1["2"] = consolidado.dia2;
                            row1["3"] = consolidado.dia3;
                            row1["4"] = consolidado.dia4;
                            row1["5"] = consolidado.dia5;
                            row1["6"] = consolidado.dia6;
                            row1["7"] = consolidado.dia7;
                            row1["8"] = consolidado.dia8;
                            row1["9"] = consolidado.dia9;
                            row1["10"] = consolidado.dia10;
                            row1["11"] = consolidado.dia11;
                            row1["12"] = consolidado.dia12;
                            row1["13"] = consolidado.dia13;
                            row1["14"] = consolidado.dia14;
                            row1["15"] = consolidado.dia15;
                            row1["16"] = consolidado.dia16;
                            row1["17"] = consolidado.dia17;
                            row1["18"] = consolidado.dia18;
                            row1["19"] = consolidado.dia19;
                            row1["20"] = consolidado.dia20;
                            row1["21"] = consolidado.dia21;
                            row1["22"] = consolidado.dia22;
                            row1["23"] = consolidado.dia23;
                            row1["24"] = consolidado.dia24;
                            row1["25"] = consolidado.dia25;
                            row1["26"] = consolidado.dia26;
                            row1["27"] = consolidado.dia27;
                            row1["28"] = consolidado.dia28;
                            row1["29"] = consolidado.dia29;
                        }
                    }
                    if (new[] { 2 }.Contains(mes))
                    {

                        row1["1"] = consolidado.dia1;
                        row1["2"] = consolidado.dia2;
                        row1["3"] = consolidado.dia3;
                        row1["4"] = consolidado.dia4;
                        row1["5"] = consolidado.dia5;
                        row1["6"] = consolidado.dia6;
                        row1["7"] = consolidado.dia7;
                        row1["8"] = consolidado.dia8;
                        row1["9"] = consolidado.dia9;
                        row1["10"] = consolidado.dia10;
                        row1["11"] = consolidado.dia11;
                        row1["12"] = consolidado.dia12;
                        row1["13"] = consolidado.dia13;
                        row1["14"] = consolidado.dia14;
                        row1["15"] = consolidado.dia15;
                        row1["16"] = consolidado.dia16;
                        row1["17"] = consolidado.dia17;
                        row1["18"] = consolidado.dia18;
                        row1["19"] = consolidado.dia19;
                        row1["20"] = consolidado.dia20;
                        row1["21"] = consolidado.dia21;
                        row1["22"] = consolidado.dia22;
                        row1["23"] = consolidado.dia23;
                        row1["24"] = consolidado.dia24;
                        row1["25"] = consolidado.dia25;
                        row1["26"] = consolidado.dia26;
                        row1["27"] = consolidado.dia27;
                        row1["28"] = consolidado.dia28;
                    }
                    else if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(mes))
                    {
                        row1["1"] = consolidado.dia1;
                        row1["2"] = consolidado.dia2;
                        row1["3"] = consolidado.dia3;
                        row1["4"] = consolidado.dia4;
                        row1["5"] = consolidado.dia5;
                        row1["6"] = consolidado.dia6;
                        row1["7"] = consolidado.dia7;
                        row1["8"] = consolidado.dia8;
                        row1["9"] = consolidado.dia9;
                        row1["10"] = consolidado.dia10;
                        row1["11"] = consolidado.dia11;
                        row1["12"] = consolidado.dia12;
                        row1["13"] = consolidado.dia13;
                        row1["14"] = consolidado.dia14;
                        row1["15"] = consolidado.dia15;
                        row1["16"] = consolidado.dia16;
                        row1["17"] = consolidado.dia17;
                        row1["18"] = consolidado.dia18;
                        row1["19"] = consolidado.dia19;
                        row1["20"] = consolidado.dia20;
                        row1["21"] = consolidado.dia21;
                        row1["22"] = consolidado.dia22;
                        row1["23"] = consolidado.dia23;
                        row1["24"] = consolidado.dia24;
                        row1["25"] = consolidado.dia25;
                        row1["26"] = consolidado.dia26;
                        row1["27"] = consolidado.dia27;
                        row1["28"] = consolidado.dia28;
                        row1["29"] = consolidado.dia29;
                        row1["30"] = consolidado.dia30;
                        row1["31"] = consolidado.dia31;
                    }
                    else if (new[] { 4, 6, 9, 11 }.Contains(mes))
                    {
                        row1["1"] = consolidado.dia1;
                        row1["2"] = consolidado.dia2;
                        row1["3"] = consolidado.dia3;
                        row1["4"] = consolidado.dia4;
                        row1["5"] = consolidado.dia5;
                        row1["6"] = consolidado.dia6;
                        row1["7"] = consolidado.dia7;
                        row1["8"] = consolidado.dia8;
                        row1["9"] = consolidado.dia9;
                        row1["10"] = consolidado.dia10;
                        row1["11"] = consolidado.dia11;
                        row1["12"] = consolidado.dia12;
                        row1["13"] = consolidado.dia13;
                        row1["14"] = consolidado.dia14;
                        row1["15"] = consolidado.dia15;
                        row1["16"] = consolidado.dia16;
                        row1["17"] = consolidado.dia17;
                        row1["18"] = consolidado.dia18;
                        row1["19"] = consolidado.dia19;
                        row1["20"] = consolidado.dia20;
                        row1["21"] = consolidado.dia21;
                        row1["22"] = consolidado.dia22;
                        row1["23"] = consolidado.dia23;
                        row1["24"] = consolidado.dia24;
                        row1["25"] = consolidado.dia25;
                        row1["26"] = consolidado.dia26;
                        row1["27"] = consolidado.dia27;
                        row1["28"] = consolidado.dia28;
                        row1["29"] = consolidado.dia29;
                        row1["30"] = consolidado.dia30;
                    }
                    row1["Total"] = consolidado.total;

                    dt.Rows.Add(row1);
                }
                if (Util.verificaAno(ano))
                {
                    if (new[] { 2 }.Contains(mes))
                    {

                        rowTotais["#"] = "TOTAL";
                        rowTotais["1"] = t1;
                        rowTotais["2"] = t2;
                        rowTotais["3"] = t3;
                        rowTotais["4"] = t4;
                        rowTotais["5"] = t5;
                        rowTotais["6"] = t6;
                        rowTotais["7"] = t7;
                        rowTotais["8"] = t8;
                        rowTotais["9"] = t9;
                        rowTotais["10"] = t10;
                        rowTotais["11"] = t11;
                        rowTotais["12"] = t12;
                        rowTotais["13"] = t13;
                        rowTotais["14"] = t14;
                        rowTotais["15"] = t15;
                        rowTotais["16"] = t16;
                        rowTotais["17"] = t17;
                        rowTotais["18"] = t18;
                        rowTotais["19"] = t19;
                        rowTotais["20"] = t20;
                        rowTotais["21"] = t21;
                        rowTotais["22"] = t22;
                        rowTotais["23"] = t23;
                        rowTotais["24"] = t24;
                        rowTotais["25"] = t25;
                        rowTotais["26"] = t26;
                        rowTotais["27"] = t27;
                        rowTotais["28"] = t28;
                        rowTotais["29"] = t29;
                        rowTotais["Total"] = ttotal;
                        dt.Rows.Add(rowTotais);
                    }
                }
                if (new[] { 2 }.Contains(mes))
                {

                    rowTotais["#"] = "TOTAL";
                    rowTotais["1"] = t1;
                    rowTotais["2"] = t2;
                    rowTotais["3"] = t3;
                    rowTotais["4"] = t4;
                    rowTotais["5"] = t5;
                    rowTotais["6"] = t6;
                    rowTotais["7"] = t7;
                    rowTotais["8"] = t8;
                    rowTotais["9"] = t9;
                    rowTotais["10"] = t10;
                    rowTotais["11"] = t11;
                    rowTotais["12"] = t12;
                    rowTotais["13"] = t13;
                    rowTotais["14"] = t14;
                    rowTotais["15"] = t15;
                    rowTotais["16"] = t16;
                    rowTotais["17"] = t17;
                    rowTotais["18"] = t18;
                    rowTotais["19"] = t19;
                    rowTotais["20"] = t20;
                    rowTotais["21"] = t21;
                    rowTotais["22"] = t22;
                    rowTotais["23"] = t23;
                    rowTotais["24"] = t24;
                    rowTotais["25"] = t25;
                    rowTotais["26"] = t26;
                    rowTotais["27"] = t27;
                    rowTotais["28"] = t28;
                    rowTotais["Total"] = ttotal;
                    dt.Rows.Add(rowTotais);
                }
                else if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(mes))
                {
                    rowTotais["#"] = "TOTAL";
                    rowTotais["1"] = t1;
                    rowTotais["2"] = t2;
                    rowTotais["3"] = t3;
                    rowTotais["4"] = t4;
                    rowTotais["5"] = t5;
                    rowTotais["6"] = t6;
                    rowTotais["7"] = t7;
                    rowTotais["8"] = t8;
                    rowTotais["9"] = t9;
                    rowTotais["10"] = t10;
                    rowTotais["11"] = t11;
                    rowTotais["12"] = t12;
                    rowTotais["13"] = t13;
                    rowTotais["14"] = t14;
                    rowTotais["15"] = t15;
                    rowTotais["16"] = t16;
                    rowTotais["17"] = t17;
                    rowTotais["18"] = t18;
                    rowTotais["19"] = t19;
                    rowTotais["20"] = t20;
                    rowTotais["21"] = t21;
                    rowTotais["22"] = t22;
                    rowTotais["23"] = t23;
                    rowTotais["24"] = t24;
                    rowTotais["25"] = t25;
                    rowTotais["26"] = t26;
                    rowTotais["27"] = t27;
                    rowTotais["28"] = t28;
                    rowTotais["29"] = t29;
                    rowTotais["30"] = t30;
                    rowTotais["31"] = t31;
                    rowTotais["Total"] = ttotal;
                    dt.Rows.Add(rowTotais);
                }
                else if (new[] { 4, 6, 9, 11 }.Contains(mes))
                {
                    rowTotais["#"] = "TOTAL";
                    rowTotais["1"] = t1;
                    rowTotais["2"] = t2;
                    rowTotais["3"] = t3;
                    rowTotais["4"] = t4;
                    rowTotais["5"] = t5;
                    rowTotais["6"] = t6;
                    rowTotais["7"] = t7;
                    rowTotais["8"] = t8;
                    rowTotais["9"] = t9;
                    rowTotais["10"] = t10;
                    rowTotais["11"] = t11;
                    rowTotais["12"] = t12;
                    rowTotais["13"] = t13;
                    rowTotais["14"] = t14;
                    rowTotais["15"] = t15;
                    rowTotais["16"] = t16;
                    rowTotais["17"] = t17;
                    rowTotais["18"] = t18;
                    rowTotais["19"] = t19;
                    rowTotais["20"] = t20;
                    rowTotais["21"] = t21;
                    rowTotais["22"] = t22;
                    rowTotais["23"] = t23;
                    rowTotais["24"] = t24;
                    rowTotais["25"] = t25;
                    rowTotais["26"] = t26;
                    rowTotais["27"] = t27;
                    rowTotais["28"] = t28;
                    rowTotais["29"] = t29;
                    rowTotais["30"] = t30;
                    rowTotais["Total"] = ttotal;
                    dt.Rows.Add(rowTotais);
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return dt;
    }
}
