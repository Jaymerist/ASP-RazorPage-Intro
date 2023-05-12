using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CPSC1517_Ex03_MihiriKamiss.Models;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace CPSC1517_Ex03_MihiriKamiss.Pages.Samples
{
    public class CreateTeamsModel : PageModel
    {
        public string Feedback { get; set; }
        [BindProperty]
        public string Names { get; set; }
        [BindProperty]
        public int NumOfTeams { get; set; }
        public List<Team> CompleteTeams { get; set; }
        public bool TeamsCreated { get; set; }

        public void OnPostCreate()
        {
            string[] parts = Names.Split(Environment.NewLine);
            List<string> allNames = parts.ToList();
            List<Team> teams = new List<Team>();
            int minMembers = Convert.ToInt32(Math.Floor(Convert.ToDecimal(parts.Length) / Convert.ToDecimal(NumOfTeams)));
            int maxMembers = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(parts.Length) / Convert.ToDecimal(NumOfTeams)));
            Random random = new Random();

            //if NumOfTeams is higher than total names, decrease to total names. 
            if(NumOfTeams > allNames.Count)
            {
                NumOfTeams = allNames.Count - 1;
            }

            //Loop through number of teams chosen to be created
            for (int currentTeam = 0; currentTeam < NumOfTeams; currentTeam++)
            {
                //create list of team names for each iteration
                List<string> teamNames = new List<string>();

                //add minimum amount of members
                for (int i = 0; i < minMembers; i++)
                {
                    //create random index
                    int randomMember = random.Next(0, allNames.Count - 1);
                    //add to unique team, delete from allNames to avoid duplicate names
                    teamNames.Add(allNames[randomMember]);
                    allNames.Remove(allNames[randomMember]);
                }
                Team team = new Team(currentTeam + 1, teamNames);
                teams.Add(team);
            }

            //after minimum amount of members are in each team, check to see if the arrary of names was split evenly
            //if not, add 1 remaining name to each team until the allNames list is empty.
            if(maxMembers != minMembers)
            {
                foreach(Team team in teams)
                {
                    if(allNames.Count != 0)
                    {
                        team.TeamNames.Add(allNames[0]); //add the first name available
                        allNames.RemoveAt(0);
                    }
                }
            }

            CompleteTeams = teams;
            TeamsCreated = true;

        }

        public void OnGet()
        {
        }
    }
}
