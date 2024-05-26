// <copyright file="Match.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core.Models;

#pragma warning disable SA1313 // ParameterNamesMustBeginWithLowerCaseLetter

/// <summary>
/// Initializes a record Match.
/// </summary>
/// <param name="Id">
/// Gets the id of the match.
/// The id is responsible to determine the order in which the matches are created and identifies a match uniquely.
/// Edge case after int.Max currently not considered. Reorg of matches would need to be done.
/// </param>
/// <param name="Home">Gets the home team object.</param>
/// <param name="Away">Gets the away team object.</param>
internal record Match(int Id, Team Home, Team Away)
{
    /// <summary>
    /// Gets the score object responsible for storing the amount of goals.
    /// </summary>
    public Score Score { get; } = new Score();

    /// <summary>
    /// Gets a value indicating whether the game is still in progress.
    /// </summary>
    public bool InProgress { get; private set; } = true;

    /// <summary>
    /// Stops a match.
    /// </summary>
    /// <remarks>
    /// This implementation prevents that a stopped match can be reopened.
    /// </remarks>
    public void StopMatch()
    {
        this.InProgress = false;
    }

}
