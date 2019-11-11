using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DojoTemplateConsoleApp;

namespace DojoTemplateTestProject
{
    public class FramesTestDataClass: IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                "X X X X X X X X X X X X",
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
                }

            };

            yield return new object[]
            {

                "9- 9- 9- 9- 9- 9- 9- 9- 9- 9-",
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

                }

            };

            yield return new object[]
            {

            "5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5",
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

                }

            };

            yield return new object[]
            {

            "9- 52 -/ 71 -- 16 X 11 43 -7",
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

            }

            };
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
