using System;
using System.Collections.Generic;
using System.Text;

namespace Bankkonto
{
    class NewAccount
    {
        static string accountName;
        static string password;
        public static void CreateAccount()
        {
            bool isNewAccount = true;
            Window.Write(Messages.createAccountMessage1.Length + 2, Messages.createAccountMessage1);
            accountName = Console.ReadLine();
            for(int i = 0; BankingDetails.accountList.Count > i; i++)
            {
                if(accountName == BankingDetails.accountList[i].username)
                {
                    isNewAccount = false;
                    Window.Write(Messages.duplicateAccountMessage.Length+ 2, Messages.duplicateAccountMessage);
                }
            }
            if(isNewAccount == true)
            {
                Window.Write(Messages.createAccountMessage2.Length + 2, Messages.createAccountMessage2);
                password = Console.ReadLine();
                BankingDetails.accountList.Add(new Account(password, accountName));
                BankingDetails.accountList[BankingDetails.accountList.Count - 1].history.Add(DateTime.Now + ": Account was created");
            }
        }
    }
}
