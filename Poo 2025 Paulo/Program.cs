using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorAlunos
{
    class Aluno
    {
        public string RA { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }

    class Program
    {
        static List<Aluno> alunos = new List<Aluno>();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Cadastrar aluno");
                Console.WriteLine("2. Listar alunos");
                Console.WriteLine("3. Alterar aluno");
                Console.WriteLine("4. Remover aluno");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarAluno();
                        break;
                    case 2:
                        ListarAlunos();
                        break;
                    case 3:
                        AlterarAluno();
                        break;
                    case 4:
                        RemoverAluno();
                        break;
                    case 5:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != 5);
        }

        static void CadastrarAluno()
        {
            Console.Write("\nDigite o RA do aluno: ");
            string ra = Console.ReadLine();

            if (alunos.Any(a => a.RA == ra))
            {
                Console.WriteLine("RA já cadastrado!");
                return;
            }

            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a idade do aluno: ");
            if (!int.TryParse(Console.ReadLine(), out int idade))
            {
                Console.WriteLine("Idade inválida!");
                return;
            }

            alunos.Add(new Aluno { RA = ra, Nome = nome, Idade = idade });
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }

        static void ListarAlunos()
        {
            if (alunos.Count == 0)
            {
                Console.WriteLine("\nNenhum aluno cadastrado.");
                return;
            }

            Console.WriteLine("\nLista de alunos:");
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"RA: {aluno.RA}, Nome: {aluno.Nome}, Idade: {aluno.Idade}");
            }
        }

        static void AlterarAluno()
        {
            Console.Write("\nDigite o RA do aluno a ser alterado: ");
            string ra = Console.ReadLine();

            var aluno = alunos.FirstOrDefault(a => a.RA == ra);
            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado!");
                return;
            }

            Console.Write("Digite o novo nome: ");
            aluno.Nome = Console.ReadLine();

            Console.Write("Digite a nova idade: ");
            if (!int.TryParse(Console.ReadLine(), out int novaIdade))
            {
                Console.WriteLine("Idade inválida!");
                return;
            }

            aluno.Idade = novaIdade;
            Console.WriteLine("Dados do aluno atualizados com sucesso!");
        }

        static void RemoverAluno()
        {
            Console.Write("\nDigite o RA do aluno a ser removido: ");
            string ra = Console.ReadLine();

            var aluno = alunos.FirstOrDefault(a => a.RA == ra);
            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado!");
                return;
            }

            alunos.Remove(aluno);
            Console.WriteLine("Aluno removido com sucesso!");
        }
    }
}
