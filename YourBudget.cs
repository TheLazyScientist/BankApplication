using System;
using System.Collections.Generic;

namespace Bankkonto
{
    internal static class YourBudget
    {
        public static void ekonomi()
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
                        Window.Write(Messages.budgetMessage1.Length + 2, Messages.budgetMessage1);
                        try
                        {
                            amount = Convert.ToSingle(Console.ReadLine());
                            Program.loggedInAccount.budgetGuide.totalAmountOfMoney = amount;
                        }
                        catch (FormatException)
                        {
                        }
                        float moneyLeft = amount;
                        bool moreExpenses = true;
                        Program.loggedInAccount.budgetGuide.expenses = new storeBothStringAndFloat();
                        while (moreExpenses)
                        {
                            Window.Write(Messages.budgetMessage2.Length + 2, Messages.budgetMessage2);
                            try
                            {
                                string name;
                                name = Console.ReadLine();
                                if (name.Equals("Exit", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Program.loggedInAccount.budgetGuide.expenses.expenseName.Add("Entertainment");
                                    Program.loggedInAccount.budgetGuide.expenses.expenseCost.Add(moneyLeft);
                                    break;
                                }
                                string amounts;
                                amounts = Console.ReadLine();
                                if (amounts.Equals("Exit", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Program.loggedInAccount.budgetGuide.expenses.expenseName.Add("Entertainment");
                                    Program.loggedInAccount.budgetGuide.expenses.expenseCost.Add(moneyLeft);
                                    break;
                                }

                                try
                                {
                                    moneyLeft -= Convert.ToSingle(amounts);
                                    Program.loggedInAccount.budgetGuide.expenses.expenseName.Add(name);
                                    Program.loggedInAccount.budgetGuide.expenses.expenseCost.Add(Convert.ToSingle(amounts));
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
                        Program.loggedInAccount.budget = Program.loggedInAccount.budgetGuide;
                        break;

                    case 3:
                        edit();
                        break;

                    case 4:
                        isMakingBudgets = false;
                        break;
                }
            }
        }

        public static void edit()
        {
            List<String> text = new List<string>();

            for (int i = 0; Program.loggedInAccount.budget.expenses.expenseCost.Count > i; i++)
            {
                text.Add(i + 1 + ": " + Program.loggedInAccount.budget.expenses.expenseName[i] + ": " + Program.loggedInAccount.budget.expenses.expenseCost[i] + " KR");
            }

            text.Add("Total Budget: " + Program.loggedInAccount.budget.totalAmountOfMoney + " KR");
            Window.Write(text.Count + 2, text.ToArray());
            Window.Write(Messages.editBudget.Length + 2, Messages.editBudget);
            int choice = -1;

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
            }

            for (int i = 0; Program.loggedInAccount.budget.expenses.expenseCost.Count > i; i++)
            {
                if (choice == i+1)
                {
                    Program.loggedInAccount.budget.expenses.expenseCost[i] -= Convert.ToSingle(Console.ReadLine());
                }
            }
        }
    }
}