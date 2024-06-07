// <copyright file="IScoreBoardService.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core.Abstractions;

using LFWCS.Core.Models;
using System.Runtime.CompilerServices;

/// <summary>
/// Abstraction of the outer interface that can be used to access the capabilities of the score board service.
/// Here we assume that users of the library want to have a very easy way to access the service, so we keep
/// the internals of the storage away from the outer interface and define a game as a tuple of home-team+away-team
/// by making the assumption that e.g.: austria can play in the world-cup exactly once at a time and not concurrently.
/// </summary>
public interface IScoreBoardService
{
    /// <summary>
    /// Starts a new match as home-team 0:0 away-team.
    /// </summary>
    /// <param name="homeTeamName">The home team name as plain text string.</param>
    /// <param name="awayTeamName">The away team name as plain text string.</param>
    void StartNewMatch(string homeTeamName, string awayTeamName);

    /// <summary>
    /// Updates the score based on home and away team as string.
    /// </summary>
    /// <param name="homeTeamName">The home team name as plain text string.</param>
    /// <param name="homeScore">The absolute count of goals the home team shot in the current moment.</param>
    /// <param name="awayTeamName">The away team name as plain text string.</param>
    /// <param name="awayScore">The absolute count of goals the away team shot in the current moment.</param>
    void UpdateScore(string homeTeamName, int homeScore, string awayTeamName, int awayScore);

    /// <summary>
    /// Finish a match identified by home-team + away-team.
    /// </summary>
    /// <param name="homeTeamName">The home team name as plain text string.</param>
    /// <param name="awayTeamName">The away team name as plain text string.</param>
    void FinishMatch(string homeTeamName, string awayTeamName);

    /// <summary>
    /// Renders the current scoreboard into a string and orders it by Count of Goals, id (which is similar to
    /// accurance or start-time) descending.
    /// </summary>
    /// <returns>The rendered score board as string.</returns>
    string GetSummary();

    /// <summary>
    /// Get the score of an active team playing in a game.
    /// Only the score of the team handed over in the arguments will be returned.
    /// </summary>
    /// <param name="teamName">Active team name to query.</param>
    /// <returns>The amount of goals shot in the current active game.</returns>
    int GetScoreOfActiveTeam(string teamName);
}
