// <copyright file="ScoreBoardService.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core;

using LFWCS.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// ScoreBoardService is the main service and outer interface of this library.
/// It enables the usage of the capabilities.
/// </summary>
public class ScoreBoardService : IScoreBoardService
{
    /// <inheritdoc/>
    public void FinishMatch(string homeTeamName, string awayTeamName)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public string GetSummary()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public void StartNewMatch(string homeTeamName, string awayTeamName)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public void UpdateScore(string homeTeamName, int homeScore, string awayTeamName, int awayScore)
    {
        throw new NotImplementedException();
    }
}
