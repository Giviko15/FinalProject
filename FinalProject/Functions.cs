using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;
using static FinalProject.ATMCheck;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinalProject
{
    //public  class Transaction
    //{
    //    public string Type { get; set; }
    //    public int Amount { get; set; }
    //    public DateTime Date { get; set; }
    //    List<Transaction> transactions = new List<Transaction>();
    //}
    internal class Functions
    {
        private Client currentClient;
        public Functions(Client currentClient)
        {
            this.currentClient = currentClient;

        }

        public void ChooseOperation()
        {

            Console.WriteLine("Select the desired operation: ");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Last 5 Operations");
            Console.WriteLine("4. Deposit");
            Console.WriteLine("5. Change PINCODE");
            Console.WriteLine("6. Conversion");
            var choose = int.Parse(Console.ReadLine());
            if (choose == 1)
            {
                CheckBalance();
            }
            else if (choose == 4)
            {
                Deposit();

                return;

            }
            else if (choose == 2)
            {
                Withdraw();
            }
            else if (choose == 3)
            {
                last5transaction();
            }
            else if (choose == 5)
            {
                ChangePin();

            }
            else if (choose == 6)
            {
                conversion();
            }

        }





        public void Deposit()

        {

            Console.WriteLine("Enter Amount ");

            var depositbalance = decimal.Parse(Console.ReadLine());

            if (depositbalance > 0)

            {

                currentClient.Balance += depositbalance;

                currentClient.Transactions.Add(new ATMCheck.Transaction

                {

                    Type = "Deposit",

                    Amount = depositbalance,

                    Date = DateTime.Now

                });

                Console.WriteLine("Deposit Successfull. Your Amount: " + currentClient.Balance);

                SaveCurrentClient();

            }

        }
        public void CheckBalance()
        {

            Console.WriteLine("Your Balance is :" + currentClient.Balance);
            currentClient.Transactions.Add(new ATMCheck.Transaction
            {
                Type = "CheckBalance",
                Amount = currentClient.Balance,
                Date = DateTime.Now
            });
            SaveCurrentClient();
        }

        public void Withdraw()
        {
            Console.WriteLine("Enter amount");
            var withdrawamount = decimal.Parse(Console.ReadLine());
            if (currentClient.Balance < withdrawamount)
            {
                Console.WriteLine("Wrong Amount");
                return;
            }
            currentClient.Balance -= withdrawamount;
            currentClient.Transactions.Add(new ATMCheck.Transaction
            {
                Type = "Withdraw",
                Amount = withdrawamount,
                Date = DateTime.Now
            });
            Console.WriteLine("Your balance is: " + currentClient.Balance);
            SaveCurrentClient();
        }
        public void ChangePin()
        {
            Console.WriteLine("Enter New PINCODE");
            var newpin = int.Parse(Console.ReadLine());

            while (currentClient.PinCode == newpin.ToString())
            {

                Console.WriteLine("PINCODE is same, try different one");
                Logger.Log("PINCODE is same");
                newpin = int.Parse(Console.ReadLine());
                
            }

            
            
                
                currentClient.PinCode = newpin.ToString();
                currentClient.Transactions.Add(new ATMCheck.Transaction
                {
                    Type = "ChangePINCODE",
                    Amount = currentClient.Balance,
                    Date = DateTime.Now,
                });


                SaveCurrentClient();
            Console.WriteLine("PINCODE Changed Successfully");

            
            
        }
        public void conversion()
        {
            decimal usdRate = 2.7m;
            decimal eurRate = 3.0m;

            Console.WriteLine("Choose conversion type : 1.USD TO GEL 2.EUR TO GEL");
            var chooseconversion = Console.ReadLine();
            Console.WriteLine("Enter Amount: ");
            decimal gel = decimal.Parse(Console.ReadLine());
            decimal eur = gel * eurRate;
            decimal usd = gel * usdRate;

            if (chooseconversion == "1")
            {
                currentClient.Balance = currentClient.Balance + usd;
                Console.WriteLine($"You got USD: {currentClient.Balance}");
               
            }
            else if (chooseconversion == "2")
            {
                currentClient.Balance = currentClient.Balance + eur;
                Console.WriteLine($"You got EUR: {currentClient.Balance}");
                
            }
            else
            {
                Console.WriteLine("Wrong Choice");
                Environment.Exit(0);    
            }
            
            
            
            currentClient.Transactions.Add(new ATMCheck.Transaction
            {
                Type = "Conversion",
                Amount = currentClient.Balance,
                Date = DateTime.Now,

            });
            SaveCurrentClient();
        }
        public void last5transaction()
        {
            var last5 = currentClient.Transactions.TakeLast(5);
            foreach (var tr in last5)
            {
                Console.WriteLine($"{tr.Date}: {tr.Type} {tr.Amount}");
            }

        }
        private void SaveCurrentClient()
        {
            var all = ATMCheck.LoadClients();
            var index = all.FindIndex(c => c.CardNumber == currentClient.CardNumber);
            if (index >= 0) all[index] = currentClient;
            else all.Add(currentClient);
            ATMCheck.SaveClients(all);
        }
    }
}

