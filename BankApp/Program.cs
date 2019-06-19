using BankLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool alive = true;
            while (alive)
            {
                Console.WriteLine("1. Без синхронизации  \t 2. С синхронизацией");
                Console.WriteLine("3. Выйти из программы");
                Console.WriteLine("Введите номер пункта:");
                int command = Convert.ToInt32(Console.ReadLine());

                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    var endtime = DateTime.Now.AddSeconds(1);

                    switch (command)
                    {
                        case 1:
                            BankAccount bankAccount = new BankAccount(2000);
                            
                            for (; endtime > DateTime.Now;)
                            {
                                int choice = new Random().Next(2);
                                double sum = new Random().Next(100);
                                if (choice == 0)
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(bankAccount.Put));
                                    thread.Start(sum);
                                }
                                else
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(bankAccount.Withdraw));
                                    thread.Start(sum);
                                }
                            }
                            break;
                        case 2:
                            BankAccountWithSyn bankAccountWithSyn = new BankAccountWithSyn(2000);
                            for (; endtime > DateTime.Now;)
                            {
                                int choice = new Random().Next(2);
                                double sum = new Random().Next(100);
                                if (choice == 0)
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(bankAccountWithSyn.Put));
                                    thread.Start(sum);
                                }
                                else
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(bankAccountWithSyn.Withdraw));
                                    thread.Start(sum);
                                }
                            }
                            break;
                        case 3:
                            alive = false; break;
                        default: goto case 3;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                Thread.Sleep(100);
                Console.ForegroundColor = color;
            }
        }
    }
}
