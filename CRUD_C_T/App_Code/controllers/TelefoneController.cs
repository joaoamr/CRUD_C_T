using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descrição resumida de TelefoneController
/// </summary>
public class TelefoneController
{
    public TelefoneController()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }

    public bool Put(List<Telefone> telefones)
    {
        if (telefones.Count == 0)
            return true;

        string putTel = "";

        for (int i = 0; i < telefones.Count; i++)
        {
            Telefone t = telefones[i];
            putTel += "INSERT INTO Telefone (DDD, NUMERO, CPF) VALUES ('" + t.DDD + "','" + t.Numero + "','" + t.Cpf + "') ";
        }

       
        string connString = DbSettings.connectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        SqlCommand cmdCreate = new SqlCommand(putTel, conn);
        try { cmdCreate.ExecuteReader(); } catch (Exception e) { return false; };
        conn.Close();
        return true;
    }

    public string SearchNumber(string CPF)
    {
        string result = "";
        string connString = DbSettings.connectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string searchStr = "SELECT DDD, NUMERO FROM Telefone WHERE CPF = '" + CPF + "'";
        SqlCommand cmd = new SqlCommand(searchStr, conn);
        SqlDataReader data = cmd.ExecuteReader();
        while (data.Read())
        {
            result += "(" + data.GetString(0) + ")" + data.GetString(1) + " ";
        }

        data.Close();
        conn.Close();
        return result;
    }

    public List<String> SearchCpf(string number)
    {
        List<String> result = new List<string>();
        string connString = DbSettings.connectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string searchStr = "SELECT CPF FROM Telefone WHERE NUMERO LIKE '" + number + "'";
        SqlCommand cmd = new SqlCommand(searchStr, conn);
        SqlDataReader data = cmd.ExecuteReader();
        while (data.Read())
        {
            result.Add(data.GetString(0));
        }

        data.Close();
        conn.Close();
        return result;
    }

    //Deleta todos os registros de telefones do banco de dados para um dado CPF.
    public bool Delete(String cpf)
    {
        string connString = DbSettings.connectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string deleteTelefone = "DELETE FROM Telefone WHERE CPF = '" + cpf + "'";
        SqlCommand cmdCreate = new SqlCommand(deleteTelefone, conn);
        try { cmdCreate.ExecuteReader(); } catch (Exception e) { return false; };
        conn.Close();
        return true;
    }
}