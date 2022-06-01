using System;
using System.Collections.Generic;

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
            bool createdAccount = false;
            for (int i = 0; i < BankingDetails.accountList.Count; i++)
            {
                if (accountName == BankingDetails.accountList[i].username)
                {
                    Window.Write(Messages.enterPassword.Length + 2, Messages.enterPassword);
                    password = Console.ReadLine();
                    if (password == BankingDetails.accountList[i].password)
                    {
                        accountPosition = i;
                        int choice = 0;
                        List<string> accountTypes = new List<string>();

                        Window.Write(Messages.newAccountMessage.Length + 2, Messages.newAccountMessage);

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
                                NewAccount.AddAccount(i);
                                choice = 0;
                                createdAccount = true;
                                break;
                        }

                        Window.Write(Messages.typeOfAccountMessageEnter.Length + 2, Messages.typeOfAccountMessageEnter);
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

                                #region BudgetAccounts

                                for (int k = 0; k < BankingDetails.accountList[i].BudgetAccounts.Count; k++)
                                {
                                    accountTypes.Add(k + ": " + BankingDetails.accountList[i].BudgetAccounts[k].accountName);
                                }
                                Window.Write(accountTypes.Count + 2, accountTypes.ToArray());

                                try
                                {
                                    if (BankingDetails.accountList[i].BudgetAccounts.Count != 0)
                                    {
                                        choice = Convert.ToInt32(Console.ReadLine());
                                    }
                                }
                                catch (System.FormatException)
                                {
                                }

                                for (int k = 0; k < BankingDetails.accountList[i].BudgetAccounts.Count; k++)
                                {
                                    if (choice == k)
                                    {
                                        Program.loggedInAccount.AccountValues = BankingDetails.accountList[i].BudgetAccounts[k];
                                        Program.loggedInAccount.accountOwner = i;
                                        Program.loggedInAccount.accountType = k;
                                        accountFound = true;
                                        Program.isLoggedIn = true;
                                    }
                                }

                                break;

                            #endregion BudgetAccounts

                            case 2:

                                #region SavingAccounts

                                for (int k = 0; k < BankingDetails.accountList[i].SavingAccounts.Count; k++)
                                {
                                    accountTypes.Add(k + ": " + BankingDetails.accountList[i].SavingAccounts[k].accountName);
                                }
                                Window.Write(accountTypes.Count + 2, accountTypes.ToArray());

                                try
                                {
                                    if (BankingDetails.accountList[i].SavingAccounts.Count != 0)
                                    {
                                        choice = Convert.ToInt32(Console.ReadLine());
                                    }
                                }
                                catch (System.FormatException)
                                {
                                }

                                for (int k = 0; k < BankingDetails.accountList[i].SavingAccounts.Count; k++)
                                {
                                    if (choice == k)
                                    {
                                        Program.loggedInAccount.AccountValues = BankingDetails.accountList[i].SavingAccounts[k];
                                        Program.loggedInAccount.accountOwner = i;
                                        Program.loggedInAccount.accountType = k;
                                        accountFound = true;
                                        BankingDetails.accountList[i].SavingAccounts[k].UpToDate();
                                        Program.isLoggedIn = true;
                                    }
                                }

                                break;

                            #endregion SavingAccounts

                            case 3:

                                #region PresentAccount

                                for (int k = 0; k < BankingDetails.accountList[i].PresentAccounts.Count; k++)
                                {
                                    accountTypes.Add(k + ": " + BankingDetails.accountList[i].PresentAccounts[k].accountName);
                                }
                                Window.Write(accountTypes.Count + 2, accountTypes.ToArray());

                                try
                                {
                                    if (BankingDetails.accountList[i].PresentAccounts.Count != 0)
                                    {
                                        choice = Convert.ToInt32(Console.ReadLine());
                                    }
                                }
                                catch (System.FormatException)
                                {
                                }

                                for (int k = 0; k < BankingDetails.accountList[i].PresentAccounts.Count; k++)
                                {
                                    if (choice == k)
                                    {
                                        Program.loggedInAccount.AccountValues = BankingDetails.accountList[i].PresentAccounts[k];
                                        Program.loggedInAccount.accountOwner = i;
                                        Program.loggedInAccount.accountType = k;
                                        accountFound = true;
                                        Program.isLoggedIn = true;
                                        BankingDetails.accountList[i].PresentAccounts[k].UpToDate();
                                    }
                                }
                                break;

                                #endregion PresentAccount
                        }

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
            if (accountFound == false && createdAccount == false)
            {
                Window.Write(Messages.noAccountMessage.Length + 2, Messages.noAccountMessage);
            }
        }
    }
}