using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab_9
{
    public enum AccountType
    {
        Current,
        Saving
    }
    public class Account
    {
        private int nextAccountNumber;
        private int AccountNumber;
        public decimal Balance;
        public AccountType Accounttype;
        private Queue<BankTransaction> Transactions = new Queue<BankTransaction>();

        public Account()
        {
            AccountNumber = GetNextAccountNumber();
        }

        public int GetNextAccountNumber()
        {
            return ++nextAccountNumber;
        }


        public Account(decimal balance)
        {
            AccountNumber = GetNextAccountNumber();
            Balance = balance;
        }

        public Account(AccountType accounttype)
        {
            AccountNumber = GetNextAccountNumber();
            Accounttype = accounttype;
        }

        public Account(decimal balance, AccountType accounttype)
        {
            AccountNumber = GetNextAccountNumber();
            Balance = balance;
            Accounttype = accounttype;
        }

        public decimal TakeoffAccount(decimal amount)
        {
            BankTransaction transaction = new BankTransaction(DateTime.Now, -amount);
            if (amount <= Balance && amount > 0)
            {
                Balance -= amount;
                Transactions.Enqueue(transaction);
                return Balance;

            }
            else
            {
                return -1;
            }
        }

        public void PutonAccount(decimal amount)
        {
            BankTransaction transaction = new BankTransaction(DateTime.Now, amount);
            if (amount < 0)
            {
                Console.WriteLine("Неправильно введено значение!");
            }
            else
            {
                Balance += amount;
                Transactions.Enqueue(transaction);
                Console.WriteLine($"Новый баланс: {Balance}");
            }
        }

        public void PrintNewBalance()
        {
            Balance = 15000;
            Console.WriteLine("Снять или пополнить?(после ввода нажмите enter)");
            string str = Console.ReadLine();
            str = str.ToLower();
            if (str == "снять")
            {
                Console.WriteLine("Введите сумму для снятия(после ввода нажмите enter):");
                decimal amount = decimal.Parse(Console.ReadLine());
                decimal newBalance = TakeoffAccount(amount);
                if (newBalance == -1)
                {
                    Console.WriteLine("Недостаточно средств на счете или неправильно введено значение для снятие!");
                }
                else
                {
                    Console.WriteLine($"Новый баланс: {newBalance}");
                    // Получаем время транзакции с помощью метода Peek
                    // Первый элемент в очереди транзакций
                    DateTime transactionTime = Transactions.Peek().DateTime;
                    // Получаем сумму транзакции с помощью метода Peek
                    decimal transactionSum = Transactions.Peek().Sum;
                    Console.WriteLine($"Время транзакции: {transactionTime}");
                    Console.WriteLine($"Сумма транзакции: {transactionSum}");
                    Dispose();

                }
            }
            else if (str == "пополнить")
            {
                Console.WriteLine("Введите сумму для пополнения(после ввода нажмите enter):");
                decimal amount = decimal.Parse(Console.ReadLine());
                PutonAccount(amount);
                DateTime transactionTime = Transactions.Peek().DateTime;
                decimal transactionSum = Transactions.Peek().Sum;
                Console.WriteLine($"Время транзакции: {transactionTime}");
                Console.WriteLine($"Сумма транзакции: {transactionSum}");
                Dispose();
            }
        }

        public void Print()
        {
            Console.WriteLine($"Номер: {AccountNumber}");
            Console.WriteLine($"Баланс: {Balance}");
            Console.WriteLine($"Тип счета: {Accounttype}");
        }
        public void TransferMoney(Account account1, decimal amount)
        {
            decimal newBalance = account1.TakeoffAccount(amount);

            if (newBalance != -1)
            {
                account1.AccountNumber++;
                Balance += amount;
                Console.WriteLine($"Новый баланс на счету {AccountNumber}: {Balance}");
                Console.WriteLine($"Новый баланс на счету {account1.AccountNumber}: {newBalance}");
                DateTime transactionTime = account1.Transactions.Peek().DateTime;
                decimal transactionSum = account1.Transactions.Peek().Sum;
                Console.WriteLine($"Время транзакции: {transactionTime}");
                Console.WriteLine($"Сумма транзакции: {transactionSum}");
                account1.Dispose();
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете или неправильно введено значение для перевода!");
            }
        }
        public void Dispose()
        {
            if (Transactions.Count > 0)
            {
                using (StreamWriter writer = new StreamWriter("Transactions.txt", true))
                {
                    foreach (BankTransaction transaction in Transactions)
                    {
                        writer.WriteLine($"Дата: {transaction.DateTime}, Сумма: {transaction.Sum}");
                    }
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
