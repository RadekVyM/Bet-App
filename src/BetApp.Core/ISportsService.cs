using System;
using System.Collections.Generic;

namespace BetApp.Core
{
    public interface ISportsService
    {
        IEnumerable<Sport> GetAllSports();
        IEnumerable<Sport> GetSport(string name);
        IEnumerable<Match> GetMatchesByDate(DateTime date);
    }
}