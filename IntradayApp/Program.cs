using System;
using System.Collections.Generic;

namespace intraday
{
    class Program
    {
        static GerenciadorDeOperacoes gerenciador = new GerenciadorDeOperacoes();
        static void Main(string[] args)
        {

            int opcao;
            do
            {
                Console.Clear();
                ExibirMenu();
                opcao = int.Parse(Console.ReadLine());
                Operacoes(opcao);

            } while (opcao != 5);

            Console.WriteLine("Programa encerrado.");

        }

        static void Operacoes(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    CadastroDeOperacao();
                    break;
                case 2:
                    ListarOperacoes();
                    break;
                case 3:
                    ListarOperacoesPorData();
                    break;
                case 4:
                    MostraSaldo();
                    break;
            }
        }

        private static void MostraSaldo()
        {
            Console.Clear();
            Console.WriteLine(">>>> Mostrar Saldo <<<<");
            Console.WriteLine();
            Console.WriteLine($"Saldo total: {gerenciador.ObterSaldoTotal().ToString("C")}");
            Console.ReadLine();
        }

        private static void ListarOperacoesPorData()
        {
            Console.Clear();
            Console.WriteLine(">>>> Listagem de Operações Por Data <<<<");
            Console.WriteLine();
            Console.Write("Digite a data (dd/mm/aaaa): ");
            DateTime data = DateTime.Parse(Console.ReadLine());
            gerenciador.MostrarOperacoesESaldoPorData(data);
            Console.ReadLine();
        }

        private static void ListarOperacoes()
        {
            Console.Clear();
            Console.WriteLine(">>>> Listagem de Operações <<<<");
            gerenciador.MostrarTodasOperacoes();
            Console.WriteLine();
            Console.WriteLine($" Saldo Total: {gerenciador.ObterSaldoTotal().ToString("C")}");
            Console.ReadLine();
        }

        private static void CadastroDeOperacao()
        {
            Console.Clear();
            Console.WriteLine(">>>> Cadastro de Operação <<<<");

            Console.Write("Digite o Id: ");
            long id = long.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o saldo: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Digite a data (dd/mm/aaaa): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            gerenciador.CadastrarOperacao(
                new Operacao(id, data, saldo)
            );
            Console.WriteLine("Operação cadastrada com sucesso!");
            Console.ReadLine();
        }

        static void ExibirMenu()
        {
            Console.WriteLine("************ Intraday ************");
            Console.WriteLine("1. Cadastrar Operação");
            Console.WriteLine("2. Listar Todas as Operações");
            Console.WriteLine("3. Listar Operações Por Data");
            Console.WriteLine("4. Mostra Saldo");
            Console.WriteLine("5. Sair");
        }
    }
}
