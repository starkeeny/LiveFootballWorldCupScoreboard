// <copyright file="MatchNotFoundException.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core.Exceptions;

/// <summary>
/// Exception if a match is created twice.
/// </summary>
public class MatchNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MatchNotFoundException"/> class.
    /// </summary>
    /// <param name="homeTeamName">The home team name as plain text string.</param>
    /// <param name="awayTeamName">The away team name as plain text string.</param>
    public MatchNotFoundException(string homeTeamName, string awayTeamName)
        : base($"Match not found: {homeTeamName} - {awayTeamName}")
    {
    }
}
