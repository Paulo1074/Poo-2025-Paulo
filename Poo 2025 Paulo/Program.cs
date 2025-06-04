public interface IPagamento
{
    void ProcessarPagamento(decimal valor);
}

public class PagamentoCartaoCredito : IPagamento
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"Pagamento de R$ {valor:F2} realizado com Cartão de Crédito.");
    }
}

public class PagamentoBoleto : IPagamento
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"Pagamento de R$ {valor:F2} realizado com Boleto Bancário.");
    }
}

public class PagamentoPIX : IPagamento
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"Pagamento de R$ {valor:F2} realizado via PIX.");
    }
}

public class LojaVirtual
{
    public void RealizarPagamento(IPagamento metodo, decimal valor)
    {
        metodo.ProcessarPagamento(valor);
    }
}

class Program
{
    static void Main(string[] args)
    {
        LojaVirtual loja = new LojaVirtual();

        Console.WriteLine("Bem-vindo à Loja Virtual");
        Console.Write("Digite o valor da compra: R$ ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
        {
            Console.WriteLine("Valor inválido!");
            return;
        }

        Console.WriteLine("Escolha a forma de pagamento:");
        Console.WriteLine("1 - Cartão de Crédito");
        Console.WriteLine("2 - Boleto Bancário");
        Console.WriteLine("3 - PIX");
        Console.Write("Opção: ");
        string? opcao = Console.ReadLine();

        IPagamento? metodo = null;

        switch (opcao)
        {
            case "1":
                metodo = new PagamentoCartaoCredito();
                break;
            case "2":
                metodo = new PagamentoBoleto();
                break;
            case "3":
                metodo = new PagamentoPIX();
                break;
            default:
                Console.WriteLine("Opção inválida!");
                return;
        }

        if (metodo != null)
        {
            loja.RealizarPagamento(metodo, valor);
        }
    }
}
