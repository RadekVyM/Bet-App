using System.Collections.Generic;

namespace BetApp.Core.Models;

public class Sport : List<Match>
{
    public string Name { get; set; }

    public Sport(string name) : base()
    {
        Name = name;
    }
}
