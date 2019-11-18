using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DojoTemplateConsoleApp;

namespace DojoTemplateTestProject
{
    public class CalculateScoresTestData: IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<Frame>
                {
                    new Frame() {Roll1 = 10, Roll2 = 0, IsStrike = true},
                    new Frame() {Roll1 = 10, Roll2 = 0, IsStrike = true},
                    new Frame() {Roll1 = 10, Roll2 = 0, IsStrike = true},
                    new Frame() {Roll1 = 10, Roll2 = 0, IsStrike = true},
                    new Frame() {Roll1 = 10, Roll2 = 0, IsStrike = true},
                    new Frame() {Roll1 = 10, Roll2 = 0, IsStrike = true},
                    new Frame() {Roll1 = 10, Roll2 = 0, IsStrike = true},
                    new Frame() {Roll1 = 10, Roll2 = 0, IsStrike = true},
                    new Frame() {Roll1 = 10, Roll2 = 0, IsStrike = true},
                    new Frame() {Roll1 = 10, Roll2 = 0, IsStrike = true},
                    new Frame() {Roll1 = 10, Roll2 = 0, IsStrike = true},
                    new Frame() {Roll1 = 10, Roll2 = 0, IsStrike = true}
                },
                300

            };

            yield return new object[]
            {

                new List<Frame>
                {
                    new Frame() {Roll1 = 9, Roll2 = 0},
                    new Frame() {Roll1 = 9, Roll2 = 0},
                    new Frame() {Roll1 = 9, Roll2 = 0},
                    new Frame() {Roll1 = 9, Roll2 = 0},
                    new Frame() {Roll1 = 9, Roll2 = 0},
                    new Frame() {Roll1 = 9, Roll2 = 0},
                    new Frame() {Roll1 = 9, Roll2 = 0},
                    new Frame() {Roll1 = 9, Roll2 = 0},
                    new Frame() {Roll1 = 9, Roll2 = 0},
                    new Frame() {Roll1 = 9, Roll2 = 0}

                },
                90

            };

            yield return new object[]
            {

                new List<Frame>
                {
                    new Frame() {Roll1 = 5, Roll2 = 5, IsSpare = true},
                    new Frame() {Roll1 = 5, Roll2 = 5, IsSpare = true},
                    new Frame() {Roll1 = 5, Roll2 = 5, IsSpare = true},
                    new Frame() {Roll1 = 5, Roll2 = 5, IsSpare = true},
                    new Frame() {Roll1 = 5, Roll2 = 5, IsSpare = true},
                    new Frame() {Roll1 = 5, Roll2 = 5, IsSpare = true},
                    new Frame() {Roll1 = 5, Roll2 = 5, IsSpare = true},
                    new Frame() {Roll1 = 5, Roll2 = 5, IsSpare = true},
                    new Frame() {Roll1 = 5, Roll2 = 5, IsSpare = true},
                    new Frame() {Roll1 = 5, Roll2 = 5, IsSpare = true},
                    new Frame() {Roll1 = 5, Roll2 = 0}
                },
                150

            };

            yield return new object[]
            {

            new List<Frame>
            {
                new Frame() {Roll1 = 9, Roll2 = 0},
                new Frame() {Roll1 = 5, Roll2 = 2},
                new Frame() {Roll1 = 0, Roll2 = 10, IsSpare = true},
                new Frame() {Roll1 = 7, Roll2 = 1},
                new Frame() {Roll1 = 0, Roll2 = 0},
                new Frame() {Roll1 = 1, Roll2 = 6},
                new Frame() {Roll1 = 10, Roll2 = 0, IsStrike = true},
                new Frame() {Roll1 = 1, Roll2 = 1},
                new Frame() {Roll1 = 4, Roll2 = 3},
                new Frame() {Roll1 = 0, Roll2 = 7},

            },
            76

            };
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
