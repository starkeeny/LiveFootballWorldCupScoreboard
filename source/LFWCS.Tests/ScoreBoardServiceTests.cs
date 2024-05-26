// <copyright file="ScoreBoardServiceTests.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Tests;

using FluentAssertions;
using LFWCS.Core;
using LFWCS.Core.Abstractions;
using LFWCS.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]
public class ScoreBoardServiceTests
{
    [TestMethod]
    public void Given_ScoreBoardService_When_StartingANewMatch_Then_ItShouldBePrintedCorrectlyInTheSummary()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        service.StartNewMatch("Mexico", "Canada");

        // Assert
        service.GetSummary().Should().Be("Mexico 0 - Canada 0");
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_StartingANewMatchWithNullAsCountry_Then_ItShouldThrow()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        var actual = () => service.StartNewMatch(null!, "Canada");

        // Assert
        actual.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_StartingANewMatchWithWhitespaceAsCountry_Then_ItShouldThrow()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        var actual = () => service.StartNewMatch("\t", "Canada");

        // Assert
        actual.Should().Throw<ArgumentOutOfRangeException>();
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_Starting2NewMatches_Then_ItShouldBePrintedCorrectlyInTheSummary()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        service.StartNewMatch("Mexico", "Canada");
        service.StartNewMatch("Spain", "Brazil");

        // Assert
        service.GetSummary().Should().Be(
@"Spain 0 - Brazil 0
Mexico 0 - Canada 0");
    }

    [TestMethod]
    public void Given_ScoreBoardServiceWithMatch_When_UpdatingTheScore_Then_ItShouldBePrintedCorrectlyInTheSummary()
    {
        // Arrange
        var service = new ScoreBoardService();
        service.StartNewMatch("Mexico", "Canada");

        // Act
        service.UpdateScore("Mexico", 0, "Canada", 5);

        // Assert
        service.GetSummary().Should().Be("Mexico 0 - Canada 5");
    }

    [TestMethod]
    public void Given_ScoreBoardServiceWithMatch_When_UpdatingTheScoreMultipleTimes_Then_ItShouldBePrintedCorrectlyInTheSummary()
    {
        // Arrange
        var service = new ScoreBoardService();
        service.StartNewMatch("Mexico", "Canada");

        // Act
        service.UpdateScore("Mexico", 0, "Canada", 1);
        service.UpdateScore("Mexico", 0, "Canada", 2);
        service.UpdateScore("Mexico", 0, "Canada", 3);
        service.UpdateScore("Mexico", 0, "Canada", 4);
        service.UpdateScore("Mexico", 0, "Canada", 5);

        // Assert
        service.GetSummary().Should().Be("Mexico 0 - Canada 5");
    }

    [TestMethod]
    public void Given_ScoreBoardServiceWithMatch_When_FinishingAllMatchen_Then_ItShouldNotPrintAScoreBoard()
    {
        // Arrange
        var service = new ScoreBoardService();
        service.StartNewMatch("Mexico", "Canada");

        // Act
        service.FinishMatch("Mexico", "Canada");

        // Assert
        service.GetSummary().Should().Be(string.Empty);
    }

    [TestMethod]
    public void Given_ScoreBoardServiceWithMatch_When_DoingNothing_Then_ItShouldNotPrintAScoreBoard()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        // Assert
        service.GetSummary().Should().Be(string.Empty);
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_Starting2NewMatchesAndFinishOne_Then_ItShouldBePrintedCorrectlyInTheSummary()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        service.StartNewMatch("Mexico", "Canada");
        service.StartNewMatch("Spain", "Brazil");
        service.FinishMatch("Mexico", "Canada");

        // Assert
        service.GetSummary().Should().Be("Spain 0 - Brazil 0");
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_StartingSomeMatches_Then_ItShouldBePrintedCorrectlyInTheSummary()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        service.StartNewMatch("Mexico", "Canada");
        service.StartNewMatch("Spain", "Brazil");
        service.StartNewMatch("Germany", "France");
        service.StartNewMatch("Uruguay", "Italy");
        service.StartNewMatch("Argentina", "Australia");

        service.UpdateScore("Mexico", 0, "Canada", 5);
        service.UpdateScore("Spain", 10, "Brazil", 2);
        service.UpdateScore("Germany", 2, "France", 2);
        service.UpdateScore("Uruguay", 6, "Italy", 6);
        service.UpdateScore("Argentina", 3, "Australia", 1);

