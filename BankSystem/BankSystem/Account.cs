using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class Account
    {
        public static int ID {  get; set; }
        private decimal _balance;
        public DateTime DateOpened { get; set; }
        public decimal Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid Balance!! ");
                }
                _balance = value;
            }
        }
        public virtual decimal CalculateInterest()
        {
            return 0;
        }
        public virtual void ShowAccountDetails()
        {
            Console.WriteLine($"Your Balace Is: {Balance}");
            Console.WriteLine($"Interest: {CalculateInterest()}");
        }
        public void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount}, New Balance = {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance!");
            }
        }
        public void Deposit(decimal amount)
        {
            if (Balance > 0)
            {
                Balance += amount;
                Console.WriteLine($"Your Balance After Added {amount} Is {Balance}");
            }
            else
            {
                Console.WriteLine("Cannt Deposite !");
            }
        }
        public void Transfer(Account toAccount, decimal amount)
        {
            if (Balance >= amount)
            {
                this.Balance -= amount;
                toAccount.Balance += amount;
                Console.WriteLine($"Transferred {amount} to account. Your Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance for transfer!");
            }
        }

    }
}
