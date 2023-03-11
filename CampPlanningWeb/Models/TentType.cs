using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CampPlanningWeb.Models
{
    public class TentType
    {
        public int TentTypeID { get; set; }
        public string Description { get; set; }
        [Display(Name="Plan Image")]
        public string PlanImage { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }
}
