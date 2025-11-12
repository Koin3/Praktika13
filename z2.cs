using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starboy2
{
    public abstract class BankAccount
    {
        public string Account { get; protected set; }
        public decimal Balance { get; protected set; }
        public string Owner { get; set; }
        protected BankAccount(string account, string owner, decimal initialBalance = 0)
        {
            Account = account;
            Owner = owner;
            Balance = initialBalance;
        }
        public virtual void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Счет {Account}: пополнение на {amount} руб. Новый баланс: {Balance} руб.");
            }
        }
        public virtual bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Счет {Account}: снятие {amount} руб. Новый баланс: {Balance} руб.");
                return true;
            }
            Console.WriteLine($"Счет {Account}: недостаточно средств для снятия {amount} руб.");
            return false;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Счет: {Account}");
            Console.WriteLine($"Владелец: {Owner}");
            Console.WriteLine($"Баланс: {Balance} руб.");
        }
    }
    public class CheckingAccount : BankAccount
    {
        public decimal OverdraftLimit { get; set; }

        public CheckingAccount(string accountNumber, string owner, decimal overdraftLimit, decimal initialBalance = 0)
            : base(accountNumber, owner, initialBalance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance + OverdraftLimit)
            {
                Balance -= amount;
                Console.WriteLine($"Счет {Account}: снятие {amount} руб. Новый баланс: {Balance} руб.");
                return true;
            }
            Console.WriteLine($"Счет {Account}: превышен лимит овердрафта. Нельзя снять {amount} руб.");
            return false;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Лимит овердрафта: {OverdraftLimit} руб.");
        }
    }
    public class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; }

        public SavingsAccount(string accountNumber, string owner, double interestRate, decimal initialBalance = 0)
            : base(accountNumber, owner, initialBalance)
        {
            InterestRate = interestRate;
        }

        public void ApplyInterest()
        {
            decimal interest = Balance * (decimal)(InterestRate / 100);
            Balance += interest;
            Console.WriteLine($"Счет {Account}: начислены проценты {interest} руб. по ставке {InterestRate}%. Новый баланс: {Balance} руб.");
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Процентная ставка: {InterestRate}%");
        }
    }
    public class CreditAccount : BankAccount
    {
        public decimal CreditLimit { get; set; }
        public DateTime DueDate { get; set; }

        public CreditAccount(string accountNumber, string owner, decimal creditLimit, DateTime dueDate)
            : base(accountNumber, owner, 0)
        {
            CreditLimit = creditLimit;
            DueDate = dueDate;
        }
        public decimal CalculateDebt()
        {
            return Math.Max(0, -Balance);
        }
        public override bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= CreditLimit + Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Кредитный счет {Account}: взятие кредита {amount} руб. Текущая задолженность: {CalculateDebt()} руб.");
                return true;
            }
            Console.WriteLine($"Кредитный счет {Account}: превышен кредитный лимит.");
            return false;
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Кредитный лимит: {CreditLimit} руб.");
            Console.WriteLine($"Срок погашения: {DueDate.ToShortDateString()}");
            Console.WriteLine($"Текущая задолженность: {CalculateDebt()} руб.");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starboy2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckingAccount checking = new CheckingAccount("ERD001", "Арсений Ли", 40000, 10000);
            SavingsAccount savings = new SavingsAccount("CDG001", "Ростислав Уткин", 5.0, 40000);
            CreditAccount credit = new CreditAccount("CRD001", "Кирилл Логинов", 100000, DateTime.Now.AddYears(1));

            checking.PrintInfo();
            checking.Withdraw(12000);
            checking.Deposit(6000);
            Console.WriteLine();

            savings.PrintInfo();
            savings.ApplyInterest();
            Console.WriteLine();

            credit.PrintInfo();
            credit.Withdraw(50000);
            credit.Deposit(20000);
        }
    }
}
