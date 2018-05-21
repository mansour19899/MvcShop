using MvcInternetShop.Models.DomainModels;
using MvcInternetShop.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcInternetShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            UserRepository blUser = new UserRepository();
            if (ModelState.IsValid)
            {
                if (user.BirthDate != null)
                {
                    user.BirthDate = user.BirthDate.Value.ToMiladiDate();
                }

                if (blUser.Add(user))
                {
                    //موفق
                    return MessageBox.Show("با موفقیت ثبت شد", MessageType.Success);
                }
                else
                {
                    //نا موفق
                    return MessageBox.Show("ثبت نشد", MessageType.Error);
                }
            }
            else
            {
                //خطا مقداری
                return MessageBox.Show(ModelState.GetErrors(), MessageType.Warning);
            }
        }
    
}
}