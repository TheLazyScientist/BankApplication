using Newtonsoft.Json.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bankkonto
{
    [Serializable]
    internal class Account
    {
        [Encrypt] public string password;
        public string username;
        public float balance;
        public List<string> history;
        public Budget budget;
        public Budget budgetGuide;

        public Account(string _password, string _username)
        {
            password = _password;
            username = _username;
            balance = 0;
            history = new List<string>();
            budget = new Budget();
            budgetGuide = new Budget();
        }

        public static void totalBalance(float _balance, List<string> _history)
        {
            int choice = 0;

            if (_history.Count >= 20)
            {
                _history.RemoveAt(1);
            }

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
                    YourBudget.ekonomi();
                    break;
            }
        }
    }
}