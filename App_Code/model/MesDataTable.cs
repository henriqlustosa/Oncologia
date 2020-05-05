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

/// <summary>
/// Summary description for MesDataTable
/// </summary>
public class MesDataTable
{
    public static DataRow LinhasTabela(string tipo, int ano, int mes
        , int dia1, int dia2, int dia3, int dia4, int dia5, int dia6, int dia7, int dia8
        , int dia9, int dia10, int dia11, int dia12, int dia13, int dia14, int dia15
        , int dia16, int dia17, int dia18, int dia19, int dia20, int dia21, int dia22
        , int dia23, int dia24, int dia25, int dia26, int dia27, int dia28, int dia29
        , int dia30, int dia31, int total)
    {
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

        DataRow row1 = dt.NewRow();

        try
        {
            row1["#"] = tipo;

            if (Util.verificaAno(ano))
            {
                if (new[] { 2 }.Contains(mes))
                {

                    row1["1"] = dia1;
                    row1["2"] = dia2;
                    row1["3"] = dia3;
                    row1["4"] = dia4;
                    row1["5"] = dia5;
                    row1["6"] = dia6;
                    row1["7"] = dia7;
                    row1["8"] = dia8;
                    row1["9"] = dia9;
                    row1["10"] = dia10;
                    row1["11"] = dia11;
                    row1["12"] = dia12;
                    row1["13"] = dia13;
                    row1["14"] = dia14;
                    row1["15"] = dia15;
                    row1["16"] = dia16;
                    row1["17"] = dia17;
                    row1["18"] = dia18;
                    row1["19"] = dia19;
                    row1["20"] = dia20;
                    row1["21"] = dia21;
                    row1["22"] = dia22;
                    row1["23"] = dia23;
                    row1["24"] = dia24;
                    row1["25"] = dia25;
                    row1["26"] = dia26;
                    row1["27"] = dia27;
                    row1["28"] = dia28;
                    row1["29"] = dia29;
                }
            }
            if (new[] { 2 }.Contains(mes))
            {

                row1["1"] = dia1;
                row1["2"] = dia2;
                row1["3"] = dia3;
                row1["4"] = dia4;
                row1["5"] = dia5;
                row1["6"] = dia6;
                row1["7"] = dia7;
                row1["8"] = dia8;
                row1["9"] = dia9;
                row1["10"] = dia10;
                row1["11"] = dia11;
                row1["12"] = dia12;
                row1["13"] = dia13;
                row1["14"] = dia14;
                row1["15"] = dia15;
                row1["16"] = dia16;
                row1["17"] = dia17;
                row1["18"] = dia18;
                row1["19"] = dia19;
                row1["20"] = dia20;
                row1["21"] = dia21;
                row1["22"] = dia22;
                row1["23"] = dia23;
                row1["24"] = dia24;
                row1["25"] = dia25;
                row1["26"] = dia26;
                row1["27"] = dia27;
                row1["28"] = dia28;
            }
            else if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(mes))
            {
                row1["1"] = dia1;
                row1["2"] = dia2;
                row1["3"] = dia3;
                row1["4"] = dia4;
                row1["5"] = dia5;
                row1["6"] = dia6;
                row1["7"] = dia7;
                row1["8"] = dia8;
                row1["9"] = dia9;
                row1["10"] = dia10;
                row1["11"] = dia11;
                row1["12"] = dia12;
                row1["13"] = dia13;
                row1["14"] = dia14;
                row1["15"] = dia15;
                row1["16"] = dia16;
                row1["17"] = dia17;
                row1["18"] = dia18;
                row1["19"] = dia19;
                row1["20"] = dia20;
                row1["21"] = dia21;
                row1["22"] = dia22;
                row1["23"] = dia23;
                row1["24"] = dia24;
                row1["25"] = dia25;
                row1["26"] = dia26;
                row1["27"] = dia27;
                row1["28"] = dia28;
                row1["29"] = dia29;
                row1["30"] = dia30;
                row1["31"] = dia31;
            }
            else if (new[] { 4, 6, 9, 11 }.Contains(mes))
            {
                row1["1"] = dia1;
                row1["2"] = dia2;
                row1["3"] = dia3;
                row1["4"] = dia4;
                row1["5"] = dia5;
                row1["6"] = dia6;
                row1["7"] = dia7;
                row1["8"] = dia8;
                row1["9"] = dia9;
                row1["10"] = dia10;
                row1["11"] = dia11;
                row1["12"] = dia12;
                row1["13"] = dia13;
                row1["14"] = dia14;
                row1["15"] = dia15;
                row1["16"] = dia16;
                row1["17"] = dia17;
                row1["18"] = dia18;
                row1["19"] = dia19;
                row1["20"] = dia20;
                row1["21"] = dia21;
                row1["22"] = dia22;
                row1["23"] = dia23;
                row1["24"] = dia24;
                row1["25"] = dia25;
                row1["26"] = dia26;
                row1["27"] = dia27;
                row1["28"] = dia28;
                row1["29"] = dia29;
                row1["30"] = dia30;
            }


            row1["Total"] = total;

            dt.Rows.Add(row1);
        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }

        return row1;
    }
}