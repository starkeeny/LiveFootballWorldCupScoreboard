# LiveFootballWorldCupScoreboard (LFWCS)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=starkeeny_LiveFootballWorldCupScoreboard&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=starkeeny_LiveFootballWorldCupScoreboard)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=starkeeny_LiveFootballWorldCupScoreboard&metric=coverage)](https://sonarcloud.io/summary/new_code?id=starkeeny_LiveFootballWorldCupScoreboard)


Repo: https://github.com/starkeeny/LiveFootballWorldCupScoreboard
CI/CD: https://github.com/starkeeny/LiveFootballWorldCupScoreboard/actions
Quality: https://sonarcloud.io/project/overview?id=starkeeny_LiveFootballWorldCupScoreboard

## Guidelines

* KISS: Keep it simple. Follow the requirements and try to implement the simplest solution you can think of that works. Do not forget about edge cases! 
* NO-DB: Use an in-memory store solution (for example just use collections to store the information you might require).
* LIB-only: We don’t expect the solution to be a REST API, command line application, a Web Service, or Microservice. Just a simple library implementation.
* TDD+SOLID: Focus on Quality. Use Test-Driven Development (TDD), pay attention to OO design, Clean Code and adherence to SOLID principles. 
* VCS: Approach. Code the solution according to your standards. Please share your solution with a link to a source control repository (e.g. GitHub, GitLab, BitBucket) as we would like you to see your progress (your commit history is important) 
* MD: Add a README.md file where beside the project documentation you can make notes of any assumption or things you would like to mention to us about your solution.

## Challenge

* Start a new match, assuming initial score 0 – 0 and adding it the scoreboard. This should capture following parameters:
  * Home team
  * Away team
* Update score. This should receive a pair of absolute scores: home team score and away team score. 
* Finish match currently in progress. This removes a match from the scoreboard.
* Get a summary of matches in progress ordered by their total score. The matches with the same total score will be returned ordered by the most recently started match in the scoreboard.

## Design

LFWCS.Core implements the requirements listed above.

It covers
* persistence
* model
* outer interface to the business logic
* the business logic

LFWCS.Tests tests the Core library.

## Settings 

### Core

* Compile with all warnings
* generate documentation xml
* add stylecop analyzer
* add sonar analyzer and settings file

### Test

* supress Warning SA1600 "Elements should be documented"
