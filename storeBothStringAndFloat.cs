using System.Collections.Generic;

namespace Bankkonto
{
    internal class StoreBothStringAndFloat
    {
        public List<string> expenseName;
        public List<float> expenseCost;

        public StoreBothStringAndFloat()
        {
            expenseName = new List<string>();
            expenseCost = new List<float>();
        }
    }

    internal class thisAccount
    {
        public int accountOwner = 0;
        public int accountType = 0;
        public BaseAccount AccountValues = new BaseAccount();
    }
}