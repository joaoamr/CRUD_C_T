using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

public class ClienteController : ApiController
{
    // GET api/<controller>
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<controller>/5
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<controller>
    public void Post([FromBody]string value)
    {
    }

    // PUT api/<controller>/5
    public bool Put(Cliente c)
    {
        string connString = DbSettings.connectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string putCliente = "INSERT INTO Cliente (CPF, NOME, DATANASCIMENTO, GENERO) VALUES ('" + c.Cpf + "','" + c.Nome + "','" + c.Datanascimento + "','" + c.Genero + "')";
        SqlCommand cmdCreate = new SqlCommand(putCliente, conn);
        try { cmdCreate.ExecuteReader(); } catch (Exception e) { return false; };
        conn.Close();
        return true;
    }


    public Cliente SearchForCPF(string cpf)
    {
        Cliente result = null;

        string connString = DbSettings.connectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string searchStr = "SELECT * FROM Cliente WHERE CPF = '" + cpf + "'";
        SqlCommand cmd = new SqlCommand(searchStr, conn);
        SqlDataReader data = cmd.ExecuteReader();
        if (data.Read())
        {
            string d = data.GetValue(2).ToString();
            string datanascimento = d[0].ToString() + d[1].ToString() + d[2].ToString() + d[3].ToString() + d[4].ToString() + d[5].ToString() + d[6].ToString() + d[7].ToString() + d[8].ToString() + d[9].ToString();
            result = new Cliente(data.GetString(1), data.GetString(0), data.GetString(3)[0], datanascimento);
        }
        data.Close();
        conn.Close();
        return result;
    }

    public List<Cliente> LoadAll()
    {
        List<Cliente> result = new List<Cliente>();

        string connString = DbSettings.connectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string searchStr = "SELECT * FROM Cliente";
        searchStr += " ORDER BY NOME ASC";
        SqlCommand cmd = new SqlCommand(searchStr, conn);
        SqlDataReader data = cmd.ExecuteReader();
        while (data.Read())
        {
            string d = data.GetValue(2).ToString();
            string datanascimento = d[0].ToString() + d[1].ToString() + d[2].ToString() + d[3].ToString() + d[4].ToString() + d[5].ToString() + d[6].ToString() + d[7].ToString() + d[8].ToString() + d[9].ToString();
            result.Add(new Cliente(data.GetString(1), data.GetString(0), data.GetString(3)[0], datanascimento));
        }
        data.Close();
        conn.Close();
        return result;
    }

    //Deleta registros de clientes do banco de dados, inclusive de tabelas relacionadas.
    public bool Delete (String cpf)
    {
        string connString = DbSettings.connectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string deleteTelefone = "DELETE FROM Telefone WHERE CPF = '" + cpf + "'";
        string deleteCliente = "DELETE FROM Cliente WHERE CPF = '" + cpf + "'";
        SqlCommand cmdCreate = new SqlCommand(deleteTelefone + deleteCliente, conn);
        try { cmdCreate.ExecuteReader(); } catch (Exception e) { return false; };
        conn.Close();
        return true;
    }

    //Retorna o número de linhas da tabela Cliente.
    public int Rows()
    {
        string connString = DbSettings.connectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string searchStr = "SELECT CPF FROM Cliente";
        SqlCommand cmd = new SqlCommand(searchStr, conn);
        SqlDataReader data = cmd.ExecuteReader();
        int rows = 0;
        while (data.Read())
            rows++;

        data.Close();
        conn.Close();

        return rows;

    }

    //Atualiza registro
    public bool Update(string cpf, Cliente c)
    {
        string connString = DbSettings.connectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string updatestr = "UPDATE Cliente SET CPF ='"+c.Cpf+"', NOME = '"+c.Nome+ "', DATANASCIMENTO ='"+c.Datanascimento+"', GENERO ='"+c.Genero+"' WHERE CPF = '" + cpf + "'";
        SqlCommand cmdCreate = new SqlCommand(updatestr, conn);
        //try { cmdCreate.ExecuteReader(); } catch (Exception e) { return false; };
        cmdCreate.ExecuteReader();
        conn.Close();
        return true;
    }

    //Busca clientes por nome
    public List<Cliente> SearchForNome(String nome)
    {
        List<Cliente> result = new List<Cliente>();

        string connString = DbSettings.connectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        string searchStr = "SELECT * FROM Cliente WHERE NOME LIKE '"+nome+"'";
        searchStr += " ORDER BY NOME ASC";
        SqlCommand cmd = new SqlCommand(searchStr, conn);
        SqlDataReader data = cmd.ExecuteReader();
        while (data.Read())
        {
            string d = data.GetValue(2).ToString();
            string datanascimento = d[0].ToString() + d[1].ToString() + d[2].ToString() + d[3].ToString() + d[4].ToString() + d[5].ToString() + d[6].ToString() + d[7].ToString() + d[8].ToString() + d[9].ToString();
            result.Add(new Cliente(data.GetString(1), data.GetString(0), data.GetString(3)[0], datanascimento));
        }
        data.Close();
        conn.Close();
        return result;
    }
}
