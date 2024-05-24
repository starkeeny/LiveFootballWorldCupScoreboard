// <copyright file="Score.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core.Models;

/// <summary>
/// Represents the goals shot between home team and away team.
/// </summary>
public record Score
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Score"/> class.
    /// </summary>
    /// <param name="home">The goals of the home team.</param>
    /// <param name="away">The goals of the away team.</param>
    /// <remarks>
    /// DataType is kept as int, because we are not 100% aware of special edge cases like
    /// if a game is canceled due to e.g.: hooligan fights there might be special handling
    /// for the goals. So it was kept as int.
    /// </remarks>
    public Score(int home = 0, int away = 0)
    {
        this.Home = home;
        this.Away = away;
    }

    /// <summary>
    /// Gets or sets the goals of the home team.
    /// </summary>
    public int Home { get; set; }

    /// <summary>
    /// Gets or sets the goals of the away team.
    /// </summary>
    public int Away { get; set; }

    /// <summary>
    /// Gets the amount of goals of the score.
    /// </summary>
    public int CountGoals => this.Home + this.Away;
}
