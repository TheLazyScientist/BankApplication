using System.Collections.Generic;

namespace Bankkonto
{
    internal class storeBothStringAndFloat
    {
        public List<string> expenseName;
        public List<float> expenseCost;

        public storeBothStringAndFloat()
        {
            expenseName = new List<string>();
            expenseCost = new List<float>();
        }
    }
}