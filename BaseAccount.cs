using System;
using System.Collections.Generic;
using System.Linq;

namespace Bankkonto
{
    [Serializable]
    internal class BaseAccount
    {
        public string accountName;
        public float balance;
        public List<string> history;

        //Writes your balance and and the accounts history.
        public static void TotalBalance(float _balance, List<string> _history)
        {
            int choice = 0;
            //Removes the oldest saved history if you have stored more
            if (_history.Count >= 20)
            {
                _history.RemoveAt(1);
            }
            //Adds a new history for your total balance at the moment.
            _history.Add(DateTime.Now + ": Your total balance is " + _balance + "KR");
            Window.Write(_history.ToArray().Concat(Messages.questionMessage).ToArray().Length + 2, _history.ToArray().Concat(Messages.questionMessage).ToArray());
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
                    Program.isLoggedIn = false;
                    break;

                case 2:
                    break;

                case 3:
                    YourBudget.Economy();
                    break;
            }
        }

        //A virtual method that the other methods of the same name later overrides.
        public virtual void UpToDate()
        {
        }
    }

    // The BudgetAccount class which is inherited of BaseAccount
    internal class BudgetAccount : BaseAccount
    {
        public Budget budgetGuide;
        public Budget budget;

        public BudgetAccount(string _accountName)
        {
            accountName = _accountName;
            balance = 0;
            history = new List<string> { DateTime.Now + ": The Account was created" };
            budgetGuide = new Budget();
            budget = new Budget();
        }
    }

    // The SavingAccount class which is inherited of BaseAccount
    internal class SavingAccount : BaseAccount
    {
        public float procentGain;
        public float time;

        public SavingAccount(string _accountName, float _procentGain)
        {
            accountName = _accountName;
            balance = 0;
            history = new List<string> { DateTime.Now + ": The Account was created" };
            procentGain = _procentGain / 100 + 1;
            time = (DateTime.Now.Year * 12) + DateTime.Now.Month;
        }

        //Uppdates the account so it has the correct amount of money.
        public override void UpToDate()
        {
            if (time < (DateTime.Now.Year * 12) + DateTime.Now.Month)
            {
                balance *= (float)Math.Pow(procentGain, (DateTime.Now.Year * 12) + DateTime.Now.Month - time);
            }
        }
    }

    // The PresentAccount class which is inherited of BaseAccount
    internal class PresentAccount : BaseAccount
    {
        public float monthlyIncome;
        public float time;

        public PresentAccount(string _accountName, float _monthlyIncome)
        {
            accountName = _accountName;
            balance = 0;
            history = new List<string> { DateTime.Now + ": The Account was created" };
            monthlyIncome = _monthlyIncome;
            time = (DateTime.Now.Year * 12) + DateTime.Now.Month;
        }

        //Uppdates the account so it has the correct amount of money.
        public override void UpToDate()
        {
            if (time < (DateTime.Now.Year * 12) + DateTime.Now.Month)
            {
                balance += monthlyIncome * ((DateTime.Now.Year * 12) + DateTime.Now.Month - time);
            }
        }
    }
}