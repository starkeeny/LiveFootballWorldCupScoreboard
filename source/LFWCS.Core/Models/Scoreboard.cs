// <copyright file="Scoreboard.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core.Models;

#pragma warning disable SA1010 // Opening square brackets should be spaced correctly

/// <summary>
/// The scoreboard that keeps track of its matches.
/// </summary>
internal class Scoreboard
{
    private readonly List<Match> matches = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="Scoreboard"/> class.
    /// </summary>
    public Scoreboard()
    {
    }

    /// <summary>
    /// Adds a match.
    /// </summary>
    /// <param name="match">A match that is taken into the scoreboard.</param>
    public void AddMatch(Match match)
    {
        this.matches.Add(match);
    }

    /// <summary>
    /// Finds a match based on the home and away team names.
    /// </summary>
    /// <param name="homeTeamName">The home team name as plain text string.</param>
    /// <param name="awayTeamName">The away team name as plain text string.</param>
    /// <returns>The match object or null.</returns>
    public Match? FindMatch(string homeTeamName, string awayTeamName)
        => this.matches.Find(x => x.Home.Name == homeTeamName && x.Away.Name == awayTeamName);

    /// <summary>
    /// Finds a match based on a related team name.
    /// </summary>
    /// <param name="teamName">The team name as plain text string.</param>
    /// <returns>The match object or null.</returns>
    public Match? FindTeam(string teamName)
        => this.matches.Find(x => x.Home.Name == teamName || x.Away.Name == teamName);

    /// <summary>
    /// Returns all stored matches.
    /// </summary>
    /// <returns>The matches as object.</returns>
    public IList<Match> GetMatches()
        => this.matches;

    /// <summary>
    /// Removes a match from the scoreboard.
    /// </summary>
    /// <param name="match">The match to remove.</param>
    public void RemoveMatch(Match match)
        => this.matches.Remove(match);
}
