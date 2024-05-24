// <copyright file="Team.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core.Models;

/// <summary>
/// Team that is represented on the scoreboard.
/// </summary>
internal record Team
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Team"/> class.
    /// </summary>
    /// <param name="teamName">The team name in plain text.</param>
    public Team(string teamName)
    {
        ArgumentNullException.ThrowIfNull(teamName);

        if (string.IsNullOrWhiteSpace(teamName))
        {
            throw new ArgumentOutOfRangeException(nameof(teamName));
        }

        this.Name = teamName;
    }

    /// <summary>
    /// Gets the team's name.
    /// </summary>
    public string Name { get; }
}
