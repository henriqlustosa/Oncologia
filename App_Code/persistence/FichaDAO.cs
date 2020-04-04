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
using System.Data.SqlClient;

/// <summary>
/// Summary description for FichaDAO
/// </summary>
public class FichaDAO
{
	public FichaDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
      
    public static string GravaFicha(DateTime dt_rh_be, int prontuario, string documento, string tipo_paciente, string nome_paciente, DateTime dt_nascimento
        , int sexo, int raca, string endereco_rua, string numero_casa, string complemento, string bairro, string municipio, string uf
        , string cep, string nome_pai_mae, string responsavel, string telefone, string procedencia, string queixa, int setor)
    {
        string mensagem = "";

        int usuario = 1;

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();

            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;
            try
            {
                cmm.CommandText = "INSERT INTO [hspmPs].[dbo].[ficha] " +
                                               "(dt_hr_be " +
                                               ",setor " +
                                               ",nome_paciente " +
                                               ",dt_nascimento " +
                                               ",sexo " +
                                               ",raca " +
                                               ",endereco_rua " +
                                               ",numero_casa " +
                                               ",complemento " +
                                               ",bairro " +
                                               ",municipio " +
                                               ",uf " +
                                               ",cep " +
                                               ",nome_pai_mae " +
                                               ",responsavel " +
                                               ",telefone " +
                                               ",procedencia " +
                                               ",queixa " +
                    //",caso_policial " +
                    //",plano_saude " +
                    //",trauma " +
                    //",acidente_trabalho " +
                    //",veio_ambulancia " +
                                               ",tipo_paciente " +
                                               ",prontuario " +
                                               ",documento" +
                                                ", usuario) " +
                                         "VALUES (" +
                                               "@dt_hr_be" +
                                               ",@setor" +
                                               ",@nome_paciente" +
                                               ",@dt_nascimento" +
                                               ",@sexo" +
                                               ",@raca" +
                                               ",@endereco_rua" +
                                               ",@numero_casa" +
                                               ",@complemento" +
                                               ",@bairro" +
                                               ",@municipio" +
                                               ",@uf" +
                                               ",@cep" +
                                               ",@nome_pai_mae" +
                                               ",@responsavel" +
                                               ",@telefone" +
                                               ",@procedencia" +
                                               ",@queixa" +
                    //",@caso_policial"+
                    //",@plano_saude"+
                    //",@trauma"+
                    //",@acidente_trabalho"+
                    //",@veio_ambulancia"+
                                               ",@tipo_paciente" +
                                               ",@prontuario" +
                                               ",@documento" +
                                               ",@usuario);" +
                                               "SELECT SCOPE_IDENTITY()";

                cmm.Parameters.Add("@dt_hr_be", SqlDbType.DateTime).Value = DateTime.Now;
                cmm.Parameters.Add("@setor", SqlDbType.Int).Value = setor;
                cmm.Parameters.Add("@nome_paciente", SqlDbType.VarChar).Value = nome_paciente;
                cmm.Parameters.Add("@dt_nascimento", SqlDbType.DateTime).Value = dt_nascimento;
                cmm.Parameters.Add("@sexo", SqlDbType.Int).Value = sexo;
                cmm.Parameters.Add("@raca", SqlDbType.VarChar).Value = raca;
                cmm.Parameters.Add("@endereco_rua", SqlDbType.VarChar).Value = endereco_rua;
                cmm.Parameters.Add("@numero_casa", SqlDbType.VarChar).Value = numero_casa;
                cmm.Parameters.Add("@complemento", SqlDbType.VarChar).Value = complemento;
                cmm.Parameters.Add("@bairro", SqlDbType.VarChar).Value = bairro;
                cmm.Parameters.Add("@municipio", SqlDbType.VarChar).Value = municipio;
                cmm.Parameters.Add("@uf", SqlDbType.VarChar).Value = uf;
                cmm.Parameters.Add("@cep", SqlDbType.VarChar).Value = cep;
                cmm.Parameters.Add("@nome_pai_mae", SqlDbType.VarChar).Value = nome_pai_mae;


                cmm.Parameters.Add("@responsavel", SqlDbType.VarChar).Value = responsavel;
                cmm.Parameters.Add("@telefone", SqlDbType.VarChar).Value = telefone;
                cmm.Parameters.Add("@procedencia", SqlDbType.VarChar).Value = procedencia;
                cmm.Parameters.Add("@queixa", SqlDbType.VarChar).Value = queixa;
                //cmm.Parameters.Add("@caso_policial", SqlDbType.Int).Value = caso_policial;
                //cmm.Parameters.Add("@plano_saude", SqlDbType.VarChar).Value = plano_saude;
                //cmm.Parameters.Add("@trauma", SqlDbType.VarChar).Value = trauma;
                //cmm.Parameters.Add("@acidente_trabalho", SqlDbType.VarChar).Value = acidente_trabalho;
                //cmm.Parameters.Add("@veio_ambulancia", SqlDbType.VarChar).Value = veio_ambulancia;
                cmm.Parameters.Add("@tipo_paciente", SqlDbType.VarChar).Value = tipo_paciente;
                cmm.Parameters.Add("@prontuario", SqlDbType.Int).Value = prontuario;
                cmm.Parameters.Add("@documento", SqlDbType.VarChar).Value = documento;
                cmm.Parameters.Add("@usuario", SqlDbType.Int).Value = usuario;

                cmm.ExecuteNonQuery();
                // retorna o id cadastrado
                int id_ficha = Convert.ToInt32(cmm.ExecuteScalar());

                mt.Commit();
                mt.Dispose();
                cnn.Close();
                mensagem = "Ficha nº " + id_ficha +" cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                mensagem = error;
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                { }
            }
        }
        return mensagem;
    }

}
