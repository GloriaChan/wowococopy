using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecard.Model
{
    public class DbBridge : DbContext
    {
        //Default Constructor
        public DbBridge() { }

        //Constructor (Just do this)
        public DbBridge(DbContextOptions<DbBridge> options) : base(options) { }

        //Table in the Database; each table gets its own line
        //public DbSet<ENTER - TableName - Here> Enter-tablename-here {get;set;}
        public DbSet<Greetings> Greetings { get; set; }

        public DbSet<Favorites> Favorites { get; set; }
    }
}
