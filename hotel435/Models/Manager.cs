using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace hotel435.Models
{
    public class Manager
    {
        [Required]
        public string Id { get; set; }
    }
}
