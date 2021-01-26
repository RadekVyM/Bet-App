using System;
using System.Collections.Generic;
using System.Linq;

namespace BetApp.Core
{
    public class SportsService : ISportsService
    {
        IEnumerable<Sport> sports;

        public SportsService()
        {
            sports = new List<Sport>
            {
                new Sport("CRICKET")
                {
                    new Match
                    {
                        FirstTeam = new Team { Name = "INDIA", Image = "india.png" },
                        SecondTeam = new Team { Name = "AUSTRALIA", Image = "australia.png" },
                        StartTime = DateTime.Today.AddHours(5)
                    },
                    new Match
                    {
                        FirstTeam = new Team { Name = "Knight Riders", Image = "knightriders.png" },
                        SecondTeam = new Team { Name = "Mumbai Indians", Image = "mumbaiindians.png" },
                        StartTime = DateTime.Today.AddHours(DateTime.Now.Hour + 8)
                    }
                },
                new Sport("SOCCER")
                {
                    new Match
                    {
                        FirstTeam = new Team { Name = "SEVILLA", Image = "sevilla.png" },
                        SecondTeam = new Team { Name = "ROMA", Image = "roma.png" },
                        StartTime = DateTime.Today.AddHours(12)
                    },
                    new Match
                    {
                        FirstTeam = new Team { Name = "FC Basel", Image = "basel.png" },
                        SecondTeam = new Team { Name = "Eintracht Frankfurt", Image = "frankfurt.png" },
                        StartTime = DateTime.Today.AddHours(DateTime.Now.Hour + 5)
                    }
                },
                new Sport("TENNIS")
                {
                    new Match
                    {
                        FirstTeam = new Team { Name = "INDIA", Image = "india.png" },
                        SecondTeam = new Team { Name = "AUSTRALIA", Image = "australia.png" },
                        StartTime = DateTime.Today.AddHours(DateTime.Now.Hour + 28)
                    },
                    new Match
                    {
                        FirstTeam = new Team { Name = "Basel", Image = "basel.png" },
                        SecondTeam = new Team { Name = "Frankfurt", Image = "frankfurt.png" },
                        StartTime = DateTime.Today.AddHours(DateTime.Now.Hour + 24)
                    }
                },
                new Sport("HOCKEY")
                {
                    new Match
                    {
                        FirstTeam = new Team { Name = "INDIA", Image = "india.png" },
                        SecondTeam = new Team { Name = "AUSTRALIA", Image = "australia.png" },
                        StartTime = DateTime.Today.AddHours(20)
                    },
                    new Match
                    {
                        FirstTeam = new Team { Name = "SEVILLA", Image = "sevilla.png" },
                        SecondTeam = new Team { Name = "ROMA", Image = "roma.png" },
                        StartTime = DateTime.Today.AddHours(DateTime.Now.Hour + 6.1d)
                    }
                }
            };
        }

        public IEnumerable<Sport> GetAllSports()
        {
            return sports;
        }

        public IEnumerable<Match> GetMatchesByDate(DateTime date)
        {
            List<Match> matches = new List<Match>();

            foreach(Sport sport in sports)
            {
                foreach (Match match in sport)
                {
                    if (match.StartTime.Date == date.Date)
                        matches.Add(match);
                }
            }

            return matches;
        }

        public IEnumerable<Sport> GetSport(string name)
        {
            return sports.Where(s => s.Name == name);
        }
    }
}
