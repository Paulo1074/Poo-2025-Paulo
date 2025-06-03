using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoProdutos
{
    class Produto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }

    class Program
    {
        static List<Produto> produtos = new List<Produto>();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.WriteLine("\n===== MENU DE PRODUTOS =====");
                Console.WriteLine("1. Cadastrar produto");
                Console.WriteLine("2. Remover produto");
                Console.WriteLine("3. Pesquisar produto");
                Console.WriteLine("4. Mostrar produto com menor valor");
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
                        CadastrarProduto();
                        break;
                    case 2:
                        RemoverProduto();
                        break;
                    case 3:
                        PesquisarProduto();
                        break;
                    case 4:
                        MostrarProdutoMenorValor();
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

        static void CadastrarProduto()
        {
            Console.Write("\nDigite a descrição do produto: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o valor do produto: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.WriteLine("Valor inválido!");
                return;
            }

            produtos.Add(new Produto { Descricao = descricao, Valor = valor });
            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        static void RemoverProduto()
        {
            Console.Write("\nDigite a descrição do produto a ser removido: ");
            string descricao = Console.ReadLine();

            var produto = produtos.FirstOrDefault(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado!");
                return;
            }

            produtos.Remove(produto);
            Console.WriteLine("Produto removido com sucesso!");
        }

        static void PesquisarProduto()
        {
            Console.Write("\nDigite a descrição do produto a ser pesquisado: ");
            string descricao = Console.ReadLine();

            var produto = produtos.FirstOrDefault(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado!");
            }
            else
            {
                Console.WriteLine($"Produto encontrado: Descrição = {produto.Descricao}, Valor = R$ {produto.Valor:F2}");
            }
        }

        static void MostrarProdutoMenorValor()
        {
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            var menor = produtos.OrderBy(p => p.Valor).First();
            Console.WriteLine($"\nProduto com menor valor: Descrição = {menor.Descricao}, Valor = R$ {menor.Valor:F2}");
        }
    }
}
