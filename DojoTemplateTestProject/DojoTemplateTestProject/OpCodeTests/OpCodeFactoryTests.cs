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
                new int[] { 2, 3, 0, 3 },
                new OpCode()
                {
                    Instruction = 2,
                    FirstParameter = 3,
                    SecondParameter = 0,
                    OutputIndex = 3
                }
            };
            yield return new object[]
            {
                new int[] { 1, 5, 3, 99 },
                new OpCode()
                {
                    Instruction = 1,
                    FirstParameter = 5,
                    SecondParameter = 3,
                    OutputIndex = 99
                }
            };
            yield return new object[]
            {
                new int[] { 3, 6 },
                new OpCode()
                {
                    Instruction = 3,
                    FirstParameter = 6,
                }
            };
            yield return new object[]
            {
                new int[] { 4, 78 },
                new OpCode()
                {
                    Instruction = 4,
                    FirstParameter = 78,
                }
            };
            yield return new object[]
            {
                new int[] { 6, 3, 7 },
                null
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
