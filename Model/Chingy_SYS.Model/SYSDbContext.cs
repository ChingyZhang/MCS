using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Chingy_SYS.Model
{
    public class SYSDbContext :DbContext
    {
        public DbSet<Dictionary_Table> Dictionary_Table { get; set; }
        public DbSet<Dictionary_Column> Dictionary_Column { get; set; } 
    }
}
