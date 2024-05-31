using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projet_SpicyInvader;

namespace Projet_SpicyInvaderTests
{
    internal class PlayerShipTest
    {
        /// <summary>
        /// Test si lors de l'appel d'une méthode la position X du vaisseau évolue à gauche
        /// </summary>
        [TestMethod]
        public void TestMove_Left()
        {
            // Arrange
            PlayerShip playerShip = new PlayerShip();
            int initialX = playerShip.PositionX;

            // Act
            playerShip.Move(false);

         s   // Assert
            Assert.IsTrue(playerShip.PositionX < initialX);
        }

        /// <summary>
        /// Test si lors de l'appel d'une méthode la position X du vaisseau évolue à droite
        /// </summary>
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
    }
}
