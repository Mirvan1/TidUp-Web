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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TIDUPEntities : DbContext
    {
        public TIDUPEntities()
            : base("name=TIDUPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLCOMPANY> TBLCOMPANY { get; set; }
        public virtual DbSet<TBLFOLDER> TBLFOLDER { get; set; }
        public virtual DbSet<TBLPRODUCT> TBLPRODUCT { get; set; }
        public virtual DbSet<TBLUSER> TBLUSER { get; set; }
        public virtual DbSet<TBLLOGS> TBLLOGS { get; set; }
    }
}
