using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class Customer 
    {
        Account account = new Account();
        public List<Account> Accounts { get; set; } = new List<Account>();

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        private string _fullName;
        string _nationalID;
        public static int ID { get; set; }
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Full name cannot be empty.");
                _fullName = value;
            }
        }
        public string NationalID
        {
            get { return _nationalID; }
            set
            {
                if (value.Length != 14 || !value.All(char.IsDigit))
                    throw new Exception("Error The Validation NationalID For 14 Digits!!");
                _nationalID = value;
            }
        }
        public DateTime DateOFBirth { get; set; }

        public Customer()
        {
            ID++;
            Console.WriteLine($"New Item ID: {ID}");
            FullName = "Khaled Ashraf";
            Console.WriteLine($"The Name Is: {FullName}");
            NationalID = "30508251702479";
            Console.WriteLine($"NationalID Is: {NationalID}");
            DateOFBirth = DateTime.Now;
        }
        public Customer(string fullname,string nationalID,DateTime dateOFBirth,decimal Balance,DateTime accDateOpen)
        {
            ID++;
            Console.WriteLine($"New Item ID: {ID}");
            FullName = fullname;
            Console.WriteLine($"The Name Is: {FullName}");
            NationalID =nationalID;
            Console.WriteLine($"NationalID Is: {NationalID}");
            DateOFBirth = dateOFBirth;
            account.Balance = Balance;
            account.DateOpened = accDateOpen;
        }
        public void ShowInfo()
        {
            Console.WriteLine(
                $"ID: {ID}\nFullName: {FullName}\nNationalID: {NationalID}\nDateOfBirth: {DateOFBirth}");

            foreach (Account acc in Accounts)
            {
                acc.ShowAccountDetails();
            }
        }

        public void UpdateDate(string name,DateTime dateOfBirth)
        {
           FullName = name;
           DateOFBirth = dateOfBirth;
            Console.WriteLine($"Your Date Is Updated Succesfully ");
        }
       public void DeleteCustomer(List<Customer> customerList)
        {
            Customer custToRemove = null;
            foreach(Customer customer in customerList)
            {
                if (customer.account.Balance == 0 && customer.FullName == this.FullName)
                {
                    custToRemove = customer;
                    break;
                }
            }
            if (custToRemove != null)
            {
                customerList.Remove(custToRemove);
                Console.WriteLine($"Customer {FullName} Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Cannot delete Balance greater than 0 or Customer not found");
            }
        }
        public static Customer GetCustBySearch(List<Customer> customerList, string name)
        {
            
            foreach(Customer customer in customerList)
            {
                if (customer.FullName == name)
                {
                   return customer;
                }
            }
            return null;
        }
    }
}
