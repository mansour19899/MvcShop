//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcInternetShop.Models.DomainModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public bool IsRead { get; set; }
    }
}
