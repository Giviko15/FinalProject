using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Transactions;

namespace FinalProject
{
    internal class ATMCheck
    {

        public class Client
        {
            public string CardNumber { get; set; }
            public string CardDate { get; set; }
            public string PinCode { get; set; }

        }



        static string filePath = "C:\\Users\\Giviko\\source\\repos\\FinalProject\\FinalProject\\clients.json";
        public void CheckATM()

        {
            Functions functions = new Functions();


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
            jsonsave(client);
        }

        public void jsonsave(Client client)
        {


            List<Client> allClients = new List<Client>();
            if (!allClients.Any(x => x.CardNumber == client.CardNumber))
            {
                allClients.Add(client);

            }

            if (File.Exists(filePath))
            {
                string oldJson = File.ReadAllText(filePath);

                if (!string.IsNullOrWhiteSpace(oldJson))
                {
                    allClients = JsonSerializer.Deserialize<List<Client>>(oldJson);
                }
            }


            var json = JsonSerializer.Serialize(allClients,
                new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, json);

        }
    }
}

