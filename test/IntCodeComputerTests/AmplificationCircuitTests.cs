using FluentAssertions;
using IntCodeComputer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntCodeComputerTests
{
    public class AmplificationCircuitTests
    {
        [Theory]
        [InlineData("4,3,2,1,0", "3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0", 43210)]
        [InlineData("0,1,2,3,4", "3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0", 54321)]
        [InlineData("1,0,4,3,2", "3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0", 65210)]
        public void PhaseSettingSequenceProducesExpectedThrusterSignal(string phaseSequence, string program, int expectedMaxSignal)
        {
            var inputCapturer = new UserInputCapturer();
            var opCodeOps = new OpCodeOperations(inputCapturer);
            var ampliCircuit = new AmplificationCircuit(opCodeOps);
            var parser = new OpCodeParser();
            
            parser.LoadInput(program);
            var result = ampliCircuit.GenerateMaxSignal(phaseSequence);

            result.Should().Be(expectedMaxSignal);
        }
    }
}
