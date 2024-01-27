﻿using Lesson1Swap.SwapFunc;

namespace Lesson1SwapTests.SwapFunc;

public class SwapperTests
{
    [Fact]
    public void TestData()
    {
        var swapper = Swapper.Create(5, 6);

        Assert.Equal(5, swapper.First);
        Assert.Equal(6, swapper.Second);

        swapper.First = 3;
        swapper.Second = 2;

        Assert.Equal(3, swapper.First);
        Assert.Equal(2, swapper.Second);
    }

    [Fact]
    public void SimpleSwap()
    {
        var swapper = Swapper.Create(2, 3);

        swapper.Swap();

        Assert.Equal(3, swapper.First);
        Assert.Equal(2, swapper.Second);
    }

    [Fact]
    public void AdvanvedSwap()
    {
        var swapper = Swapper.Create(2, 3);

        swapper.AdvancedSwap();

        Assert.Equal(3, swapper.First);
        Assert.Equal(2, swapper.Second);
    }
}