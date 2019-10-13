using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace hotel435.Models
{
    public class Hotel435DbContext : DbContext
    {
        public Hotel435DbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Manager> Managers { get; set; }
    }
}
