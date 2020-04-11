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
using System.Collections.Generic;

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

    public List<Ficha> fichaLista = new List<Ficha>();

    public List<Ficha> GetFicha(int _cod_ficha)
    {
        
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [cod_ficha] " +
                                  ",[dt_hr_be]" +
                                  ",[setor]" +
                                  ",[nome_paciente]" +
                                  ",[dt_nascimento]" +
                                  ",[idade]" +
                                  ",[sexo]" +
                                  ",[raca]" +
                                  ",[endereco_rua]" +
                                  ",[numero_casa]" +
                                  ",[complemento]" +
                                  ",[bairro]" +
                                  ",[municipio]" +
                                  ",[uf]" +
                                  ",[cep]" +
                                  ",[nome_pai_mae]" +
                                  ",[responsavel]" +
                                  ",[telefone]" +
                                  ",[telefone1]" +
                                  ",[telefone2]" +
                                  ",[email]" +
                                  ",[procedencia]" +
                                  ", informacao_complementar " +
                                  ",[queixa]" +
                                  ",[tipo_paciente]" +
                                  ",[prontuario]" +
                                  ",[documento]" +
                                  ",[cns]" +
                                  ",[usuario] " +
                              "FROM [hspmPs].[dbo].[ficha] " +
                              "WHERE cod_ficha = " + _cod_ficha;
            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                if (dr1.Read())
                {

                    Ficha ficha = new Ficha();
                    ficha.cod_ficha = dr1.GetInt32(0);
                    ficha.dt_rh_be = dr1.GetDateTime(1);
                    ficha.setor = dr1.GetString(2);
                    ficha.nome_paciente = dr1.GetString(3);
                    ficha.dt_nascimento = dr1.GetDateTime(4);
                    ficha.idade = dr1.GetString(5);
                    ficha.sexo = dr1.GetString(6);
                    ficha.raca = dr1.GetString(7);
                    ficha.endereco_rua = dr1.GetString(8);
                    ficha.numero_casa = dr1.GetString(9);
                    ficha.complemento = dr1.GetString(10);
                    ficha.bairro = dr1.GetString(11);
                    ficha.municipio = dr1.GetString(12);
                    ficha.uf = dr1.GetString(13);
                    ficha.cep = dr1.GetString(14);
                    ficha.nome_pai_mae = dr1.GetString(15);
                    ficha.responsavel = dr1.GetString(16);
                    ficha.telefone = dr1.GetString(17);
                    ficha.telefone1 = dr1.GetString(18);
                    ficha.telefone2 = dr1.GetString(19);
                    ficha.email = dr1.GetString(20);
                    ficha.procedencia = dr1.GetString(21);
                    ficha.informacao_complementar = dr1.GetString(22);
                    ficha.queixa = dr1.GetString(23);
                    if (dr1.GetString(24) == "F")
                    {
                        ficha.tipo_paciente = "FUNCIONÁRIO";
                    }
                    if (dr1.GetString(24) == "M")
                    {
                        ficha.tipo_paciente = "MUNÍCIPE";
                    }
                    ficha.prontuario = dr1.GetInt32(25);
                    ficha.documento = dr1.GetString(26);
                    ficha.cns = dr1.GetString(27);
                    ficha.usuario = dr1.GetString(28);

                    fichaLista.Add(ficha);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return fichaLista;
    }



    public static int GravaFicha(DateTime dt_rh_be, int prontuario, string documento, string cns, string tipo_paciente, string nome_paciente, DateTime dt_nascimento, string idade
        , string sexo, string raca, string endereco_rua, string numero_casa, string complemento, string bairro, string municipio, string uf
        , string cep, string nome_pai_mae, string responsavel, string telefone, string telefone1, string telefone2, string email, string procedencia, string informacao_complementar, string queixa, string setor, string usuario)
    {
        int _cod_ficha = 0;

        int _status_ficha = 0; //se status for 0 ficha cadastrada - 1 ficha baixa

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
                                               ", setor " +
                                               ", nome_paciente " +
                                               ", dt_nascimento " +
                                               ", idade " +
                                               ", sexo " +
                                               ", raca " +
                                               ", endereco_rua " +
                                               ", numero_casa " +
                                               ", complemento " +
                                               ", bairro " +
                                               ", municipio " +
                                               ", uf " +
                                               ", cep " +
                                               ", nome_pai_mae " +
                                               ", responsavel " +
                                               ", telefone " +
                                               ", telefone1 " +
                                               ", telefone2 " +
                                               ", email " +
                                               ", procedencia " +
                                               ", informacao_complementar " +
                                               ", queixa " +
                                               ", tipo_paciente " +
                                               ", prontuario " +
                                               ", documento " +
                                               ", cns " +
                                               ", status_ficha " +
                                               ", usuario) " +
                                         "VALUES (" +
                                               "@dt_hr_be" +
                                               ",@setor" +
                                               ",@nome_paciente" +
                                               ",@dt_nascimento" +
                                               ",@idade" +
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
                                               ",@telefone1" +
                                               ",@telefone2" +
                                               ",@email" +
                                               ",@procedencia" +
                                               ",@informacao_complementar " +
                                               ",@queixa" +
                                               ",@tipo_paciente" +
                                               ",@prontuario" +
                                               ",@documento" +
                                               ",@cns" +
                                               ",@status_ficha" +
                                               ",@usuario);" +
                                               "SELECT SCOPE_IDENTITY()";

                cmm.Parameters.Add("@dt_hr_be", SqlDbType.DateTime).Value = DateTime.Now;
                cmm.Parameters.Add("@setor", SqlDbType.VarChar).Value = setor;
                cmm.Parameters.Add("@nome_paciente", SqlDbType.VarChar).Value = nome_paciente;
                cmm.Parameters.Add("@dt_nascimento", SqlDbType.DateTime).Value = dt_nascimento;
                cmm.Parameters.Add("@idade", SqlDbType.VarChar).Value = idade;
                cmm.Parameters.Add("@sexo", SqlDbType.VarChar).Value = sexo;
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
                cmm.Parameters.Add("@telefone1", SqlDbType.VarChar).Value = telefone1;
                cmm.Parameters.Add("@telefone2", SqlDbType.VarChar).Value = telefone2;
                cmm.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmm.Parameters.Add("@procedencia", SqlDbType.VarChar).Value = procedencia;
                cmm.Parameters.Add("@informacao_complementar", SqlDbType.VarChar).Value = informacao_complementar;
                cmm.Parameters.Add("@queixa", SqlDbType.VarChar).Value = queixa;
                cmm.Parameters.Add("@tipo_paciente", SqlDbType.VarChar).Value = tipo_paciente;
                cmm.Parameters.Add("@prontuario", SqlDbType.Int).Value = prontuario;
                cmm.Parameters.Add("@documento", SqlDbType.VarChar).Value = documento;
                cmm.Parameters.Add("@cns", SqlDbType.VarChar).Value = cns;
                cmm.Parameters.Add("@status_ficha", SqlDbType.Int).Value = _status_ficha;
                cmm.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                //cmm.ExecuteNonQuery();
                // retorna o id cadastrado
                int id_ficha = Convert.ToInt32(cmm.ExecuteScalar());
                
                mt.Commit();
                mt.Dispose();
                cnn.Close();
                _cod_ficha = id_ficha;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                { }
            }
        }
        return _cod_ficha;
    }

    public static List<Ficha> GetBE(int _nr_be)
    {
        var lista = new List<Ficha>();

        
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [cod_ficha] " +
                                  ",[dt_hr_be]" +
                                  ",[setor]" +
                                  ",[nome_paciente]" +
                                  ",[dt_nascimento]" +
                                  ",[idade]" +
                                  ",[sexo]" +
                                  ",[raca]" +
                                  ",[endereco_rua]" +
                                  ",[numero_casa]" +
                                  ",[complemento]" +
                                  ",[bairro]" +
                                  ",[municipio]" +
                                  ",[uf]" +
                                  ",[cep]" +
                                  ",[nome_pai_mae]" +
                                  ",[responsavel]" +
                                  ",[telefone]" +
                                  ",[telefone1]" +
                                  ",[telefone2]" +
                                  ",[email]" +
                                  ",[procedencia]" +
                                  ",[informacao_complementar]" +
                                  ",[queixa]" +
                                  ",[tipo_paciente]" +
                                  ",[prontuario]" +
                                  ",[documento]" +
                                  ",[cns]" +
                                  ",[usuario] " +
                              "FROM [hspmPs].[dbo].[ficha] " +
                              "WHERE cod_ficha = " + _nr_be;
            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                if (dr1.Read())
                {
                    Ficha ficha = new Ficha();
                    ficha.cod_ficha = dr1.GetInt32(0);
                    ficha.dt_rh_be = dr1.GetDateTime(1);
                    ficha.setor = dr1.GetString(2);
                    ficha.nome_paciente = dr1.GetString(3);
                    ficha.dt_nascimento = dr1.GetDateTime(4);
                    ficha.idade = dr1.GetString(5);
                    ficha.sexo = dr1.GetString(6);
                    ficha.raca = dr1.GetString(7);
                    ficha.endereco_rua = dr1.GetString(8);
                    ficha.numero_casa = dr1.GetString(9);
                    ficha.complemento = dr1.GetString(10);
                    ficha.bairro = dr1.GetString(11);
                    ficha.municipio = dr1.GetString(12);
                    ficha.uf = dr1.GetString(13);
                    ficha.cep = dr1.GetString(14);
                    ficha.nome_pai_mae = dr1.GetString(15);
                    ficha.responsavel = dr1.GetString(16);
                    ficha.telefone = dr1.GetString(17);
                    ficha.telefone1 = dr1.GetString(18);
                    ficha.telefone2 = dr1.GetString(19);
                    ficha.email = dr1.GetString(20);
                    ficha.procedencia = dr1.GetString(21);
                    ficha.informacao_complementar = dr1.GetString(22);
                    ficha.queixa = dr1.GetString(23);
                    if (dr1.GetString(24) == "F")
                    {
                        ficha.tipo_paciente = "FUNCIONÁRIO";
                    }
                    if (dr1.GetString(24) == "M")
                    {
                        ficha.tipo_paciente = "MUNÍCIPE";
                    }
                    ficha.prontuario = dr1.GetInt32(25);
                    ficha.documento = dr1.GetString(26);
                    ficha.cns = dr1.GetString(27);
                    ficha.usuario = dr1.GetString(28);
                    lista.Add(ficha);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;
    }

    public static Ficha GetDadosBE(int _nr_be)
    {
        Ficha ficha = new Ficha();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [cod_ficha] " +
                                  ",[dt_hr_be]" +
                                  ",[setor]" +
                                  ",[nome_paciente]" +
                                  ",[dt_nascimento]" +
                                  ",[idade]" +
                                  ",[sexo]" +
                                  ",[raca]" +
                                  ",[endereco_rua]" +
                                  ",[numero_casa]" +
                                  ",[complemento]" +
                                  ",[bairro]" +
                                  ",[municipio]" +
                                  ",[uf]" +
                                  ",[cep]" +
                                  ",[nome_pai_mae]" +
                                  ",[responsavel]" +
                                  ",[telefone]" +
                                  ",[telefone1]" +
                                  ",[telefone2]" +
                                  ",[email]" +
                                  ",[procedencia]" +
                                  ",[informacao_complementar]" +
                                  ",[queixa]" +
                                  ",[tipo_paciente]" +
                                  ",[prontuario]" +
                                  ",[documento]" +
                                  ",[cns]" +
                                  ",[usuario] " +
                                  ",[status_ficha]" +
                              "FROM [hspmPs].[dbo].[ficha] " +
                              "WHERE cod_ficha = " + _nr_be;
            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                if (dr1.Read())
                {
                    
                    ficha.cod_ficha = dr1.GetInt32(0);
                    ficha.dt_rh_be = dr1.GetDateTime(1);
                    ficha.setor = dr1.GetString(2);
                    ficha.nome_paciente = dr1.GetString(3);
                    ficha.dt_nascimento = dr1.GetDateTime(4);
                    ficha.idade = dr1.GetString(5);
                    ficha.sexo = dr1.GetString(6);
                    ficha.raca = dr1.GetString(7);
                    ficha.endereco_rua = dr1.GetString(8);
                    ficha.numero_casa = dr1.GetString(9);
                    ficha.complemento = dr1.GetString(10);
                    ficha.bairro = dr1.GetString(11);
                    ficha.municipio = dr1.GetString(12);
                    ficha.uf = dr1.GetString(13);
                    ficha.cep = dr1.GetString(14);
                    ficha.nome_pai_mae = dr1.GetString(15);
                    ficha.responsavel = dr1.GetString(16);
                    ficha.telefone = dr1.GetString(17);
                    ficha.telefone1 = dr1.GetString(18);
                    ficha.telefone2 = dr1.GetString(19);
                    ficha.email = dr1.GetString(20);
                    ficha.procedencia = dr1.GetString(21);
                    ficha.informacao_complementar = dr1.GetString(22);
                    ficha.queixa = dr1.GetString(23);
                    if (dr1.GetString(24) == "F")
                    {
                        ficha.tipo_paciente = "FUNCIONÁRIO";
                    }
                    if (dr1.GetString(24) == "M")
                    {
                        ficha.tipo_paciente = "MUNÍCIPE";
                    }
                    ficha.prontuario = dr1.GetInt32(25);
                    ficha.documento = dr1.GetString(26);
                    ficha.cns = dr1.GetString(27);
                    ficha.usuario = dr1.GetString(28);
                    //ficha.cns = "0";
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return ficha;
    }


    public static List<Ficha> GetListaFicha(string _nome)
    {
        List<Ficha> listagem = new List<Ficha>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [cod_ficha] " +
                                  ",[dt_hr_be]" +
                                  ",[setor]" +
                                  ",[nome_paciente]" +
                                  ",[dt_nascimento]" +
                                  ",[idade]" +
                                  ",[sexo]" +
                                  ",[raca]" +
                                  ",[endereco_rua]" +
                                  ",[numero_casa]" +
                                  ",[complemento]" +
                                  ",[bairro]" +
                                  ",[municipio]" +
                                  ",[uf]" +
                                  ",[cep]" +
                                  ",[nome_pai_mae]" +
                                  ",[responsavel]" +
                                  ",[telefone]" +
                                  ",[telefone1]" +
                                  ",[telefone2]" +
                                  ",[email]" +
                                  ",[procedencia]" +
                                  ",[informacao_complementar]" +
                                  ",[queixa]" +
                                  ",[tipo_paciente]" +
                                  ",[prontuario]" +
                                  ",[documento]" +
                                  ",[cns]" +
                                  ",[usuario] " +
                              "FROM [hspmPs].[dbo].[ficha] " +
                              "WHERE nome_paciente LIKE '%" + _nome + "%'";
            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {

                    Ficha ficha = new Ficha();
                    ficha.cod_ficha = dr1.GetInt32(0);
                    ficha.dt_rh_be = dr1.GetDateTime(1);
                    ficha.setor = dr1.GetString(2);
                    ficha.nome_paciente = dr1.GetString(3);
                    ficha.dt_nascimento = dr1.GetDateTime(4);
                    ficha.idade = dr1.GetString(5);
                    ficha.sexo = dr1.GetString(6);
                    ficha.raca = dr1.GetString(7);
                    ficha.endereco_rua = dr1.GetString(8);
                    ficha.numero_casa = dr1.GetString(9);
                    ficha.complemento = dr1.GetString(10);
                    ficha.bairro = dr1.GetString(11);
                    ficha.municipio = dr1.GetString(12);
                    ficha.uf = dr1.GetString(13);
                    ficha.cep = dr1.GetString(14);
                    ficha.nome_pai_mae = dr1.GetString(15);
                    ficha.responsavel = dr1.GetString(16);
                    ficha.telefone = dr1.GetString(17);
                    ficha.telefone1 = dr1.GetString(18);
                    ficha.telefone2 = dr1.GetString(19);
                    ficha.email = dr1.GetString(20);
                    ficha.procedencia = dr1.GetString(21);
                    ficha.informacao_complementar = dr1.GetString(22);
                    ficha.queixa = dr1.GetString(23);
                    if (dr1.GetString(24) == "F")
                    {
                        ficha.tipo_paciente = "FUNCIONÁRIO";
                    }
                    if (dr1.GetString(24) == "M")
                    {
                        ficha.tipo_paciente = "MUNÍCIPE";
                    }
                    ficha.prontuario = dr1.GetInt32(25);
                    ficha.documento = dr1.GetString(26);
                    ficha.cns = dr1.GetString(27);
                    ficha.usuario = dr1.GetString(28);

                    listagem.Add(ficha);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return listagem;
    }
}