using System.Security.Principal;
using System.Transactions;

namespace BankSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            Console.WriteLine("Hello, World!");
            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Welcome To Bank ElAhalay");
                Console.WriteLine(@"1:Add New Account 
                                    2:Update Customer Info
                                    3:Delete Customer 
                                    4: Search For Customer: 
                                    5: Withdraw: 
                                    6:Deposite:
                                    7:Transfer
                                    8:Display Current Customer: 
                                    9:Exit: ");
                bool IsChhoce = int.TryParse(Console.ReadLine(), out int chooce);
                if (IsChhoce == false)
                {
                    Console.WriteLine("Please Enter Valid Number {1 or 2 or 3,....}");
                }
                else
                {
                   
                    switch (chooce)
                    {
                        case 1:
                         
                            Console.Write("Enter Your Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Your National Id: ");
                            string national = Console.ReadLine();
                            Console.Write("Enter Your BirthDate: ");
                            DateTime birthDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter Your Balance: ");
                            decimal balance = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter Account Date Open: ");
                            DateTime accDateOpened = DateTime.Parse(Console.ReadLine());

                            Customer cust = new Customer(name, national, birthDate, balance, accDateOpened);
                            cust.Accounts.Add(new SavingAccount(10, 5000));
                            cust.Accounts.Add(new CurrentAccount( 1000,  500));
                            customers.Add(cust);

                            break;

                            case 2:
                            Console.Write("Enter Customer Name: ");
                            string nameCustomer = Console.ReadLine();
                            Console.Write("Enter Customer BirthDate: ");
                            DateTime BdCustomer = DateTime.Parse(Console.ReadLine());
                            foreach(Customer customer in customers)
                            {
                                if(customer.FullName == nameCustomer)
                                {
                                    Console.Write("Enter New Customer Name: ");
                                    string newName = Console.ReadLine();
                                    Console.Write("Enter New Customer BirthDate: ");
                                    DateTime newBdCustomer = DateTime.Parse(Console.ReadLine());
                                    customer.UpdateDate(newName,newBdCustomer);
                                    break;
                                }
                                else
                                    Console.WriteLine("Customer Not Found");
                            }
                            break;
                            case 3:
                            Console.Write("Enter The Account Name: ");
                            string NameDel= Console.ReadLine();
                            foreach (Customer customer in customers)
                            {
                                if (customer.FullName == NameDel)
                                {
                                    customer.DeleteCustomer(customers);
                                    break;
                                }
                            }
                            break;
                        case 4:
                            Console.Write("Enter The Customer Name: ");
                            string CustName = Console.ReadLine();
                            Customer found = Customer.GetCustBySearch(customers, CustName);
                            if (found != null)
                            {
                                Console.WriteLine("Customer Found:");
                                found.ShowInfo();
                            }
                            else
                            {
                                Console.WriteLine("Customer Not Found");
                            }
                            break;
                            case 5:
                            Console.Write("Enter Customer Name: ");
                            string withdrawName = Console.ReadLine();

                            Customer withdrawCustomer = null;

                            foreach (Customer customer in customers)
                            {
                                if (customer.FullName == withdrawName)
                                {
                                    withdrawCustomer = customer;
                                    break;
                                }
                            }
                            if (withdrawCustomer != null && withdrawCustomer.Accounts.Count > 0)
                            {
                                Console.Write("Enter Account Index (0 for first account): ");
                                int accIndex = int.Parse(Console.ReadLine());

                                if (accIndex >= 0 && accIndex < withdrawCustomer.Accounts.Count)
                                {
                                    Console.Write("Enter Amount of Withdraw: ");
                                    decimal amount = decimal.Parse(Console.ReadLine());
                                    withdrawCustomer.Accounts[accIndex].Withdraw(amount);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid account index!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Customer not found or has no accounts.");
                            }
                            break;
                        case 6:
                            Console.Write("Enter Customer Name: ");
                            string DeposteName = Console.ReadLine();
                            Customer DeposteCustomer = null;

                            foreach (Customer customer in customers)
                            {
                                if (customer.FullName == DeposteName)
                                {
                                    DeposteCustomer = customer;
                                    break;
                                }
                            }
                            if (DeposteCustomer != null && DeposteCustomer.Accounts.Count > 0)
                            {
                                Console.Write("Enter Account Index (0 for first account): ");
                                int accIndex = int.Parse(Console.ReadLine());

                                if (accIndex >= 0 && accIndex < DeposteCustomer.Accounts.Count)
                                {
                                    Console.Write("Enter Amount of Withdraw: ");
                                    decimal amount = decimal.Parse(Console.ReadLine());
                                    DeposteCustomer.Accounts[accIndex].Deposit(amount);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid account index!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Customer not found or has no accounts.");
                            }
                            break;
                        case 7:
                            Console.Write("Enter Sender Customer Name: ");
                            string senderName = Console.ReadLine();

                            Console.Write("Enter Receiver Customer Name: ");
                            string receiverName = Console.ReadLine();

                            Console.Write("Enter Amount To Transfer: ");
                            decimal transferAmount = decimal.Parse(Console.ReadLine());
                            Customer sender = null;
                            Customer receiver = null;

                            foreach(Customer customer in customers)
                            {
                                if (customer.FullName == senderName)
                                {
                                    sender = customer;
                                }
                                if (customer.FullName == receiverName)
                                {
                                    receiver = customer;
                                }
                            }
                            if (sender != null && receiver != null)
                            {
                                if (sender.Accounts.Count > 0 && receiver.Accounts.Count > 0)
                                {
                                    sender.Accounts[0].Transfer(receiver.Accounts[0], transferAmount);
                                }
                                else
                                {
                                    Console.WriteLine("One of the customers has no accounts!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sender or Receiver not found!");
                            }
                            break;
                        case 8:
                            foreach(Customer customer in customers)
                            {
                                customer.ShowInfo();
                            }
                            break;
                            case 9: return;
                            default: Console.WriteLine("Enter Valid Number!");break;
                    }
                } 
            } while (true);
        }
    }
}
