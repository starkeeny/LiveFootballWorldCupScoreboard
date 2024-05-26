// <copyright file="ScoreBoardServiceAsyncTests.cs" company="DK">
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
public class ScoreBoardServiceAsyncTests
{
    [TestMethod]
    public void Given_ScoreBoardService_When_UpdatingTheScoreboardFromDifferentThread_Then_ItShouldBePrintedCorrectlyInTheSummary()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        Task t = Task.Run(() =>
        {
            service.StartNewMatch("Mexico", "Canada");
        });
        t.Wait();

        // Assert
        service.GetSummary().Should().Be("Mexico 0 - Canada 0");
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_UpdatingTheScoreboardFromDifferentThreadALot_Then_ItShouldBePrintedCorrectlyInTheSummary()
    {
        // Arrange
        var service = new ScoreBoardService();

        // Act
        Task t = Task.Run(() =>
        {
            for (int i = 1; i < 11; i++)
            {
                service.StartNewMatch("Mexico" + i, "Canada" + i);
            }

            // keep the first two
            for (int i = 3; i < 11; i++)
            {
                service.FinishMatch("Mexico" + i, "Canada" + i);
            }
        });
        t.Wait();

        // Assert
        service.GetSummary().Should().Be(
@"Mexico2 0 - Canada2 0
Mexico1 0 - Canada1 0");
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_UpdatingTheScoreboardFromMultipleThreadALot_Then_ItShouldBePrintedCorrectlyInTheSummary()
    {
        // Arrange
        var service = new ScoreBoardService();
        var t1 = new Task(() => AddUpdateFinishGames(service, 1, 10, 1, 1));
        var t2 = new Task(() => AddUpdateFinishGames(service, 2, 10, 1, 2));

        // Act
        t1.Start();
        t2.Start();
        t1.Wait();
        t2.Wait();

        // Assert
        service.GetSummary().Should().Be(
@"2_home_1 0 - 2_away_1 2
1_home_1 0 - 1_away_1 1");
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_UpdatingTheScoreboardFromManyThreadsALot_Then_ItShouldBePrintedCorrectlyInTheSummary()
    {
        // Arrange
        var service = new ScoreBoardService();

        var tasks = new List<Task>();
        for (int i = 0; i < 100; i++)
        {
            int teamId = i;
            var task = new Task(() => AddUpdateFinishGames(service, teamId + 1, 10, 0, 1));
            task.Start();
            tasks.Add(task);
        }

        // Act
        Task.WaitAll([.. tasks]);

        // Assert
        service.GetSummary().Should().Be(string.Empty);
    }

    [TestMethod]
    public void Given_ScoreBoardService_When_RunningTests100times_Then_NoExceptionShouldBeThrown()
    {
        for (int i = 0; i < 100; i++)
        {
            this.Given_ScoreBoardService_When_UpdatingTheScoreboardFromDifferentThread_Then_ItShouldBePrintedCorrectlyInTheSummary();
            this.Given_ScoreBoardService_When_UpdatingTheScoreboardFromDifferentThreadALot_Then_ItShouldBePrintedCorrectlyInTheSummary();
            this.Given_ScoreBoardService_When_UpdatingTheScoreboardFromMultipleThreadALot_Then_ItShouldBePrintedCorrectlyInTheSummary();
            this.Given_ScoreBoardService_When_UpdatingTheScoreboardFromManyThreadsALot_Then_ItShouldBePrintedCorrectlyInTheSummary();
        }
    }

    private static void AddUpdateFinishGames(ScoreBoardService service, int id, int addCount, int keepCount, int goals)
    {
        for (int i = 1; i < addCount + 1; i++)
        {
            service.StartNewMatch($"{id}_home_{i}", $"{id}_away_{i}");
        }

        for (int i = 1; i < addCount + 1; i++)
        {
            service.UpdateScore($"{id}_home_{i}", 0, $"{id}_away_{i}", goals);
        }

        for (int i = 1 + keepCount; i < addCount + 1; i++)
        {
            service.FinishMatch($"{id}_home_{i}", $"{id}_away_{i}");
        }
    }
}
