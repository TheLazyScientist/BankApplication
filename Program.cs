using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Bankkonto
{
    class Program
    {
        public static Account loggedInAccount;
        public static bool isLoggedIn;
        static void Main(string[] args)
        {
            bool isRunning = true;
            int accountPosition = 0;
            bool accountFound = false;
            
            string fileName = Path.GetFullPath("SavedAccounts.json");
            
            /*
            var binFormatter = new BinaryFormatter();
            var oldmStream = new MemoryStream(File.ReadAllBytes(fileName));
            var mStream = new MemoryStream();
            */
            BankingDetails.accountList = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(fileName));
            //BankingDetails.accountList = (List<Account>)binFormatter.Deserialize(oldmStream);
            

            while (isRunning==true)
            {

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
                        if(isLoggedIn == true)
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
                        
                        if(isLoggedIn == true)
                        {
                            EditAccount.AccountEdit(loggedInAccount);
                        }
                        else
                        {
                            CheckAccount.ChecksAccount(ref accountPosition, ref accountFound);
                            if (accountFound == true)
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
                        //binFormatter.Serialize(mStream, BankingDetails.accountList);
                        string jon = JsonConvert.SerializeObject(BankingDetails.accountList);
                        File.WriteAllText(fileName, jon);
                        //File.WriteAllBytes(fileName, mStream.ToArray());
                        System.Environment.Exit(0);
                        break;
                }
                

            }
            
        }
    }
}
