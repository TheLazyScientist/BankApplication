using System;
using System.Collections.Generic;
using System.Text;

namespace Bankkonto
{
    class Messages
    {
        public static string[] startMessage = { "C#Bank","Please choose an option","1: Enter Account   2: Withdraw or Deposit Money to Account","3: Create Account   4: Exit Bank" };
        public static string[] questionMessage = { "1: Logout from account   2: Go to menu"};
        public static string[] createAccountMessage1 = { "Create Account","Enter AccountName" };
        public static string[] createAccountMessage2 = { "Create Account", "Enter password" };
        public static string[] enterAccountName = { "Enter Your AccountName" };
        public static string[] enterPassword = { "Enter Your password" };
        public static string[] exitMessage = { "Thank you for using C#Bank" };
        public static string[] withdrawMessage = { "Enter amount to withdraw" };
        public static string[] depositMessage = { "Enter amount to deposit" };
        public static string[] editMessage = { "Please choose an option","1: Withdraw from account   2: Deposit to account" };
        public static string[] duplicateAccountMessage = { "This account already exists", "Please try again" };
    }
}
