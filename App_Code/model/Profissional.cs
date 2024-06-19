﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Profissional
/// </summary>
public class Profissional : Conselho
{

    public Profissional()
    { 
        //
        // TODO: Add constructor logic here
        //
    }
    public int cod_profissional { get; set; }
    public string nome_profissional { get; set; }
    public int conselho { get; set; }
    public int nr_conselho { get; set; }
    public string status_profissional { get; set; }

    public string UserId { get; set; }
    public DateTime data_cadastro { get; set; }
   
    public string nome_usuario { get; set; }
    public DateTime data_atualizacao { get; set; }
    public string nome_usuario_atualizacao { get; set; }
}