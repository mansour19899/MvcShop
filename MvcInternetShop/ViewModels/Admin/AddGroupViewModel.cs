using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcInternetShop.ViewModels.Admin
{
    public class AddGroupViewModel
    {
        public IEnumerable<MvcInternetShop.Models.DomainModels.Group> Groups { get; set; }
        public MvcInternetShop.Models.DomainModels.Group Group { get; set; }
    }
}