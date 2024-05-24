// <copyright file="DuplicateTeamException.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core.Exceptions;

/// <summary>
/// Exception if a match is created twice.
/// </summary>
public class DuplicateTeamException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DuplicateTeamException"/> class.
    /// </summary>
    /// <param name="teamName">The team name as plain text string.</param>
    public DuplicateTeamException(string teamName)
        : base($"Duplicate Team: {teamName}")
    {
    }
}
