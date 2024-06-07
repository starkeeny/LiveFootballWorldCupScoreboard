// <copyright file="TeamNotFound.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Exception if a team is not found in active matches.
/// </summary>
public class TeamNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TeamNotFoundException"/> class.
    /// </summary>
    /// <param name="teamName">The team name as plain text string.</param>
    public TeamNotFoundException(string teamName)
        : base($"Team not found in active matches: {teamName}")
    {
    }
}
