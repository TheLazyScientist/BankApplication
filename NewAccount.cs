using System;

namespace Bankkonto
{
    internal static class NewAccount
    {
        private static string accountName;
        private static string password;

        public static void CreateAccount()
        {
            bool isNewAccount = true;
            Window.Write(Messages.createHostAccountMessage1.Length + 2, Messages.createHostAccountMessage1);
            accountName = Console.ReadLine();
            for (int i = 0; BankingDetails.accountList.Count > i; i++)
            {
                if (accountName == BankingDetails.accountList[i].username)
                {
                    isNewAccount = false;
                    Window.Write(Messages.duplicateAccountMessage.Length + 2, Messages.duplicateAccountMessage);
                }
            }
            if (isNewAccount)
            {
                Window.Write(Messages.createHostAccountMessage2.Length + 2, Messages.createHostAccountMessage2);
                password = Console.ReadLine();
                BankingDetails.accountList.Add(new AccountCollection(password, accountName));
                //BankingDetails.accountList[BankingDetails.accountList.Count - 1].history.Add(DateTime.Now + ": BaseAccount was created");
            }
        }

        public static void AddAccount(int owner)
        {
            int choice = 0;
            float value = 0;
            string accountName;
            Window.Write(Messages.typeOfAccountMessageCreate.Length + 2, Messages.typeOfAccountMessageCreate);
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
            }
            Window.Write(Messages.createAccountMessage.Length + 2, Messages.createAccountMessage);
            accountName = Console.ReadLine();
            //Depending of choice it creates a different account to your baseAccount.
            switch (choice)
            {
                case 1:
                    BankingDetails.accountList[owner].BudgetAccounts.Add(new BudgetAccount(accountName));
                    break;

                case 2:
                    Window.Write(Messages.specialValueMessage.Length + 2, Messages.specialValueMessage);
                    try
                    {
                        value = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                    }
                    BankingDetails.accountList[owner].SavingAccounts.Add(new SavingAccount(accountName, value));
                    break;

                case 3:
                    Window.Write(Messages.specialValueMessage.Length + 2, Messages.specialValueMessage);
                    try
                    {
                        value = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                    }
                    BankingDetails.accountList[owner].PresentAccounts.Add(new PresentAccount(accountName, value));
                    break;
            }
        }
    }
}