// <copyright file="ScoreBoardServiceSingleTeamScoreTests.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Tests;

using FluentAssertions;
using LFWCS.Core;
using LFWCS.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]

public class ScoreBoardServiceSingleTeamScoreTests
{
    [TestMethod]
    public void Given_ScoreBoardService_When_RequestValidTeamInvolvedInAGameWithScore2on3_Then_ReturnOutputTheRightValues()
    {
        // Arrange
        var service = new ScoreBoardService();
        service.StartNewMatch("Mexico", "Canada");
        service.UpdateScore("Mexico", 2, "Canada", 3);

        // Act
        var actualHome = service.GetScoreOfActiveTeam("Mexico");
        var actualAway = service.GetScoreOfActiveTeam("Canada");

        // Assert
        actualHome.Should().Be(2);
        actualAway.Should().Be(3);
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_RequestNonActiveTeam_Then_ThrowException()
    {
        // Arrange
        var service = new ScoreBoardService();
        service.StartNewMatch("Mexico", "Canada");
        service.UpdateScore("Mexico", 2, "Canada", 3);

        // Act
        var actual = () => service.GetScoreOfActiveTeam("Austria");

        // Assert
        actual.Should().ThrowExactly<TeamNotFoundException>();
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_RequestATeamOfAFinished_Then_ThrowException()
    {
        // Arrange
        var service = new ScoreBoardService();
        service.StartNewMatch("Mexico", "Canada");
        service.UpdateScore("Mexico", 2, "Canada", 3);
        service.FinishMatch("Mexico", "Canada");

        // Act
        var actual = () => service.GetScoreOfActiveTeam("Mexico");

        // Assert
        actual.Should().ThrowExactly<TeamNotFoundException>();
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_RequestATeamWithInvalidNameNull_Then_ThrowException()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        var actual = () => service.GetScoreOfActiveTeam(null!);

        // Assert
        actual.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_RequestATeamWithInvalidNameWhitespace_Then_ThrowException()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        var actual = () => service.GetScoreOfActiveTeam(" ");

        // Assert
        actual.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }
}
