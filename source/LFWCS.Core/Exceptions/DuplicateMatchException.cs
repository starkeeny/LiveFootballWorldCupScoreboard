// <copyright file="DuplicateMatchException.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core.Exceptions;

/// <summary>
/// Exception if a match is created twice.
/// </summary>
public class DuplicateMatchException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DuplicateMatchException"/> class.
    /// </summary>
    /// <param name="homeTeamName">The home team name as plain text string.</param>
    /// <param name="awayTeamName">The away team name as plain text string.</param>
    public DuplicateMatchException(string homeTeamName, string awayTeamName)
        : base($"Duplicate Match: {homeTeamName} - {awayTeamName}")
    {
    }
}
