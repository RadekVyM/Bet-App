using System;

namespace BetApp.Core.Models;

public class Match
{
    public Team? FirstTeam { get; set; }
    public Team? SecondTeam { get; set; }
    public DateTime StartTime { get; set; }
}
