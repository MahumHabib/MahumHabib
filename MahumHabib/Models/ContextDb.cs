using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MahumHabib.Models
{
    public class ContextDb : DbContext
    {
        
            public ContextDb() : base("ContextDb")
            {

            }
            public DbSet<Student> students { get; set; }
        
    }
}