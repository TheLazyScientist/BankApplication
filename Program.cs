using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Threading;

namespace Bankkonto
{
    internal static class Program
    {
        public static thisAccount loggedInAccount = new thisAccount();
        public static bool isLoggedIn;
        public static string fileName = Path.GetFullPath("SavedAccounts.json");

        private static void Main(string[] args)
        {
            Thread music = new Thread(musicPlayer);
            music.Start();
            bool isRunning = true;
            int accountPosition = 0;
            string[] startMessage;

            //Serializes the Jsonfile and converts it all to the AccountCollection List/Class
            if (File.Exists(fileName))
            {
                BankingDetails.accountList = JsonConvert.DeserializeObject<List<AccountCollection>>(File.ReadAllText(fileName));
            }

            //The menu  for everything, It's where you return after you have created/edited your account
            while (isRunning)
            {
                if (isLoggedIn)
                {
                    startMessage = new string[] { "C#Bank", "Logged in:" + loggedInAccount.AccountValues.accountName, "Please choose an option", "1: Enter Account   2: Withdraw or Deposit Money to Account", "3: Create Account   4: Instrucions", "5: Check Stocks   6: Exit Bank" };
                }
                else
                {
                    startMessage = new string[] { "C#Bank", "Please choose an option", "1: Enter Account   2: Withdraw or Deposit Money to Account", "3: Create Account   4: Instrucions", "5: Check Stocks   6: Exit Bank" };
                }
                bool accountFound = false;
                int choice = 0;

                Window.Write(startMessage.Length + 2, startMessage);
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                }

                switch (choice)
                {
                    //Checks if you're logged in and either throws you to the loggin window or allows you to check your balance/accounthistory
                    case 1:
                        if (isLoggedIn)
                        {
                            BaseAccount.TotalBalance(loggedInAccount.AccountValues.balance, loggedInAccount.AccountValues.history);
                        }
                        else
                        {
                            CheckAccount.ChecksAccount(ref accountPosition, ref accountFound);
                            if (accountFound)
                            {
                                BaseAccount.TotalBalance(loggedInAccount.AccountValues.balance, loggedInAccount.AccountValues.history);
                            }
                        }
                        break;

                    case 2:
                        //Checks if your logged in and either throws you to the loggin window or allows you to deposit/withdraw from your account
                        if (isLoggedIn)
                        {
                            EditAccount.AccountEdit(loggedInAccount.AccountValues);
                        }
                        else
                        {
                            CheckAccount.ChecksAccount(ref accountPosition, ref accountFound);
                            if (accountFound)
                            {
                                EditAccount.AccountEdit(loggedInAccount.AccountValues);
                            }
                        }
                        break;
                    //Sends you to the create section of the program where you can create a hostaccount.
                    case 3:
                        NewAccount.CreateAccount();
                        break;

                    case 4:
                        Window.Write(Messages.instructionMessage.Length + 2, Messages.instructionMessage);
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 5:
                        Window.Write(Messages.CompanyNameMessage.Length + 2, Messages.CompanyNameMessage);
                        AvailableStocks.StockExchange(Console.ReadLine());
                        break;
                    //Exits the program, but also writes the code from the accountList to a jsonfile.
                    case 6:
                        Console.Clear();
                        Window.Write(Messages.exitMessage.Length + 2, Messages.exitMessage);
                        string lazy = JsonConvert.SerializeObject(BankingDetails.accountList);
                        File.WriteAllText(fileName, lazy);
                        Environment.Exit(0);
                        break;
                }
            }
            //A threaded musicplayer that playes music at the same time as you use the application.
            static void musicPlayer()
            {
                SoundPlayer sound = new SoundPlayer("Elevator.wav");
                sound.PlayLooping();
            }
        }
    }
}