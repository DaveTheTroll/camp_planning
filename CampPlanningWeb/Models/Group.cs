using System.ComponentModel.DataAnnotations;

namespace CampPlanningWeb.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public int NationID { get; set; }
        public Nation Nation { get; set; }

    }
}
