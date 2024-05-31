using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projet_SpicyInvader;

namespace Projet_SpicyInvaderTests
{
    internal class MissileTest
    {
        /// <summary>
        /// Test si lors de l'appel d'une méthode, un bool s'active
        /// </summary>
        [TestMethod]
        public void TestLaunchMissile()
        {
            // Arrange
            PlayerShip playerShip = new PlayerShip();
            Missile missile = new Missile(0, 0);

            // Act
            missile.LaunchMissile(playerShip);

            // Assert
            Assert.IsTrue(missile.MissileLaunched);
        }

        /// <summary>
        ///Test si lors de l'appel d'une méthode la position Y de l'user évolue
        /// </summary>
        [TestMethod]
        public void TestProgress_PlayerMissile()
        {
            // Arrange
            Missile missile = new Missile(0, 10);
            missile.IsLaunchedByPlayerShip = true;
            int initialY = missile.Y;

            // Act
            missile.Progress();

            // Assert
            Assert.IsTrue(missile.Y < initialY);
        }

        /// <summary>
        /// Test si lors de l'appel d'une méthode la position Y de l'ennemi évolue
        /// </summary>
        [TestMethod]
        public void TestProgress_EnemyMissile()
        {
            // Arrange
            Missile missile = new Missile(0, 10);
            missile.IsLaunchedByPlayerShip = false;
            int initialY = missile.Y;

            // Act
            missile.Progress();

            // Assert
            Assert.IsTrue(missile.Y > initialY);
        }
    }
}
