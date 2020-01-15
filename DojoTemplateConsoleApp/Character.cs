using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Character
    {
        public int Health { get; set; } = 1000;
        public int Level { get; set; } = 1;
        public bool IsDead { get; set; }
        public int Position { get; set; }
        public int AttackRange { get; set; }

        public void DealDamage(Character victim, int damage)
        {
            if ((Math.Abs(Position - victim.Position) > AttackRange) 
                || victim == this)
            {
                return;
            }
            if (victim.Level - Level >= 5)
            {
                victim.Health -= damage / 2;
            }
            else if (Level - victim.Level >= 5)
            {
                victim.Health -= damage * 2;
            }
            else
            {
                victim.Health -= damage;
            }

            if (victim.Health <= 0)
            {
                victim.IsDead = true;
                victim.Health = 0;
            }
        }

        public void Heal(int health)
        {
            if (this.Health < 1000)
            {
                this.Health += health;
            }
            if (this.Health > 1000)
            {
                this.Health = 1000;
            }
            if (this.IsDead)
            {
                this.Health = 0;
            }
        }
    }
}
