namespace CPSC1517_Ex03_MihiriKamiss.Models
{
    public class Team
    {
        public int Id { get; set; }
        public List<string> TeamNames { get; set; }
        public Team(int id, List<string> allNames)
        {
            Id = id;
            TeamNames = allNames;
        }
    }
}
