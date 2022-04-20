using System;
using System.Collections.Generic;
using System.Text;

namespace Bankkonto
{
    class CheckAccount
    {
        static string accountName;
        static string password;
        public static void ChecksAccount(ref int accountPosition, ref bool accountFound)
        {
            Window.Write(Messages.enterAccountName.Length + 2, Messages.enterAccountName);
            accountName = Console.ReadLine();
            for(int i=0; i<BankingDetails.accountList.Count; i++)
            {
                if(accountName == BankingDetails.accountList[i].username)
                {
                    Window.Write(Messages.enterPassword.Length + 2, Messages.enterPassword);
                    password = Console.ReadLine();
                    if(password == BankingDetails.accountList[i].password)
                    {
                        accountFound = true;
                        accountPosition = i;
                        Program.loggedInAccount = BankingDetails.accountList[i];
                        Program.isLoggedIn = true;
                        break;
                    }
                    else
                    {
                        accountFound = false;
                        break;
                    }
                }
                else
                {
                    accountFound = false;
                }
            }
        }
    }
}
