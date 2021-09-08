using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intraday
{
    public class Operacao
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public double Saldo { get; set; }

        public Operacao (long id, DateTime data, double saldo)
        {
            this.Id = id;
            this.Data = data;
            this.Saldo = saldo;
        }

        public override string ToString()
        {
            return $" Id: {Id, -3} | Saldo: {Saldo.ToString("F"), 8} | Data: {Data.Date:d}";
        }

    }
}
