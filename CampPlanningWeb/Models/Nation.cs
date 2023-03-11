namespace CampPlanningWeb.Models
{
    public class Nation
    {
        public int NationID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
