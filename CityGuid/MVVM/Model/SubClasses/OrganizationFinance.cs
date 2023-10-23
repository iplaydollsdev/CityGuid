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
        public uint Revenue { get; private set; }
        public uint Expenses { get; private set; }
        public uint Profit { get; private set; }
        public uint NumberOfEmployees { get; private set; }
    }
}
