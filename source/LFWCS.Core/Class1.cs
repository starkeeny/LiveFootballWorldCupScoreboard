// <copyright file="Class1.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Core;

/// <summary>
/// Class for first testing.
/// </summary>
public class Class1
{
    /// <summary>
    /// Method to test unit test execution. Will be deleted later.
    /// </summary>
    /// <returns>Zero.</returns>
#pragma warning disable S3400 // Methods should not return constants
#pragma warning disable CA1822 // Mark member as static
    public int Method()
#pragma warning restore CA1822
#pragma warning restore S3400
    {
        return 0;
    }
}
