using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    public class CharacterTest
    {
        private Character character;

        [SetUp]
        public void Setup()
        {
            character = new Character("Frank", RaceCategory.Elf, 100);
        }

        [Test]
        public void TakeDamage()
        {
            character.TakeDamage(60);
            Assert.GreaterOrEqual(character.Health, 40);
            character.TakeDamage(60);
            Assert.IsFalse(character.IsAlive);
        }

        [Test]
        public void RestoreHealth()
        {
            character.Health = 50;
            character.RestoreHealth(20);
            Assert.IsTrue(character.Health == 70);

            character.RestoreHealth(100);
            Assert.IsTrue(character.Health == character.MaxHealth);

            character.Health -= character.MaxHealth;
            character.IsAlive = false;
            character.RestoreHealth(character.MaxHealth);
            Assert.IsTrue(character.IsAlive);
        }
    }
}
