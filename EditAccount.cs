using System;

namespace Bankkonto
{
    internal static class EditAccount
    {
        public static void AccountEdit(BaseAccount _Account)
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
            //Removes the oldest message in your accounts history after it has reached twenty messages.
            if (_Account.history.Count >= 20)
            {
                _Account.history.RemoveAt(1);
            }

            switch (choice)
            {
                //Allows you to enter an amount to withdraw from your account
                case 1:
                    Window.Write(Messages.withdrawMessage.Length + 2, Messages.withdrawMessage);
                    changeAmount = Convert.ToInt32(Console.ReadLine());
                    _Account.balance -= changeAmount;
                    _Account.history.Add(DateTime.Now + ": Withdrew " + changeAmount + "KR from account");
                    break;
                //Allows you to enter an amount to deposit to your account
                case 2:
                    Window.Write(Messages.depositMessage.Length + 2, Messages.depositMessage);
                    changeAmount = Convert.ToInt32(Console.ReadLine());
                    _Account.balance += changeAmount;
                    _Account.history.Add(DateTime.Now + ": Deposited " + changeAmount + "KR to account");
                    break;
                //Allows you to work on your budget/economy
                case 3:
                    YourBudget.Economy();
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
                //Logs you out from your account.
                case 1:
                    Program.isLoggedIn = false;
                    break;
                //Returns you back to the menu.
                case 2:
                    break;
                //Allows you to work on your budget/economy.
                case 3:
                    YourBudget.Economy();
                    break;
            }
        }
    }
}