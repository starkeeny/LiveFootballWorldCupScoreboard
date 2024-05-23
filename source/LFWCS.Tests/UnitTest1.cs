// <copyright file="UnitTest1.cs" company="DK">
// Copyright (c) Daniel Kienböck. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace LFWCS.Tests;

using LFWCS.Core;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Given_Class1Instance_When_CallingMethod_Then_ResultShouldBe0()
    {
        // Arrange
        var class1 = new Class1();

        // Act
        var actual = class1.Method();

        // Assert
        Assert.AreEqual(0, actual);
    }
}