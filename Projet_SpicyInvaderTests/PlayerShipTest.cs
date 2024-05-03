using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projet_SpicyInvader;

namespace Projet_SpicyInvaderTests
{
    internal class PlayerShipTest
    {
        [TestMethod]
        public void TestUpdate_MoveRight()
        {
            // Arrange
            Invaders invaders;

            // Act
            invaders = new Invaders();
            var initialX = invaders.X;
            invaders.Update();
            invaders.Update();

            // Assert
            Assert.AreNotEqual(invaders.X, initialX);
        }

        [TestMethod]
        public void TestMove_Left()
        {
            // Arrange
            PlayerShip playerShip = new PlayerShip();
            int initialX = playerShip.PositionX;

            // Act
            playerShip.Move(false);

            // Assert
            Assert.IsTrue(playerShip.PositionX < initialX);
        }

        [TestMethod]
        public void TestMove_Right()
        {
            // Arrange
            PlayerShip playerShip = new PlayerShip();
            int initialX = playerShip.PositionX;

            // Act
            playerShip.Move(true);

            // Assert
            Assert.IsTrue(playerShip.PositionX > initialX);
        }

        [TestMethod]
        public void TestAlive()
        {
            // Arrange
            PlayerShip playerShip = new PlayerShip();

            // Act
            bool isAlive = playerShip.Alive();

            // Assert
            Assert.IsTrue(isAlive); // Le vaisseau devrait être en vie par défaut
        }
    }
}
