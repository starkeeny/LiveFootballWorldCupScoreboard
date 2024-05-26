// <copyright file="Scoreboard.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core.Models;

using System.Collections.Concurrent;

#pragma warning disable SA1010 // Opening square brackets should be spaced correctly

/// <summary>
/// The scoreboard that keeps track of its matches.
/// </summary>
internal class Scoreboard
{
    /// <summary>
    /// Internal store of all matches. ConcurrentBag (which is the appropriate concurrent
    /// collection to List has very inconvient deletion), so I moved to concurrent dictionary
    /// and used the matchId as key, which is not great, because it is not used in the API. A
    /// better approach would be a string which makes a hash of home-away to make direct access
    /// possible, or to use a tuple of home-away or a string concatination. Here duplicates need to
    /// be considered: HomeA+AwayB == HomeAA + wayB which made me think that it might be smarter
    /// to use something that is not driven by the customer of the api, but created by the application
    /// uniquely.
    /// </summary>
    private readonly ConcurrentDictionary<int, Match> matches = [];

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
        this.matches.TryAdd(match.Id, match);
    }

    /// <summary>
    /// Finds a match based on the home and away team names.
    /// </summary>
    /// <param name="homeTeamName">The home team name as plain text string.</param>
    /// <param name="awayTeamName">The away team name as plain text string.</param>
    /// <returns>The match object or null.</returns>
    public Match? FindMatch(string homeTeamName, string awayTeamName)
        => this.matches.FirstOrDefault(x => x.Value.Home.Name == homeTeamName && x.Value.Away.Name == awayTeamName).Value;

    /// <summary>
    /// Finds a match based on a related team name.
    /// </summary>
    /// <param name="teamName">The team name as plain text string.</param>
    /// <returns>The match object or null.</returns>
    public Match? FindTeam(string teamName)
        => this.matches.FirstOrDefault(x => x.Value.Home.Name == teamName || x.Value.Away.Name == teamName).Value;

    /// <summary>
    /// Returns all stored matches.
    /// </summary>
    /// <returns>The matches as object.</returns>
    public ICollection<Match> GetMatches()
        => this.matches.Values;

    /// <summary>
    /// Removes a match from the scoreboard.
    /// </summary>
    /// <param name="match">The match to remove.</param>
    public void RemoveMatch(Match match)
        => this.matches.TryRemove(match.Id, out _);
}