        // Assert
        service.GetSummary().Should().Be(
@"Uruguay 6 - Italy 6
Spain 10 - Brazil 2
Mexico 0 - Canada 5
Argentina 3 - Australia 1
Germany 2 - France 2");
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_StartingSomeMatchesAndFinishTheFirstOnes_Then_ItShouldBePrintedCorrectlyInTheSummary()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        service.StartNewMatch("Mexico", "Canada");
        service.StartNewMatch("Spain", "Brazil");
        service.StartNewMatch("Germany", "France");
        service.StartNewMatch("Uruguay", "Italy");
        service.StartNewMatch("Argentina", "Australia");

        service.UpdateScore("Mexico", 0, "Canada", 5);
        service.UpdateScore("Spain", 10, "Brazil", 2);
        service.UpdateScore("Germany", 2, "France", 2);
        service.UpdateScore("Uruguay", 6, "Italy", 6);
        service.UpdateScore("Argentina", 3, "Australia", 1);

        service.FinishMatch("Mexico", "Canada");
        service.FinishMatch("Spain", "Brazil");

        // Assert
        service.GetSummary().Should().Be(
@"Uruguay 6 - Italy 6
Argentina 3 - Australia 1
Germany 2 - France 2");
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_StartingSomeMatchesAndFinishSome_Then_ItShouldBePrintedCorrectlyInTheSummary()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        service.StartNewMatch("Mexico", "Canada");
        service.StartNewMatch("Spain", "Brazil");
        service.StartNewMatch("Germany", "France");
        service.StartNewMatch("Uruguay", "Italy");
        service.StartNewMatch("Argentina", "Australia");

        service.UpdateScore("Mexico", 0, "Canada", 5);
        service.UpdateScore("Spain", 10, "Brazil", 2);
        service.UpdateScore("Germany", 2, "France", 2);
        service.UpdateScore("Uruguay", 6, "Italy", 6);
        service.UpdateScore("Argentina", 3, "Australia", 1);

        service.FinishMatch("Germany", "France");
        service.FinishMatch("Uruguay", "Italy");

        // Assert
        service.GetSummary().Should().Be(
@"Spain 10 - Brazil 2
Mexico 0 - Canada 5
Argentina 3 - Australia 1");
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_StartingANewMatchTwice_Then_ItShouldThrow()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        Action actual = () =>
        {
            service.StartNewMatch("Mexico", "Canada");
            service.StartNewMatch("Mexico", "Canada");
        };

        // Assert
        actual.Should().Throw<DuplicateMatchException>();
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_StartingANewMatchWithAnOccupiedTeam_Then_ItShouldThrow()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        Action actual = () =>
        {
            service.StartNewMatch("Mexico", "Canada");
            service.StartNewMatch("Mexico", "Germany");
        };

        // Assert
        actual.Should().Throw<DuplicateTeamException>();
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_StartingANewMatchWithAnOccupiedTeamMixHomeAndAway_Then_ItShouldThrow()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        Action actual = () =>
        {
            service.StartNewMatch("Mexico", "Canada");
            service.StartNewMatch("Germany", "Mexico");
        };

        // Assert
        actual.Should().Throw<DuplicateTeamException>();
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_FinishingANotStartedMatch_Then_ItShouldThrow()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        Action actual = () =>
        {
            service.FinishMatch("Mexico", "Canada");
        };

        // Assert
        actual.Should().Throw<MatchNotFoundException>();
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_FinishingAStartedMatchTwice_Then_ItShouldThrow()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        service.StartNewMatch("Mexico", "Canada");
        service.FinishMatch("Mexico", "Canada");

        Action actual = () =>
        {
            service.FinishMatch("Mexico", "Canada");
        };

        // Assert
        actual.Should().Throw<MatchNotFoundException>();
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_UpdatingAStartedAndFinishedMatch_Then_ItShouldThrow()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        Action actual = () =>
        {
            service.StartNewMatch("Mexico", "Canada");
            service.FinishMatch("Mexico", "Canada");
            service.UpdateScore("Mexico", 0, "Canada", 3);
        };

        // Assert
        actual.Should().Throw<MatchNotFoundException>();
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_UpdatingANotStartedMatch_Then_ItShouldThrow()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        Action actual = () =>
        {
            service.UpdateScore("Mexico", 0, "Canada", 3);
        };

        // Assert
        actual.Should().Throw<MatchNotFoundException>();
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_UpdatingAStartedMatchWithNegativeValues_Then_ItShouldNotThrow()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        Action actual = () =>
        {
            service.StartNewMatch("Mexico", "Canada");
            service.UpdateScore("Mexico", 0, "Canada", -3);
        };

        // Assert
        actual.Should().NotThrow();
        service.GetSummary().Should().Be("Mexico 0 - Canada -3");
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_UpdatingAStartedMatchWithHugeValues_Then_ItShouldNotThrow()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        Action actual = () =>
        {
            service.StartNewMatch("Mexico", "Canada");
            service.UpdateScore("Mexico", 15000, "Canada", 3000);
        };

        // Assert
        actual.Should().NotThrow();
        service.GetSummary().Should().Be("Mexico 15000 - Canada 3000");
    }
}
