using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AzureWebApp.Models
{
    public class RetailStoreContext : DbContext
    {
        public RetailStoreContext()
            :base("name=Context")
        {

        }

        public virtual DbSet<RetailStore> RetailStores { get; set; }
    }
}