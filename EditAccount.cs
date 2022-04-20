using System;
using System.Collections.Generic;
using System.Text;

namespace Bankkonto
{
    class EditAccount
    {
        
        public static void AccountEdit(Account _Account)
        {
            int choice = 0;
            float changeAmount;
            Window.Write(Messages.editMessage.Length + 2, Messages.editMessage);
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
                    Window.Write(Messages.withdrawMessage.Length + 2, Messages.withdrawMessage);
                    changeAmount = Convert.ToInt32(Console.ReadLine());
                    _Account.balance -= changeAmount;
                    _Account.history.Add(DateTime.Now + ": Withdrew " + changeAmount + "KR from account");
                    break;
                case 2:
                    Window.Write(Messages.depositMessage.Length + 2, Messages.depositMessage);
                    changeAmount = Convert.ToInt32(Console.ReadLine());
                    _Account.balance += changeAmount;
                    _Account.history.Add(DateTime.Now + ": Deposited " + changeAmount + "KR to account");
                    break;
            }

            Window.Write(Messages.questionMessage.Length + 2, Messages.questionMessage);

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
            }

        }
    }
}
