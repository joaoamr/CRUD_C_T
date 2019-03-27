using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Class1
/// </summary>
public class Telefone
{
    private int id;
    private string ddd;
    private string numero;
    private string cpf;
      
    public Telefone(string ddd, string numero, string cpf)
    {
        this.ddd = ddd;
        this.numero = numero;
        this.cpf = cpf;
    }

    public Telefone(int id, string ddd, string numero, string cpf)
    {
        this.id = id;
        this.ddd = ddd;
        this.numero = numero;
        this.cpf = cpf;
    }

    public string Numero { get => numero; set => numero = value; }
    public string Cpf { get => cpf; set => cpf = value; }
    public string DDD { get => ddd; set => ddd = value; }
    public int Id { get => id; set => id = value; }


}