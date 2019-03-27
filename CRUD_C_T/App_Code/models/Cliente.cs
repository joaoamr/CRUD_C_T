using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Descrição resumida de Class1
/// </summary>

public class Cliente
{
    private string nome;
    private string cpf;
    private char genero;
    private string datanascimento;

    public Cliente(string nome, string cpf, char genero, string datanascimento)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.genero = genero;
        this.datanascimento = "";
        for(int i = 0; i < datanascimento.Length; i++)
            if(datanascimento[i] != '-')
                this.datanascimento += datanascimento[i];
    }

    public string Nome { get => nome; set => nome = value; }
    public string Cpf { get => cpf; set => cpf = value; }
    public char Genero { get => genero; set => genero = value; }
    public string Datanascimento { get => datanascimento; set => datanascimento = value; }
}
