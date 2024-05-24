// <copyright file="ModelTests.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Tests.Models;

using FluentAssertions;
using LFWCS.Core.Models;

[TestClass]
public class ModelTests
{
    [TestMethod]
    public void Given_RealWorldFootballGameToStore_When_CreatingAMatch_Then_InitializationShouldBeRight()
    {
        // Arrange
        // Act
        var match = new Match(1, new Team("Mexico"), new Team("Canada"));

        // Assert
        match.Id.Should().Be(1);
        match.InProgress.Should().BeTrue();

        match.Home.Name.Should().Be("Mexico");
        match.Away.Name.Should().Be("Canada");

        match.Score.Home.Should().Be(0);
        match.Score.Away.Should().Be(0);
        match.Score.CountGoals.Should().Be(0);
    }

    [TestMethod]
    public void Given_AMatch_When_FinishingTheMatch_Then_ItShouldBeFinished()
    {
        // Arrange
        var match = new Match(1, new Team("Mexico"), new Team("Canada"));

        // Act
        match.StopMatch();

        // Assert
        match.Id.Should().Be(1);
        match.InProgress.Should().BeFalse();

        match.Home.Name.Should().Be("Mexico");
        match.Away.Name.Should().Be("Canada");

        match.Score.Home.Should().Be(0);
        match.Score.Away.Should().Be(0);
        match.Score.CountGoals.Should().Be(0);
    }

    [TestMethod]
    public void Given_ScoreBoard_When_AddingAMatch_Then_TheMatchShouldBeAvailable()
    {
        // Arrange
        var scoreboard = new Scoreboard();
        var match = new Match(1, new Team("Mexico"), new Team("Canada"));

        // Act
        scoreboard.AddMatch(match);
        var actual = scoreboard.GetMatches();

        // Assert
        actual.Should().HaveCount(1);
        actual[0].Id.Should().Be(1);
        actual[0].InProgress.Should().BeTrue();
        actual[0].Score.CountGoals.Should().Be(0);
    }
}
