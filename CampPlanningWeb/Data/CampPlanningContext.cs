using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CampPlanningWeb.Models;

namespace CampPlanningWeb.Data
{
    public class CampPlanningContext : DbContext
    {
        public CampPlanningContext (DbContextOptions<CampPlanningContext> options)
            : base(options)
        {
        }

        public DbSet<CampPlanningWeb.Models.Group> Group { get; set; }
        public DbSet<CampPlanningWeb.Models.Nation> Nation { get; set; }
        public DbSet<CampPlanningWeb.Models.TentType> TentType { get; set; }
    }
}
