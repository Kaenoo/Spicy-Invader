using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Projet_SpicyInvader;

namespace Projet_SpicyInvaderTests
{
    [TestClass]
    public class InvadersTests
    {
        /// <summary>
        /// Teste si le nombre d'ennemies est égal à celui attendu
        /// </summary>
        [TestMethod]
        public void TestCreateInvaders_Count()
        {
            // Arrange
            Invaders invaders = new Invaders();

            // Act
            invaders.CreateInvaders();

            // Assert
            Assert.AreEqual(15, invaders.Invaderss.Count);
        }

        /// <summary>
        /// Test si lors de l'appel d'une méthode la position X du vaisseau ennemi évolue
        /// </summary>

        [TestMethod]
        public void TestUpdate_MoveRight()
        {
            // Arrange
            Invaders invaders;

            // Act
            invaders = new Invaders();
            int initialX = invaders.X;
            invaders.Update();
            invaders.Update();

            // Assert
            Assert.IsTrue(invaders.X > initialX);
        }
    }
}
