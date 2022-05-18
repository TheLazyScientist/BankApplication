using System;
using System.Collections.Generic;

namespace Bankkonto
{
    [Serializable]
    internal static class BankingDetails
    {
        public static List<AccountCollection> accountList = new List<AccountCollection>();
    }

    internal class AccountCollection
    {
        public string password;
        public string username;
        public List<BudgetAccount> BudgetAccounts;
        public List<PresentAccount> PresentAccounts;
        public List<SavingAccount> SavingAccounts;

        public AccountCollection(string _password, string _username)
        {
            password = _password;
            username = _username;
            BudgetAccounts = new List<BudgetAccount>();
            PresentAccounts = new List<PresentAccount>();
            SavingAccounts = new List<SavingAccount>();
        }
    }
}