using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGuid.MVVM.Model.SubClasses
{
    public class Contacts
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WebSiteLink { get; set; }
    }
}
