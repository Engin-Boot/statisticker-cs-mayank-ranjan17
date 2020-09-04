using System;
using Xunit;
using System.Collections.Generic;
using Statistics;

namespace Statistics.Test
{
    public class StatsUnitTest
    {
        [Fact]
        public void WhenUserInputsAnNonEmptyListOfFloatStatisticsareProduced()
        {
            var statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics(
                new List<float>{1.5F, 8.9F, 3.2F, 4.5F});
            float epsilon = 0.001F;

            Assert.True(Math.Abs(computedStats.average - 4.525) <= epsilon);
            Assert.True(Math.Abs(computedStats.max - 8.9) <= epsilon);
            Assert.True(Math.Abs(computedStats.min - 1.5) <= epsilon);
        }
        [Fact]
        public void WhenUserInputsAEmptyListOfFloatNANisReturned()
        {
            var statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics(
                new List<float> { });
            //All fields of computedStats (average, max, min) must be

            Assert.True(float.IsNaN(computedStats.average));
            Assert.True(float.IsNaN(computedStats.max));
            Assert.True(float.IsNaN(computedStats.min));
        }

        [Fact]
        public void WhenUserInputsAnNonEmptyListOfFloatWithSomeNaNInputsStatisticsareProducedForTheNonNaNInput()
        {
            var statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics(
                new List<float> { 1.5F, 8.9F,float.NaN ,3.2F, 4.5F });
            float epsilon = 0.001F;

            Assert.True(Math.Abs(computedStats.average - 4.525) <= epsilon);
            Assert.True(Math.Abs(computedStats.max - 8.9) <= epsilon);
            Assert.True(Math.Abs(computedStats.min - 1.5) <= epsilon);
        }

    }
}
