// <copyright file="ScoreBoardService.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core;

#pragma warning disable SA1000 // Keywords should be spaced correctly / new() feature unknown by stylecop

using LFWCS.Core.Abstractions;
using LFWCS.Core.Exceptions;
using LFWCS.Core.Models;
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
    private readonly Scoreboard scoreboard = new();

    private readonly object nextMatchIdLock = new();
    private int nextMatchId = 1;

    /// <inheritdoc/>
    public void FinishMatch(string homeTeamName, string awayTeamName)
    {
        var match = this.scoreboard.FindMatch(homeTeamName, awayTeamName)
            ?? throw new MatchNotFoundException(homeTeamName, awayTeamName);
        match.StopMatch();
        this.scoreboard.RemoveMatch(match);
    }

    /// <inheritdoc/>
    public string GetSummary()
    {
        return string.Join(
            Environment.NewLine,
            this.scoreboard.GetMatches().OrderByDescending(x => x.Score.CountGoals).ThenByDescending(x => x.Id).Select(x => $"{x.Home.Name} {x.Score.Home} - {x.Away.Name} {x.Score.Away}"));
    }

    /// <inheritdoc/>
    public void StartNewMatch(string homeTeamName, string awayTeamName)
    {
        var id = 0;

        if(this.scoreboard.FindMatch(homeTeamName, awayTeamName) != null)
        {
            throw new DuplicateMatchException(homeTeamName, awayTeamName);
        }

        if(this.scoreboard.FindTeam(homeTeamName) != null)
        {
            throw new DuplicateTeamException(homeTeamName);
        }

        if (this.scoreboard.FindTeam(awayTeamName) != null)
        {
            throw new DuplicateTeamException(awayTeamName);
        }

        lock (this.nextMatchIdLock)
        {
            id = this.nextMatchId++;
        }

        this.scoreboard.AddMatch(new Match(id, new Team(homeTeamName), new Team(awayTeamName)));
    }

    /// <inheritdoc/>
    public void UpdateScore(string homeTeamName, int homeScore, string awayTeamName, int awayScore)
    {
        var match = this.scoreboard.FindMatch(homeTeamName, awayTeamName)
            ?? throw new MatchNotFoundException(homeTeamName, awayTeamName);
        match.Score.Home = homeScore;
        match.Score.Away = awayScore;
    }
}
