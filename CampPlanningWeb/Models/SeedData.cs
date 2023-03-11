using CampPlanningWeb.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CampPlanningWeb.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CampPlanningContext(serviceProvider.GetRequiredService<DbContextOptions<CampPlanningContext>>()))
            {
                if (!context.Nation.Any())
                {
                    context.Nation.AddRange(
                        (new string[] {"Varushka","Marches","Urizen","Wintermark","Dawn","League","Highguard","Brass Coast","Imperial Orcs"}).Select(n => new Nation { Name = n })
                        );
                    context.SaveChanges();
                }
            }
        }
    }
}
