using System;
using System.Collections.Generic;

public class Competidor
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Modalidade { get; set; }

    public Competidor(string nome, int idade, string modalidade)
    {
        Nome = nome;
        Idade = idade;
        Modalidade = modalidade;
    }
}

public class Competicao
{
    public string Nome { get; private set; }
    private List<Competidor> competidores = new List<Competidor>();

    public Competicao(string nome)
    {
        Nome = nome;
    }

    public void AdicionarCompetidor(Competidor competidor)
    {
        competidores.Add(competidor);
        Console.WriteLine("Competidor adicionado com sucesso!");
    }

    public void ListarCompetidores()
    {
        if (competidores.Count == 0)
        {
            Console.WriteLine("Nenhum competidor cadastrado.");
            return;
        }

        Console.WriteLine($"\nCompetidores da competição '{Nome}':");
        for (int i = 0; i < competidores.Count; i++)
        {
            var c = competidores[i];
            Console.WriteLine($"{i + 1}. Nome: {c.Nome}, Idade: {c.Idade}, Modalidade: {c.Modalidade}");
        }
    }

    public void EditarCompetidor(int indice, Competidor novo)
    {
        if (indice >= 0 && indice < competidores.Count)
        {
            competidores[indice] = novo;
            Console.WriteLine("Competidor atualizado com sucesso.");
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

    public void RemoverCompetidor(int indice)
    {
        if (indice >= 0 && indice < competidores.Count)
        {
            competidores.RemoveAt(indice);
            Console.WriteLine("Competidor removido com sucesso.");
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

    public int QuantidadeCompetidores => competidores.Count;
}
public class Program
{
    public static void Main(string[] args)
    {
        Competicao competicao = new Competicao("Olimpíadas Escolares");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Adicionar competidor");
            Console.WriteLine("2. Listar competidores");
            Console.WriteLine("3. Editar competidor");
            Console.WriteLine("4. Remover competidor");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Idade: ");
                    int idade = int.Parse(Console.ReadLine());
                    Console.Write("Modalidade: ");
                    string modalidade = Console.ReadLine();
                    competicao.AdicionarCompetidor(new Competidor(nome, idade, modalidade));
                    break;
                case "2":
                    competicao.ListarCompetidores();
                    break;
                case "3":
                    competicao.ListarCompetidores();
                    Console.Write("Digite o número do competidor para editar: ");
                    if (int.TryParse(Console.ReadLine(), out int indiceEditar))
                    {
                        indiceEditar -= 1;
                        Console.Write("Novo nome: ");
                        string novoNome = Console.ReadLine();
                        Console.Write("Nova idade: ");
                        int novaIdade = int.Parse(Console.ReadLine());
                        Console.Write("Nova modalidade: ");
                        string novaModalidade = Console.ReadLine();
                        competicao.EditarCompetidor(indiceEditar, new Competidor(novoNome, novaIdade, novaModalidade));
                    }
                    else
                    {
                        Console.WriteLine("Índice inválido.");
                    }
                    break;
                case "4":
                    competicao.ListarCompetidores();
                    Console.Write("Digite o número do competidor para remover: ");
                    if (int.TryParse(Console.ReadLine(), out int indiceRemover))
                    {
                        indiceRemover -= 1;
                        competicao.RemoverCompetidor(indiceRemover);
                    }
                    else
                    {
                        Console.WriteLine("Índice inválido.");
                    }
                    break;
                case "5":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
