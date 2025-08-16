using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class SavingAccount :Account
    {
        private decimal _interestRate;
        public decimal InterestRate
        {
            get
            {
                return _interestRate;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid InterestRate!! ");
                }
                _interestRate = value;
            }
        }
        public SavingAccount()
        {
            InterestRate = 20;
            Balance = 5000;
        }
        public SavingAccount(decimal interestRate, decimal balance)
        {
            InterestRate = interestRate;
            Balance = balance;
        }
        public override decimal CalculateInterest()
        {
            return Balance * InterestRate / 100;
        }
        public override void ShowAccountDetails()
        {
            base.ShowAccountDetails();
            Console.WriteLine($"InterestRate: {InterestRate}");
        }
        public decimal CalculateMonthlyInterest()
        {
            return (Balance * InterestRate / 100) / 12;
        }

    }
}
