using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bankkonto
{
    internal static class YourBudget
    {
        public static void Economy()
        {
            bool isMakingBudgets = true;
            while (isMakingBudgets)
            {
                Window.Write(Messages.budgettingMessage.Length + 2, Messages.budgettingMessage);

                int choice = 0;

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
                        float amount = 0;

                        BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budgetGuide.budgetHistory.Clear();
                        Window.Write(Messages.budgetMessage1.Length + 2, Messages.budgetMessage1);
                        try
                        {
                            amount = Convert.ToSingle(Console.ReadLine());
                            BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budgetGuide.totalAmountOfMoney = amount;
                        }
                        catch (FormatException)
                        {
                        }
                        float moneyLeft = amount;
                        bool moreExpenses = true;
                        BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budgetGuide.expenses = new StoreBothStringAndFloat();
                        while (moreExpenses)
                        {
                            Window.Write(Messages.budgetMessage2.Length + 2, Messages.budgetMessage2);
                            try
                            {
                                string name;
                                name = Console.ReadLine();
                                if (name.Equals("Exit", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budgetGuide.expenses.expenseName.Add("Savings");
                                    BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budgetGuide.expenses.expenseCost.Add(moneyLeft);
                                    break;
                                }
                                string amounts;
                                amounts = Console.ReadLine();
                                if (amounts.Equals("Exit", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budgetGuide.expenses.expenseName.Add("Savings");
                                    BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budgetGuide.expenses.expenseCost.Add(moneyLeft);
                                    break;
                                }

                                try
                                {
                                    moneyLeft -= Convert.ToSingle(amounts);
                                    BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budgetGuide.expenses.expenseName.Add(name);
                                    BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budgetGuide.expenses.expenseCost.Add(Convert.ToSingle(amounts));
                                }
                                catch (FormatException)
                                {
                                    break;
                                }
                            }
                            catch (FormatException)
                            {
                            }
                        }
                        break;

                    case 2:
                        string lazy = JsonConvert.SerializeObject(BankingDetails.accountList);
                        File.WriteAllText(Program.fileName, lazy);
                        BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budget = BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budgetGuide;
                        break;

                    case 3:
                        Edit();
                        break;

                    case 4:
                        Window.Write(BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budget.budgetHistory.ToArray().Length + 2,
                            BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budget.budgetHistory.ToArray());
                        Console.ReadLine();
                        break;

                    case 5:
                        isMakingBudgets = false;
                        break;
                }
            }
        }

        public static void Edit()
        {
            List<String> text = new List<string>();
            float change = 0;
            for (int i = 0; BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budget.expenses.expenseCost.Count > i; i++)
            {
                text.Add(i + 1 + ": " + BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budget.expenses.expenseName[i] + ": " + BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budget.expenses.expenseCost[i] + " KR");
            }
            text.Add("Total Budget: " + BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budget.totalAmountOfMoney + " KR");
            Window.Write(text.Count + 2, text.ToArray());
            Window.Write(Messages.editBudget.Length + 2, Messages.editBudget);
            int choice = -1;

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                //Window.Write()
                change = Convert.ToSingle(Console.ReadLine());
                if (change <= 0)
                {
                    change = 0;
                }
            }
            catch (System.FormatException)
            {
            }

            for (int i = 0; BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budget.expenses.expenseCost.Count > i; i++)
            {
                if (choice == i + 1)
                {
                    BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budget.expenses.expenseCost[i] -= change;
                    if (change != 0)
                    {
                        BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budget.budgetHistory.Add(change + " was spent on " + BankingDetails.accountList[Program.loggedInAccount.accountOwner].BudgetAccounts[Program.loggedInAccount.accountType].budget.expenses.expenseName[i]);
                    }
                }
            }
        }
    }
}