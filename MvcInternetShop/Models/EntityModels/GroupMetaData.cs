using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcInternetShop.Models.EntityModels
{
    internal class GroupMetaData
    {
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "نام گروه را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام گروه")]
        [Display(Name = "نام گروه")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Name { get; set; }

        [DisplayName("گروه پدر")]
        [Display(Name = "گروه پدر")]
        [ScaffoldColumn(false)]
        public Nullable<int> ParentId { get; set; }
    }

}

namespace MvcInternetShop.Models.DomainModels
{
    [MetadataType(typeof(MvcInternetShop.Models.EntityModels.GroupMetaData))]
    public partial class Group
    {
    }
}


