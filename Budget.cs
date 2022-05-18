using System.Collections.Generic;

namespace Bankkonto
{
    internal class Budget
    {
        public float totalAmountOfMoney;
        public List<string> budgetHistory = new List<string>();
        public StoreBothStringAndFloat expenses = new StoreBothStringAndFloat();
    }
}