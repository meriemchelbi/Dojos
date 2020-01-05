using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using DojoTemplateConsoleApp.OpCode;
using NSubstitute;
using System.Collections;

namespace DojoTemplateTestProject.OpCodeTests
{
    public class OpCodeFactoryTests
    {
        [Theory]
        [ClassData(typeof(OpCodeFactoryTestData))]
        public void CreateOpCodeCreatesExpectedOpCode(int[] opCodes, OpCode expectedOpCode)
        {
            var opCodeOperations = Substitute.For<IOperateOpCode>();
            var opCodeFactory = new OpCodeFactory(opCodeOperations);
            opCodeOperations.OpCodes = opCodes;

            var actual = opCodeFactory.CreateOpCode(0);

            actual.Should().BeEquivalentTo(expectedOpCode);
        }

    }

    internal class OpCodeFactoryTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new int[] { 1002, 4, 3, 4 },
                new OpCode()
                {
                    Instruction = 2,
                    FirstParameter = (4, 0),
                    SecondParameter = (3, 1),
                    OutputIndex = (4, 0)
                }
            };
            yield return new object[]
            {
                new int[] { 101, 5, 3, 99 },
                new OpCode()
                {
                    Instruction = 1,
                    FirstParameter = (5, 1),
                    SecondParameter = (3, 0),
                    OutputIndex = (99, 0)
                }
            };
            yield return new object[]
            {
                new int[] { 3, 6 },
                new OpCode()
                {
                    Instruction = 3,
                    FirstParameter = (6, 0),
                }
            };
            yield return new object[]
            {
                new int[] { 107, 0, 1, 5 },
                new OpCode()
                {
                    Instruction = 7,
                    FirstParameter = (0, 1),
                    SecondParameter = (1, 0),
                    OutputIndex = (5, 0)
                }
            };
            yield return new object[]
            {
                new int[] { 104, 78 },
                new OpCode()
                {
                    Instruction = 4,
                    FirstParameter = (78, 1),
                }
            };
            yield return new object[]
            {
                new int[] { 10, 3, 7 },
                null
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
