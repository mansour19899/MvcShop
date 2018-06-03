using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcInternetShop.ViewModels.Admin
{
    public class AddProductViewModel
    {
        public IEnumerable<MvcInternetShop.Models.DomainModels.Group> Groups { get; set; }
        public MvcInternetShop.Models.DomainModels.Product Product { get; set; }
    }
}