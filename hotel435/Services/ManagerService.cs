using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel435.Models;
using Microsoft.AspNetCore.Mvc;

namespace hotel435.Services
{
    public class ManagerService : DbOperationsBase<Manager>, IManagerService
    {
        public ManagerService(Hotel435DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
