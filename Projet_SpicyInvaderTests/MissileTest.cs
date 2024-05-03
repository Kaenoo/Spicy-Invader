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
        [TestMethod]
        public void TestLaunchMissile()
        {
            // Arrange
            PlayerShip playerShip = new PlayerShip();
            Missile missile = new Missile(0, 0);

            // Act
            missile.LaunchMissile(playerShip);

            // Assert
            Assert.IsTrue(missile.missileLaunched);
        }

        [TestMethod]
        public void TestProgress_PlayerMissile()
        {
            // Arrange
            Missile missile = new Missile(0, 10);
            missile.isLaunchedByPlayerShip = true;
            int initialY = missile.Y;

            // Act
            missile.Progress();

            // Assert
            Assert.IsTrue(missile.Y < initialY);
        }

        [TestMethod]
        public void TestProgress_EnemyMissile()
        {
            // Arrange
            Missile missile = new Missile(0, 10);
            missile.isLaunchedByPlayerShip = false;
            int initialY = missile.Y;

            // Act
            missile.Progress();

            // Assert
            Assert.IsTrue(missile.Y > initialY);
        }
    }
}
