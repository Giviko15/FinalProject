using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Transactions;

namespace FinalProject
{
    public class ATMCheck
    {

        public class Client
        {
            public string CardNumber { get; set; }
            public string CardDate { get; set; }
            public string PinCode { get; set; }
            public decimal Balance { get; set; }
            public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        }

        public class Transaction
        {
            public string Type { get; set; }
            public decimal Amount { get; set; }

            public DateTime Date { get; set; }

        }


        static string filePath = "C:\\Users\\Giviko\\source\\repos\\FinalProject\\FinalProject\\clients.json";

        public static List<Client> LoadClients()
        {
            if (!File.Exists(filePath)) return new List<Client>();
            string json = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(json)) return new List<Client>();
            return JsonSerializer.Deserialize<List<Client>>(json);
        }

        public static void SaveClients(List<Client> clients)
        {
            var json = JsonSerializer.Serialize(clients,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        public Client CheckATM()

        {



            List<string> clhistory = new List<string>();

            Console.WriteLine("Enter Card Number");
            var cardnumber = long.Parse(Console.ReadLine());


            if (cardnumber.ToString().Length != 16)
            {
                Console.WriteLine("Your Card Number is wrong");
                Logger.Log("Wrong Card Number");
                Environment.Exit(0);

            }


            Console.WriteLine("Enter Card Date");
            var carddate = DateTime.Parse(Console.ReadLine());
            if (carddate < DateTime.Today)
            {

                Console.WriteLine("Your Card Date is not valid");
                Logger.Log("Wrong Date");
                Environment.Exit(0);

            }
            else
            {
                Console.WriteLine("Your Card Date is valid");


            }
            Console.WriteLine("Enter Your PINCODE");
            var cardpincode = int.Parse(Console.ReadLine());
            Client client = new Client
            {
                CardNumber = cardnumber.ToString(),
                CardDate = carddate.ToString(),
                PinCode = cardpincode.ToString()

            };
            return client;
        }

       

    }
}


