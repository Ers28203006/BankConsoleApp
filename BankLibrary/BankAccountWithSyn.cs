using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    [Synchronization]
    public class BankAccountWithSyn : ContextBoundObject
    {
        private int id;
        private double sum;
        private static int counter = 0;

        public BankAccountWithSyn(double sum)
        {
            id = ++counter;
            this.sum = sum;
            Console.WriteLine($"Открыт счет под номером: {id}");
            Console.WriteLine($"Средств на счете: {sum}\n");
        }
        public void Put(object sum)
        {
            this.sum += (double)sum;
            Console.WriteLine($"На счет поступило средств на сумму: {sum}\n" +
                $"Средств на счете: {this.sum}\n");
        }
        public void Withdraw(object sum)
        {
            if (this.sum >= (double)sum)
            {
                this.sum -= (double)sum;
                Console.WriteLine($"Со счета снято средств на сумму: {sum}\n" +
                    $"Средств на счете: {this.sum}\n");
            }
            else
                Console.WriteLine("Недостаточно средств для списания");
        }
    }
}
