namespace Bankkonto
{
    internal static class Messages
    {
        //Contains all the text in multiple arrays to write multiple lines of text

        public static string[] questionMessage = { "1: Logout from account   2: Go to menu", "3: Budget your economy" };
        public static string[] budgettingMessage = { "1: Create a new Guide  2: Reset to Guide", "3: Budget your economy  4: Check your budgeting history", "5: Return to Main menu" };
        public static string[] budgetMessage1 = { "Write the amount of money you're earning each month" };
        public static string[] newAccountMessage = { "1: Create a new account   2: Use created Account" };
        public static string[] typeOfAccountMessageCreate = { "Create Account", "1: BudgetAccount", "2: SavingsAccount", "3: PresentAccount" };
        public static string[] typeOfAccountMessageEnter = { "Enter Account", "1: BudgetAccount", "2: SavingsAccount", "3: PresentAccount" };
        public static string[] budgetMessage2 = { "Write in the name of the expense and hit enter", "Then write the amount you're willing to spend", "Write Exit at any time to exit", "Leftover money will be labeled as savings" };
        public static string[] editBudget = { "Choose expense by entering it's representative number and press enter", "Then enter the amount you have spent" };
        public static string[] createHostAccountMessage1 = { "Create HostAccount", "Enter AccountName" };
        public static string[] createHostAccountMessage2 = { "Create HostAccount", "Enter password" };
        public static string[] createAccountMessage = { "Create Account", "Enter AccountName" };
        public static string[] CompanyNameMessage = { "Enter CompanyName" };
        public static string[] CompanyErrorMessage = { "This company does not have any visible stocks" };
        public static string[] enterAccountName = { "Enter Your AccountName" };
        public static string[] enterPassword = { "Enter Your password" };
        public static string[] exitMessage = { "Thank you for using C#Bank" };
        public static string[] specialValueMessage = { "Enter the amount/procentage that will be added each month" };
        public static string[] withdrawMessage = { "Enter amount to withdraw" };
        public static string[] depositMessage = { "Enter amount to deposit" };
        public static string[] editMessage = { "Please choose an option", "1: Withdraw from account   2: Deposit to account" };
        public static string[] noAccountMessage = { "This account doesn't exist", "Please try again" };
        public static string[] duplicateAccountMessage = { "This account already exists", "Please try again" };

        public static string[] instructionMessage = { "The hostAccount is the account that stores all other accounts like budgetaccount and savingsaccount-", "it also stores your password and accountname.", " ", "The BudgetAccount lets you store and edit any amount of money to your account-", "it also let's you have a seperate section where you can keep track of all your purshases and handle your economy.", " ", "The Savingsaccount gives procental profit each month based on how much is on your account.", " ", "The PresentAccount lets you set a preditermend amount that gets added to your account at the beginning of each month." };
    }
}