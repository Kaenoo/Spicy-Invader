using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Projet_SpicyInvader;

namespace Projet_SpicyInvaderTests
{
    [TestClass]
    public class InvadersTests
    {
        [TestMethod]
        public void TestCreateInvaders_Count()
        {
            // Arrange
            Invaders invaders = new Invaders();

            // Act
            invaders.CreateInvaders();

            // Assert
            Assert.AreEqual(15, invaders.invaders.Count);
        }
    }
}
