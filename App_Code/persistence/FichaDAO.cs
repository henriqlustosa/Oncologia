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
                                  ",[info_resgate] " +
                                  ",[rf] " +
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
                    ficha.info_resgate = dr1.GetString(29);
                    ficha.rf = dr1.GetString(30);
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



    public static int GravaFicha(DateTime _dt_rh_be, int _prontuario, string _documento, string _cns, string _tipo_paciente, string _nome_paciente
        , DateTime _dt_nascimento, string _idade, string _sexo, string _raca, string _endereco_rua, string _numero_casa, string _complemento
        , string _bairro, string _municipio, string _uf, string _cep, string _nome_pai_mae, string _responsavel, string _telefone, string _telefone1
        , string _telefone2, string _email, string _procedencia, string _informacao_complementar, string _queixa, string _setor, string _usuario
        , string _info_resgate, string _rf)
    {
        int _cod_ficha = 0;
        int _status_ficha = 0; //se status for 0 ficha cadastrada - 1 ficha baixa

        Ficha f = new Ficha();
        f.dt_rh_be = _dt_rh_be;
        f.prontuario = _prontuario;
        f.documento = _documento;
        f.cns = _cns;
        f.tipo_paciente = _tipo_paciente;
        f.nome_paciente = _nome_paciente;
        f.dt_nascimento = _dt_nascimento;
        f.idade = _idade;
        f.sexo = _sexo;
        f.raca = _raca;
        f.endereco_rua = _endereco_rua;
        f.numero_casa = _numero_casa;
        f.complemento = _complemento;
        f.bairro = _bairro;
        f.municipio = _municipio;
        f.uf = _uf;
        f.cep = _cep;
        f.nome_pai_mae = _nome_pai_mae;
        f.responsavel = _responsavel;
        f.telefone = _telefone;
        f.telefone1 = _telefone1;
        f.telefone2 = _telefone2;
        f.email = _email;
        f.procedencia = _procedencia;
        f.informacao_complementar = _informacao_complementar;
        f.queixa = _queixa;
        f.setor = _setor;
        f.usuario = _usuario;
        f.info_resgate = _info_resgate;
        f.rf = _rf;

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            
            SqlCommand cmm = cnn.CreateCommand();
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
                                               ", usuario " +
                                               ", info_resgate" +
                                               ", rf)" +
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
                                               ",@usuario" +
                                               ",@info_resgate" +
                                               ",@rf);" +
                                               "SELECT SCOPE_IDENTITY();";

            cmm.Parameters.Add("@dt_hr_be", SqlDbType.DateTime).Value = f.dt_rh_be;
            cmm.Parameters.Add("@setor", SqlDbType.VarChar).Value = f.setor;
            cmm.Parameters.Add("@nome_paciente", SqlDbType.VarChar).Value = f.nome_paciente.ToUpper();
            cmm.Parameters.Add("@dt_nascimento", SqlDbType.DateTime).Value = f.dt_nascimento;
            cmm.Parameters.Add("@idade", SqlDbType.VarChar).Value = f.idade;
            cmm.Parameters.Add("@sexo", SqlDbType.VarChar).Value = f.sexo;
            cmm.Parameters.Add("@raca", SqlDbType.VarChar).Value = f.raca;
            cmm.Parameters.Add("@endereco_rua", SqlDbType.VarChar).Value = f.endereco_rua.ToUpper();
            cmm.Parameters.Add("@numero_casa", SqlDbType.VarChar).Value = f.numero_casa;
            cmm.Parameters.Add("@complemento", SqlDbType.VarChar).Value = f.complemento.ToUpper();
            cmm.Parameters.Add("@bairro", SqlDbType.VarChar).Value = f.bairro.ToUpper();
            cmm.Parameters.Add("@municipio", SqlDbType.VarChar).Value = f.municipio.ToUpper();
            cmm.Parameters.Add("@uf", SqlDbType.VarChar).Value = f.uf.ToUpper();
            cmm.Parameters.Add("@cep", SqlDbType.VarChar).Value = f.cep;
            cmm.Parameters.Add("@nome_pai_mae", SqlDbType.VarChar).Value = f.nome_pai_mae.ToUpper();
            cmm.Parameters.Add("@responsavel", SqlDbType.VarChar).Value = f.responsavel.ToUpper();
            cmm.Parameters.Add("@telefone", SqlDbType.VarChar).Value = f.telefone;
            cmm.Parameters.Add("@telefone1", SqlDbType.VarChar).Value = f.telefone1;
            cmm.Parameters.Add("@telefone2", SqlDbType.VarChar).Value = f.telefone2;
            cmm.Parameters.Add("@email", SqlDbType.VarChar).Value = f.email;
            cmm.Parameters.Add("@procedencia", SqlDbType.VarChar).Value = f.procedencia.ToUpper();
            cmm.Parameters.Add("@informacao_complementar", SqlDbType.VarChar).Value = f.informacao_complementar;
            cmm.Parameters.Add("@queixa", SqlDbType.VarChar).Value = f.queixa.ToUpper();
            cmm.Parameters.Add("@tipo_paciente", SqlDbType.VarChar).Value = f.tipo_paciente;
            cmm.Parameters.Add("@prontuario", SqlDbType.Int).Value = f.prontuario;
            cmm.Parameters.Add("@documento", SqlDbType.VarChar).Value = f.documento;
            cmm.Parameters.Add("@cns", SqlDbType.VarChar).Value = f.cns;
            cmm.Parameters.Add("@status_ficha", SqlDbType.Int).Value = _status_ficha;
            cmm.Parameters.Add("@usuario", SqlDbType.VarChar).Value = f.usuario.ToUpper();
            cmm.Parameters.Add("@info_resgate", SqlDbType.VarChar).Value = f.info_resgate;
            cmm.Parameters.Add("@rf", SqlDbType.VarChar).Value = f.rf;
            
            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;
            try
            {
                // retorna o id cadastrado
                int id_ficha = Convert.ToInt32(cmm.ExecuteScalar());
                _cod_ficha = id_ficha;
                mt.Commit();
                mt.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                Console.WriteLine("  Message: {0}", ex.Message);

                // Attempt to roll back the transaction. 
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex2)
                {
                    // This catch block will handle any errors that may have occurred 
                    // on the server that would cause the rollback to fail, such as 
                    // a closed connection.
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    Console.WriteLine("  Message: {0}", ex2.Message);
                }
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
                                  ",[info_resgate]" +
                                  ",[rf] " +
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
                    ficha.info_resgate = dr1.GetString(29);
                    ficha.rf = dr1.GetString(30);
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
                                  ",[info_resgate]" +
                                  ",[rf] " +
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
                    ficha.status_ficha = dr1.GetInt32(29);
                    ficha.info_resgate = dr1.GetString(30);
                    ficha.rf = dr1.GetString(31);
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
                                  ",[info_resgate] " +
                                  ",[rf] " +
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
                    ficha.info_resgate = dr1.GetString(29);
                    ficha.rf = dr1.GetString(30);
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

    public static string AtualizarFicha(int num_be, string documento, string cns, string tipo_paciente, string nome_paciente, DateTime dt_nascimento, string idade
        , string sexo, string raca, string endereco_rua, string numero_casa, string complemento, string bairro, string municipio, string uf
        , string cep, string nome_pai_mae, string responsavel, string telefone, string telefone1, string telefone2, string email, string procedencia, string rf)
    {

        string mensagem = "";

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();

            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;
            try
            {
                cmm.CommandText = "UPDATE [hspmPs].[dbo].[ficha]" +
                                            "SET " +
                                               " nome_paciente = @nome_paciente " +
                                               ", dt_nascimento = @dt_nascimento " +
                                               ", idade = @idade" +
                                               ", sexo = @sexo " +
                                               ", raca = @raca" +
                                               ", endereco_rua = @endereco_rua" +
                                               ", numero_casa = @numero_casa" +
                                               ", complemento = @complemento" +
                                               ", bairro = @bairro" +
                                               ", municipio = @municipio" +
                                               ", uf = @uf" +
                                               ", cep = @cep" +
                                               ", nome_pai_mae = @nome_pai_mae" +
                                               ", responsavel = @responsavel" +
                                               ", telefone = @telefone" +
                                               ", telefone1 = @telefone1" +
                                               ", telefone2 = @telefone2" +
                                               ", email = @email" +
                                               ", procedencia = @procedencia" +
                                               ", tipo_paciente = @tipo_paciente " +
                                               ", documento = @documento" +
                                               ", cns = @cns" +
                                               ", rf = @rf" +
                                                " WHERE  cod_ficha = @cod_ficha";
                cmm.Parameters.Add(new SqlParameter("@cod_ficha", num_be));
                cmm.Parameters.Add(new SqlParameter("@nome_paciente", nome_paciente.ToUpper()));
                cmm.Parameters.Add(new SqlParameter("@dt_nascimento", dt_nascimento));
                cmm.Parameters.Add(new SqlParameter("@idade", idade));
                cmm.Parameters.Add(new SqlParameter("@sexo", sexo));
                cmm.Parameters.Add(new SqlParameter("@raca", raca));
                cmm.Parameters.Add(new SqlParameter("@endereco_rua", endereco_rua.ToUpper()));
                cmm.Parameters.Add(new SqlParameter("@numero_casa", numero_casa));
                cmm.Parameters.Add(new SqlParameter("@complemento", complemento.ToUpper()));
                cmm.Parameters.Add(new SqlParameter("@bairro", bairro.ToUpper()));
                cmm.Parameters.Add(new SqlParameter("@municipio", municipio.ToUpper()));
                cmm.Parameters.Add(new SqlParameter("@uf", uf.ToUpper()));
                cmm.Parameters.Add(new SqlParameter("@cep", cep));
                cmm.Parameters.Add(new SqlParameter("@nome_pai_mae", nome_pai_mae.ToUpper()));
                cmm.Parameters.Add(new SqlParameter("@responsavel", responsavel.ToUpper()));
                cmm.Parameters.Add(new SqlParameter("@telefone", telefone));
                cmm.Parameters.Add(new SqlParameter("@telefone1", telefone1));
                cmm.Parameters.Add(new SqlParameter("@telefone2", telefone2));
                cmm.Parameters.Add(new SqlParameter("@email", email.ToUpper()));
                cmm.Parameters.Add(new SqlParameter("@procedencia", procedencia));
                cmm.Parameters.Add(new SqlParameter("@tipo_paciente", tipo_paciente));
                cmm.Parameters.Add(new SqlParameter("@documento", documento));
                cmm.Parameters.Add(new SqlParameter("@cns", cns));
                cmm.Parameters.Add(new SqlParameter("@rf", rf));

                cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();
                cnn.Close();
                mensagem = "Atualização de cadastro realizado com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
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