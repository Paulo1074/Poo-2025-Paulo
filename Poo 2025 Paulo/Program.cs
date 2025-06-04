using System;

class Program
{
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            try
            {
                Console.Write("\nDigite o primeiro número (ou 'sair' para encerrar): ");
                string entrada1 = Console.ReadLine();

                if (entrada1.Trim().ToLower() == "sair")
                {
                    continuar = false;
                    break;
                }

                int numero1 = int.Parse(entrada1);

                Console.Write("Digite o segundo número: ");
                string entrada2 = Console.ReadLine();
                int numero2 = int.Parse(entrada2);

                int resultado = numero1 / numero2;

                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Valor inválido. Digite um número inteiro.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Erro: Não é possível dividir por zero.");
            }
        }

        Console.WriteLine("\nPrograma encerrado.");
    }
}
