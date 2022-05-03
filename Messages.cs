namespace Bankkonto
{
    internal static class Messages
    {
        public static string[] startMessage = { "C#Bank", "Please choose an option", "1: Enter Account   2: Withdraw or Deposit Money to Account", "3: Create Account   4: Exit Bank" };
        public static string[] questionMessage = { "1: Logout from account   2: Go to menu", "3: Hushålla din ekonomi" };
        public static string[] hushållningMessage = { "1: Create a new Guide  2: Reset to Guide", "3: Hushålla din ekonomi  4: Return to Main menu" };
        public static string[] hushållaMessage1 = { "Write the amount of money you're earning each month" };
        public static string[] hushållaMessage2 = { "Write in the name of the expense and hit enter", "Then write the amount you're willing to spend" };
        public static string[] createAccountMessage1 = { "Create Account", "Enter AccountName" };
        public static string[] createAccountMessage2 = { "Create Account", "Enter password" };
        public static string[] enterAccountName = { "Enter Your AccountName" };
        public static string[] enterPassword = { "Enter Your password" };
        public static string[] exitMessage = { "Thank you for using C#Bank" };
        public static string[] withdrawMessage = { "Enter amount to withdraw" };
        public static string[] depositMessage = { "Enter amount to deposit" };
        public static string[] editMessage = { "Please choose an option", "1: Withdraw from account   2: Deposit to account" };
        public static string[] noAccountMessage = { "This account doesn't exist", "Please try again" };
        public static string[] duplicateAccountMessage = { "This account already exists", "Please try again" };
    }
}