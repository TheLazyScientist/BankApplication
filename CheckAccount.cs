using System;

namespace Bankkonto
{
    internal static class CheckAccount
    {
        private static string accountName;
        private static string password;

        public static void ChecksAccount(ref int accountPosition, ref bool accountFound)
        {
            Window.Write(Messages.enterAccountName.Length + 2, Messages.enterAccountName);
            accountName = Console.ReadLine();
            for (int i = 0; i < BankingDetails.accountList.Count; i++)
            {
                if (accountName == BankingDetails.accountList[i].username)
                {
                    Window.Write(Messages.enterPassword.Length + 2, Messages.enterPassword);
                    password = Console.ReadLine();
                    if (password == BankingDetails.accountList[i].password)
                    {
                        accountFound = true;
                        accountPosition = i;
                        Program.loggedInAccount = BankingDetails.accountList[i];
                        Program.isLoggedIn = true;
                        break;
                    }
                    else
                    {
                        Window.Write(Messages.noAccountMessage.Length + 2, Messages.noAccountMessage);
                        accountFound = false;
                        break;
                    }
                }
                else
                {
                    accountFound = false;
                }
            }
            if (accountFound == false)
            {
                Window.Write(Messages.noAccountMessage.Length + 2, Messages.noAccountMessage);
            }
        }
    }
}