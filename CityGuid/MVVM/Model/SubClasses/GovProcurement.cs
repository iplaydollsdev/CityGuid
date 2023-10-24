using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CityGuid.MVVM.Model.SubClasses
{
    public class GovProcurement
    {
        public DateTime Date { get; set; }
        public string Name { get; private set; }
        public string Revenue { get; private set; }

        public GovProcurement(DateTime date, string name, string revenue)
        {
            Date = date;
            Name = name;
            Revenue = revenue;
        }
    }
}
