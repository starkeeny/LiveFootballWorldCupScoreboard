// <copyright file="Team.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core.Models;

#pragma warning disable SA1313 // Parameter names should begin with lower-case letter

/// <summary>
/// Team that is represented on the scoreboard.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Team"/> class.
/// </remarks>
internal record Team(string Name);
