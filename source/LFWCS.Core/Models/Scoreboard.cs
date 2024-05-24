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
    /// Returns all stored matches.
    /// </summary>
    /// <returns>The matches as object.</returns>
    public IList<Match> GetMatches()
    {
        return this.matches;
    }
}
