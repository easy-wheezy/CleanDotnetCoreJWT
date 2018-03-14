using GateKeeper.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GateKeeper.Core.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<AccessItem> AccessItem { get; set; }
        public AccessItem_AccessRight_Link AccessItem_AccessRight_Link { get; set; }
        public AccessItemType AccessItemType { get; set; }
        public AccessRight AccessRight { get; set; }
        public AspNetUser_OrganisationHierarchy_Link AspNetUser_OrganisationHierarchy_Link { get; set; }
        public AspNetUser_Product_Link AspNetUser_Product_Link { get; set; }
        public AspNetUser_UserGroup_Link AspNetUser_UserGroup_Link { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<OrganisationHierarchy> OrganisationHierarchy { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }


    }
}
