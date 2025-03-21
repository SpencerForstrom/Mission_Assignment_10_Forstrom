namespace MissionAssignment10.API.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string? TeamName { get; set; }

        public ICollection<Bowler>? Bowlers { get; set; }
    }
}

