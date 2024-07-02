using BetApp.Core.Interfaces.ViewModels;
using BetApp.Core.Models;

namespace BetApp.Core.ViewModels;

public record MatchDetailPageParameters(Match Match) : IParameters;