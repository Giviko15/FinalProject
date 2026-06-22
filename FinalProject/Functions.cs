using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;

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


        private decimal balance;


        public void Deposit()
        {
            
            {

            }
            Console.WriteLine("Enter amount to deposit: ");
            var depositbalance = decimal.Parse(Console.ReadLine());
            if (depositbalance > 0)
            {
                balance += depositbalance;
                Console.WriteLine("Deposit Successful. Your Balance is :" + balance);
                
            }

        }
        public void CheckBalance()
        {

            Console.WriteLine("Your Balance is :" + balance);
        } 
        //    transactions.Add(new Transaction
        //    {
        //        Type = "CheckBalance",
        //        Amount = (int)balance,
        //        Date = DateTime.Now,
        //    });
        //}
        public void Withdraw()
        {
            Console.WriteLine("Enter amount");
            var withdrawamount = decimal.Parse(Console.ReadLine());
            if (balance == 0 && balance < withdrawamount)
            {
                Console.WriteLine("Wrong Amount");
            }
            if (balance > 0)
            {
                Console.WriteLine("Your balance is : " + (balance - withdrawamount));

            }

        }
        public void ChangePin()
        {
            Console.WriteLine("Enter New PINCODE");
            var newpin = int.Parse(Console.ReadLine());


        }
        public void conversion()
        {
            decimal usdRate = 2.7m;
            decimal eurRate = 3.0m;
           
            Console.WriteLine("Choose conversion type : 1.GEL TO USD 2.GEL TO EUR");
            var chooseconversion = Console.ReadLine();
            Console.WriteLine("Enter Amount in GEL");
            decimal gel = decimal.Parse(Console.ReadLine());
            decimal eur = gel / eurRate;
            decimal usd = gel / usdRate;
            if (chooseconversion == "1")
            {
                Console.WriteLine($"You got USD: {usd}");
            }
       else if (chooseconversion == "2")
            {
                Console.WriteLine($"You got EUR: {eur}");
            }
        }
        public void last5transaction ()
        {
            var trlist = transactions;
            foreach (var tr in trlist)
            {
                Console.WriteLine(trlist);
            }
            
        }
    }
}

