using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Variáveis globais de configuração de acesso ao banco de dados.
/// </summary>
public class DbSettings
{
    public static string connectionString = "Data Source=.\\SQLExpress;Database=CLIENTEDB;Integrated Security=True;";
}