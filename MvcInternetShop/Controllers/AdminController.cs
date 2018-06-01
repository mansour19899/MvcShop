using MvcInternetShop.Helpers.Filters;
using MvcInternetShop.Models.DomainModels;
using MvcInternetShop.Models.Repositories;
using MvcInternetShop.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcInternetShop.Controllers
{
    public class AdminController : Controller
    {
        GroupRepository blGroup = new GroupRepository();

        //
        // GET: /Admin/

        public ActionResult Groups()
        {
            var model = new AddGroupViewModel();
            model.Groups = blGroup.Select().ToList();
            return View(model);
        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteGroup(int id)
        {
            if (blGroup.Delete(id))
            {
                return Json(new JsonData()
                {
                    Script = MessageBox.Show("با موفقیت حذف شد", MessageType.Success).Script,
                    Success = true,
                    Html = this.RenderPartialToString("_GroupList", blGroup.Select().ToList())
                });
            }
            else
            {
                return Json(new JsonData
                {
                    Script = MessageBox.Show("حذف نشد", MessageType.Error).Script,
                    Success = false,
                    Html = ""
                });
            }
        }



        [HttpPost]
        [AjaxOnly]
        public ActionResult AddGroup(Group group)
        {
            if (ModelState.IsValid)
            {
                if (blGroup.Add(group))
                {
                    //موفق
                    return Json(new JsonData()
                    {
                        Script = MessageBox.Show("با موفقیت ثبت شد", MessageType.Success).Script,
                        Success = true,
                        Html = this.RenderPartialToString("_GroupList", blGroup.Select().ToList())
                    });
                }
                else
                {
                    //نا موفق
                    return Json(new JsonData
                    {
                        Script = MessageBox.Show("ثبت نشد", MessageType.Error).Script,
                        Success = false,
                        Html = ""
                    });
                }
            }
            else
            {
                //خطا مقداری
                return Json(new JsonData
                {
                    Script = MessageBox.Show(ModelState.GetErrors(), MessageType.Warning).Script,
                    Success = false,
                    Html = ""
                });
            }
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult EditGroup(Group group)
        {
            if (ModelState.IsValid && group.Id != 0)
            {
                if (blGroup.Update(group))
                {
                    //موفق
                    return Json(new JsonData()
                    {
                        Script = MessageBox.Show("با موفقیت ویرایش شد", MessageType.Success).Script,
                        Success = true,
                        Html = this.RenderPartialToString("_GroupList", blGroup.Select().ToList())
                    });
                }
                else
                {
                    //نا موفق
                    return Json(new JsonData
                    {
                        Script = MessageBox.Show("ویرایش نشد", MessageType.Error).Script,
                        Success = false,
                        Html = ""
                    });
                }
            }
            else
            {
                //خطا مقداری
                return Json(new JsonData
                {
                    Script = MessageBox.Show(ModelState.GetErrors(), MessageType.Warning).Script,
                    Success = false,
                    Html = ""
                });
            }
        }

        public class JsonData
        {
            public string Script { get; set; }
            public string Html { get; set; }
            public bool Success { get; set; }
        }
    }
}
