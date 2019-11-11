using System;
using System.Diagnostics;
using Xunit;

namespace DojoTemplateTestProject
{
    public class PomodoroTests
    {
        [Fact]
        public void TimerLastsConfiguredTime()
        {
            // arrange
            var pomodoroTimer = new PomodoroTimer();
            var stopwatch = new Stopwatch();
            
            // act
            stopwatch.Start();
            pomodoroTimer.Run(25);
            stopwatch.Stop();

            // assert
            Assert.Equal(25, stopwatch.ElapsedMilliseconds);
        }

        [Fact]
        public void UninterruptedCycleLastsExpectedTime()
        {
            // arrange
            var pomodoro = new Pomodoro();

            // act
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            pomodoro.StartCycle(25);
            stopwatch.Stop();

            // assert
            Assert.Equal(145, stopwatch.ElapsedMilliseconds);
        }
        
        [Fact]
        public void PomodoroStartCycleYieldsFourTomatoes()
        {
            // arrange
            var pomodoro = new Pomodoro();

            // act
            pomodoro.StartCycle();
            
            // assert
            Assert.Equal(4, pomodoro.TomatoCount);
            
        }

        public void PomodoroStartCycleIncrementsCountByOne()
        {
            // arrange
            var pomodoro = new Pomodoro();

            // act
            pomodoro.StartCycle();

            // assert
            Assert.Equal(1, pomodoro.CycleCount);

        }

    }
}
