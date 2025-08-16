using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class CurrentAccount :Account
    {
        private decimal _overdraftLimit;
        public decimal OverdraftLimit
        {
            get
            {
                return _overdraftLimit;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid OverdraftLimit!! ");
                }
                _overdraftLimit = value;
            }
        }
        public override decimal CalculateInterest()
        {
            return 0;
        }
        public CurrentAccount()
        {
            Balance = 1000;
            OverdraftLimit = 500;
        }
        public CurrentAccount(decimal balance, decimal OverdraftLimit)
        {
            Balance = balance;
            this.OverdraftLimit = OverdraftLimit;
        }
        public override void ShowAccountDetails()
        {
            base.ShowAccountDetails();
            Console.WriteLine($"OverdraftLimit:{OverdraftLimit}");
        }
    }
}
