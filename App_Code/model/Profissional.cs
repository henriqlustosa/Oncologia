using System;
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
    public int status_profissional { get; set; }

    public string UserId { get; set; }
}