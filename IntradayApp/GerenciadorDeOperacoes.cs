using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intraday
{
    public class GerenciadorDeOperacoes
    {
        private List<Operacao> operacoes;

        public GerenciadorDeOperacoes()
        {
            operacoes = new List<Operacao>();
        }

        public void CadastrarOperacao(Operacao operacao)
        {
            operacoes.Add(operacao);
        }

        public List<Operacao> ObterOperacoes()
        {
            return operacoes;
        }
        public void MostrarTodasOperacoes()
        {
            if (operacoes.Count == 0)
            {
                Console.WriteLine("\n Nenhuma operação cadastrada.");
            } else
            {
                operacoes.ForEach(o => Console.WriteLine(o));
            }
        }
        public void MostrarOperacoesESaldoPorData(DateTime data)
        {
            List<Operacao> operacoesPorData = this.operacoes.FindAll(o => o.Data.ToShortDateString().Equals(data.ToShortDateString()));

            Console.WriteLine($"Data: {data.ToShortDateString()}");
            Console.WriteLine("----------------");
            Console.WriteLine($" ID  | {"Resultado", 8}");
            Console.WriteLine("----------------");

            foreach (var op in operacoesPorData)
            {
                Console.WriteLine($" {op.Id, -3} | {op.Saldo.ToString("F"), 8}");
            }

            double saldoDoDia = 0;
            operacoesPorData.ForEach(o => saldoDoDia += o.Saldo);

            Console.WriteLine("----------------");
            Console.WriteLine($"\n Saldo do dia: {saldoDoDia.ToString("C")}");

        }

        public double ObterSaldoTotal()
        {
            double saldoTotal = 0;
            this.operacoes.ForEach(o => saldoTotal += o.Saldo);

            return saldoTotal;
        }

    }
}
