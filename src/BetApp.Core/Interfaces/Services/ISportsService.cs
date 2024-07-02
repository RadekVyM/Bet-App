using System.Collections.Generic;
using BetApp.Core.Models;

namespace BetApp.Core.Interfaces.Services;

public interface ISportsService
{
    IEnumerable<Sport> GetAllSports();
    IEnumerable<Sport> GetSport(string name);
    IEnumerable<Match> GetMatchesByDate(DateTime date);
}