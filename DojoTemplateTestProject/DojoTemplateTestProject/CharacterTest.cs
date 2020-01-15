using DojoTemplateConsoleApp;
using System;
using Xunit;

namespace DojoTemplateTestProject
{
    public class CharacterTest
    {
        [Fact]
        public void DealDamageRemovesExpectedHealth()
        {
            var char1 = new Character();
            var victim = new Character();

            char1.DealDamage(victim, 50);

            Assert.Equal(950, victim.Health);
        }
        
        public void DealDamageKillsCharacterWhenDamageHigherThanHealth()
        {
            var char1 = new Character();
            var victim = new Character() { Health = 250 };

            char1.DealDamage(victim, 500);

            Assert.Equal(0, victim.Health);
            Assert.True(victim.IsDead);
        }

        [Fact]
        public void HealAddsExpectedHealth()
        {
            var victim = new Character() { Health = 300 };

            victim.Heal(500);

            Assert.Equal(800, victim.Health);
        }

        [Fact]
        public void CharacterCannotHealWhenDead()
        {
            var victim = new Character() { Health = 0, IsDead = true };

            victim.Heal(500);

            Assert.True(victim.IsDead);
            Assert.Equal(0, victim.Health);
        }

        [Fact]
        public void CharacterCannotHaveMoreThan1000Health()
        {
            var victim = new Character() { Health = 600 };

            victim.Heal(500);

            Assert.Equal(1000, victim.Health);
        }

        [Fact]
        public void CharacterCannotDamageHimself()
        {
            var char1 = new Character();

            char1.DealDamage(char1, 50);

            Assert.Equal(1000, char1.Health);
        }

        [Fact]
        public void CharacterCanOnlyHealThemselves()
        {
            // nothing to do here;
        }

        [Theory]
        [InlineData(2, 9, 950)]
        [InlineData(9, 2, 800)]
        public void DamageReducedByHalfIfVictim5MoreLevelsAboveAttacker(int attackerLevel, int victimLevel, int expectedVictimHealth)
        {
            var char1 = new Character() { Level = attackerLevel };
            var victim = new Character() { Level = victimLevel };

            char1.DealDamage(victim, 100);

            Assert.Equal(expectedVictimHealth, victim.Health);
        }

        [Fact]
        public void PlayerInflictNoDamageWhenVictimOutOfRange()
        {
            var meleeFighter = new MeleeFighter() { Position = 5 };
            var rangedFighter = new RangedFighter() { Position = 10 };

            meleeFighter.DealDamage(rangedFighter, 100);

            Assert.Equal(1000, rangedFighter.Health);
        }
    }
}
