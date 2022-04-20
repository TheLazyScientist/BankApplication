using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bankkonto
{
    [Serializable]
    class Account
    {
                public string password;
        public string username;
        public float balance;
        public List <string> history;

        public Account(string _password, string _username)
        {
            password = _password;
            username = _username;
            balance = 0;
            history = new List<string>();
        }

        static public void totalBalance(float _balance, List<string> _history)
        {
            int choice = 0;

            _history.Add(DateTime.Now + ": Your total balance is " + _balance + "KR");
            Window.Write(_history.ToArray().Concat(Messages.questionMessage).ToArray().Length+2,  _history.ToArray().Concat(Messages.questionMessage).ToArray());
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                
            }

            switch(choice)
            {
                case 1:
                    Program.isLoggedIn = false;
                    break;
                case 2:
                    break;
            }
        }
    }
}
