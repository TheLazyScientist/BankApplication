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
        public static Account loggedInAccount;
        public static bool isLoggedIn;

        private static void Main(string[] args)
        {
            Thread music = new Thread(musicPlayer);
            music.Start();
            bool isRunning = true;
            int accountPosition = 0;
            bool accountFound = false;

            string fileName = Path.GetFullPath("SavedAccounts.json");

            if (File.Exists(fileName))
            {
                BankingDetails.accountList = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(fileName));
            }

            while (isRunning)
            {
                //Console.Clear();
                int choice = 0;

                Window.Write(Messages.startMessage.Length + 2, Messages.startMessage);
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                }

                switch (choice)
                {
                    case 1:
                        if (isLoggedIn)
                        {
                            Account.totalBalance(loggedInAccount.balance, loggedInAccount.history);
                        }
                        else
                        {
                            CheckAccount.ChecksAccount(ref accountPosition, ref accountFound);
                            if (accountFound == true)
                            {
                                Account.totalBalance(BankingDetails.accountList[accountPosition].balance, BankingDetails.accountList[accountPosition].history);
                            }
                        }
                        break;

                    case 2:

                        if (isLoggedIn)
                        {
                            EditAccount.AccountEdit(loggedInAccount);
                        }
                        else
                        {
                            CheckAccount.ChecksAccount(ref accountPosition, ref accountFound);
                            if (accountFound)
                            {
                                EditAccount.AccountEdit(BankingDetails.accountList[accountPosition]);
                            }
                        }
                        break;

                    case 3:
                        NewAccount.CreateAccount();
                        break;

                    case 4:
                        Window.Write(Messages.exitMessage.Length + 2, Messages.exitMessage);
                        string jon = JsonConvert.SerializeObject(BankingDetails.accountList);
                        File.WriteAllText(fileName, jon);
                        Environment.Exit(0);
                        break;
                }
            }

            static void musicPlayer()
            {
                SoundPlayer sound = new SoundPlayer("Elevator.wav");
                sound.PlayLooping();
            }
        }
    }
}