using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGuid.MVVM.Model.SubClasses
{
    public class OrganizationFinance
    {
        public uint Debts { get; private set; }
        public uint AuthorizedCapital { get; private set; }
        public List<KeyValuePair<string, int>> Revenue { get; private set; } = new();
        public List<KeyValuePair<string, int>> Expenses { get; private set; } = new();
        public List<KeyValuePair<string, int>> Profit { get; private set; } = new();
        public uint NumberOfEmployees { get; private set; }
    }
}
