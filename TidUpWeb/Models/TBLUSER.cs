//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TidUpWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLUSER
    {
        public int ID { get; set; }
        public string EMAIL { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string ROLE { get; set; }
        public Nullable<int> COMPANYID { get; set; }
        public Nullable<bool> STATUS { get; set; }
    
        public virtual TBLCOMPANY TBLCOMPANY { get; set; }
    }
}
